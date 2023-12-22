using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectLevelBtn : BaseButton
{
    public string sceneName;
    public override void LoadComponent()
    {
        
    }

    public override void OnClick()
    {
        SceneManager.LoadSceneAsync(sceneName);
    }
}
