using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform player;
    public float minX;
    public float maxX;

    private void Update()
    {
        if(player.position.x > minX && player.position.x < maxX)
        {
            transform.position = new Vector3(player.position.x, transform.position.y, transform.position.z);
        }      
    }
}
