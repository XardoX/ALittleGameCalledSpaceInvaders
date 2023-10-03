using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private Bullet bulletPrefab;


    private void Start()
    {
        StartCoroutine(ConstantShoot());
    }
    IEnumerator ConstantShoot()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);
            Shoot();
        }
    }
    private void Shoot()
    {
        var newBullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        newBullet.Shoot(Vector3.down);
    }
}
