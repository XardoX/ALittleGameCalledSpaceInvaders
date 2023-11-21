using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour
{
    [SerializeField]
    protected Bullet bullet;
    [SerializeField] private int bulletId = 1;

    [SerializeField]
    protected bool singleBulletMode = true;

    private void Awake()
    {
        bullet.transform.parent = null;
    }
    public virtual void Shoot(Vector3 direction)
    {
        Bullet bulletToShoot = bullet;

        if(singleBulletMode == false)
        {
            bulletToShoot = ObjectPooler.Instance.GetPooledObject(1).GetComponent<Bullet>();
        }

        if (!bulletToShoot.gameObject.activeInHierarchy)
        {
            bulletToShoot.transform.position = transform.position;
            bulletToShoot.gameObject.SetActive(true);
            bulletToShoot.Shoot(direction);
        }
        
    }

    protected virtual void OnDamage()
    {

    }

    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Bullet"))
        {
            collision.gameObject.SetActive(false);
            OnDamage();
        }
    }
}
