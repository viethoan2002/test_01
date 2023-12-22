using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;
    public GameObject LoseMenu;
    public GameObject WinMenu;
    public GameObject PauseMenu;

    public TMP_Text appleText;
    public TMP_Text timeText;
    public TMP_Text scoreText;

    private void Awake()
    {
        if (UIManager.Instance == null)
        {
            UIManager.Instance = this;
        }
    }

    public void ShowUIDelay(GameObject UI,float timeDelay)
    {
        StartCoroutine(DelayUI(UI,timeDelay));
    }

    IEnumerator DelayUI(GameObject UI, float timeDelay)
    {
        yield return new WaitForSeconds(timeDelay);
        UI.gameObject.SetActive(true);
    }

    public void SetApple(int amount)
    {
        appleText.text = amount.ToString();
    }

    public void SetScore(int amount)
    {
        scoreText.text=amount.ToString();
    }

    public void SetTime(int amount)
    {
        timeText.text = amount.ToString();
    }
}
