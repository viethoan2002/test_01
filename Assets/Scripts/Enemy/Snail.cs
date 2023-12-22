using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snail : MonoBehaviour
{
    public EnemyStateManager enemyStateManager;
    public CharacterAnimatorCtrl characterAnimator;
    public ParticleSystem particle;
    public GameObject Model;

    public bool canDamage;
    public bool isShell;
    public bool isDead;
    public bool endIdle;

    public State shellState;
    public State currentState;
    public State shellIdleState;
    public State withOutShellState;

    public Material material;

    private void Update()
    {
        currentState.UpdateSate(enemyStateManager);
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player") && canDamage)
        {
            if (collision.transform.GetComponent<PlayerStats>().isSuper)
            {
                collision.transform.GetComponent<PlayerStats>().OnTini();
            }
            else
                collision.transform.GetComponent<PlayerStats>().OnDead();
        }
        else if(collision.transform.CompareTag("Player") && !canDamage)
        {
            StartCoroutine(ChangeWithOutShell(collision.transform.position.x));       
        }
    }

    IEnumerator ChangeWithOutShell(float x)
    {
        if (transform.position.x > x)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        else
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        currentState = withOutShellState;
  
        yield return new WaitForSeconds(0.1f);
        canDamage = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Player") && !isShell)
        {
            if(!endIdle)
            {
                particle.Play();
                endIdle = true;
            }
           

            collision.transform.GetComponent<PlayerLocomotion>().Up();
            canDamage = false;
            characterAnimator.PlayerTargetAnimation("Shell_Idle");
            currentState = shellIdleState;
            isShell = true;

            GameManager.Instance.AddScore(30);
        }
        else if(collision.transform.CompareTag("Player") && isShell && currentState!=withOutShellState)
        {
            currentState = withOutShellState;
        }else if (collision.transform.CompareTag("Player") && currentState == withOutShellState)
        {
            collision.transform.GetComponent<PlayerLocomotion>().Up();
            OnDead();
        }
    }


    public void OnDead()
    {
        GameManager.Instance.AddScore(50);

        isDead = true;
        canDamage = false;
        transform.gameObject.layer = LayerMask.NameToLayer("Stun");

        ParticleSystem.TextureSheetAnimationModule textureSheet = particle.textureSheetAnimation;
        textureSheet.enabled = true;
        textureSheet.numTilesX = 5;
        particle.GetComponent<Renderer>().material = material;

        enemyStateManager.rb.velocity = Vector2.zero;

        particle.Play();
        if (Model != null)
        {
            Model.SetActive(false);
            StartCoroutine(DesObj());
        }
    }

    IEnumerator DesObj()
    {
        yield return new WaitForSeconds(1);
        Destroy(this.gameObject);
    }
}
