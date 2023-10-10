using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour
{
    [SerializeField]
    protected Bullet bulletPrefab;

    protected virtual void Shoot(Vector3 direction)
    {
        var newBullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        newBullet.Shoot(direction);
    }

    protected virtual void OnDamage()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Bullet"))
        {
            Destroy(collision.gameObject);
            OnDamage();
        }
    }
}
