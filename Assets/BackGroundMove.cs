using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundMove : MonoBehaviour
{
    public float loopSpeed;
    public Renderer bacgroundRenderer;

    private void Update()
    {
        bacgroundRenderer.material.mainTextureOffset += new Vector2(0,-loopSpeed * Time.deltaTime);
    }
}
