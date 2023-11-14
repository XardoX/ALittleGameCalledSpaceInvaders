using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour
{
    [SerializeField]
    protected Bullet bullet;
    [SerializeField] private int bulletId = 1;

    private void Awake()
    {
        bullet.transform.parent = null;
    }
    public virtual void Shoot(Vector3 direction)
    {
        if (!bullet.gameObject.activeInHierarchy)
        {
            bullet.transform.position = transform.position;
            bullet.gameObject.SetActive(true);
            bullet.Shoot(direction);
        }
        
    }

    protected virtual void OnDamage()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Bullet"))
        {
            collision.gameObject.SetActive(false);
            OnDamage();
        }
    }
}
