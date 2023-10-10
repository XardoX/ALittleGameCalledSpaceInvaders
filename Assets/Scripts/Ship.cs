using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour
{

    [SerializeField]
    protected Bullet bulletPrefab;
    protected void Shoot()
    {
        var newBullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        newBullet.Shoot(Vector3.down);
    }
}
