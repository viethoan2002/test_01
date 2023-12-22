using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public ParticleSystem particle;
    public Material material;
    public Material materialFlip;
    public PlayerComponent player;
    public List<PlayerData> playerDatas = new List<PlayerData>();

    public Vector2 checkPoint;

    public bool isDead;
    public bool isSuper;

    private void Start()
    {
        PlayerData data = playerDatas[PlayerPrefs.GetInt("PlayerIndex")];
        player.playerAnimatorCtrl.animator.runtimeAnimatorController = data.animatorOverride;
        material = data.material;
        materialFlip = data.materialFlip;
    }

    public void RePoint()
    {
        player.locomotion.canMove = true;
        player.locomotion.rb.gravityScale = 2;
        player.GetComponent<Collider2D>().enabled = true;
        player.playerAnimatorCtrl.spriteRenderer.enabled = true;
        player.playerStats.isDead = false;
        transform.position = checkPoint;
    }

    public void OnDead()
    {
        if(!isDead)
        {
            isDead = true;
            player.locomotion.canMove= false;
            player.locomotion.rb.gravityScale = 0;
            player.locomotion.rb.velocity = Vector2.zero;
            player.GetComponent<Collider2D>().enabled = false;
            player.playerAnimatorCtrl.spriteRenderer.enabled = false;
            if (player.locomotion.isFlip)
            {
                particle.GetComponent<Renderer>().material = materialFlip;
            }
            else
            {
                particle.GetComponent<Renderer>().material = material;
            }

            particle.Play();
            
            GameManager.Instance.Lose();
        }       
    }

    public void OnSuper()
    {
        player.locomotion.canMove = false;
        player.gameObject.layer = LayerMask.NameToLayer("Stun");
        player.locomotion.rb.velocity = Vector2.zero;
        player.playerAnimatorCtrl.PlayerTargetAnimation("Hit");

        StartCoroutine(OverScale(new Vector3(1, 1, 1), new Vector3(1.2f, 1.2f, 1.2f), 2));
        StartCoroutine(SetSuper(true,2));
    }

    public void OnTini()
    {
        player.locomotion.canMove = false;
        player.gameObject.layer = LayerMask.NameToLayer("Stun");
        player.locomotion.rb.velocity = Vector2.zero;
        player.playerAnimatorCtrl.PlayerTargetAnimation("Hit");

        StartCoroutine(OverScale(new Vector3(1.2f, 1.2f, 1.2f), new Vector3(1, 1, 1), 2f));
        StartCoroutine(SetSuper(false,2f));
    }

    IEnumerator SetSuper(bool isSuper,float timeScale)
    {
        yield return new WaitForSeconds(timeScale);
        this.isSuper = isSuper;
    }

    IEnumerator OverScale(Vector3 from, Vector3 to,float timeScale)
    {
        float elapsed = 0f;
        float duration = timeScale;

        while (elapsed < duration)
        {
            float t = elapsed / duration;

            transform.localScale = Vector3.Lerp(from, to, t);
            elapsed += Time.deltaTime;

            yield return null;
        }

        transform.localScale = to;
        player.locomotion.canMove = true;
        player.gameObject.layer = LayerMask.NameToLayer("Player");
        player.playerAnimatorCtrl.PlayerTargetAnimation("Move");

    }
}
