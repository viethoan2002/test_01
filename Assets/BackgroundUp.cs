using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundUp : MonoBehaviour
{
    private void Update()
    {
        transform.Translate(Vector2.up*2*Time.deltaTime);
    }
}
