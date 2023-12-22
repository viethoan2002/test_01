using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectPlayer : MonoBehaviour
{
    public List<AnimatorOverrideController> animatorOverrideControllers = new List<AnimatorOverrideController>();
    public Animator animator;
    public GameObject leftBtn;
    public GameObject rightBtn;
    public int currentIndex;

    private void Start()
    {
        currentIndex = PlayerPrefs.GetInt("PlayerIndex");
        animator.runtimeAnimatorController = animatorOverrideControllers[currentIndex];

        if (currentIndex == 0)
        {
            leftBtn.SetActive(false);
        }

        if (currentIndex == animatorOverrideControllers.Count - 1)
        {
            rightBtn.SetActive(false);
        }
    }

    public void ChangeLeft()
    {
        currentIndex -= 1;
        animator.runtimeAnimatorController = animatorOverrideControllers[currentIndex];
        PlayerPrefs.SetInt("PlayerIndex", currentIndex);

        if (currentIndex == 0)
        {
            leftBtn.SetActive(false);
        }

        if (currentIndex < animatorOverrideControllers.Count - 1)
            rightBtn.SetActive(true);
    }

    public void ChangeRight()
    {
        currentIndex += 1;
        animator.runtimeAnimatorController = animatorOverrideControllers[currentIndex];
        PlayerPrefs.SetInt("PlayerIndex", currentIndex);

        if (currentIndex == animatorOverrideControllers.Count-1)
        {
            rightBtn.SetActive(false);
        }

        if (currentIndex > 0)
            leftBtn.SetActive(true);
    }
}
