using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ShootBullet : MonoBehaviour
{
    public GameObject bullet;
    public Transform parent;
    public Transform posShoot;

    public void Shoot()
    {
        var _bullet=Instantiate(bullet,posShoot.position,Quaternion.identity) as GameObject;
        _bullet.GetComponent<BulletCtrl>().SetDirection(parent.right);
    }
}
