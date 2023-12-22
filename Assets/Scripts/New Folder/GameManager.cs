using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public String currentScene;
    public String NextScene;

    public bool isPause;

    public int currentTime;
    public int apple;
    public int score;

    private void Awake()
    {
        if(GameManager.Instance == null)
        {
            GameManager.Instance = this;
        }
    }

    private void Start()
    {
        StartCoroutine(TimeCountDownt());
    }

    IEnumerator TimeCountDownt()
    {
        while (currentTime > 0 && !isPause)
        {
            yield return new WaitForSeconds(1);
            currentTime--;
            UIManager.Instance.SetTime(currentTime);
        }
    }

    public void AddApple(int amount)
    {
        apple += amount;
        UIManager.Instance.SetApple(apple);
    }

    public void AddScore(int amount)
    {
        score += amount;
        UIManager.Instance.SetScore(score);
    }

    public void Main()
    {
        SceneManager.LoadSceneAsync("Menu");
    }


    public void Lose()
    {
        UIManager.Instance.ShowUIDelay(UIManager.Instance.LoseMenu, 2);
        isPause = true;
    }

    public void Win()
    {
        UIManager.Instance.ShowUIDelay(UIManager.Instance.WinMenu, 0.5f);
        isPause = true;
    }

    public void Resume()
    {
        isPause = false;
        StartCoroutine(TimeCountDownt());
    }

    public void Reload()
    {
        SceneManager.LoadSceneAsync(currentScene);
    }

    public void NextLevel()
    {
        SceneManager.LoadSceneAsync(NextScene);
    }
}

