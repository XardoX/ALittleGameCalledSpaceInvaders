using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : Ship, IDamagable
{
    public Action OnWallHit;
    public Action<Enemy> OnDeath;

    [SerializeField]
    private ParticleSystem deathParticle;
    private void Start()
    {
    }

    protected override void OnDamage()
    {
        OnDeath?.Invoke(this);
        var deathParticle = ObjectPooler.Instance.GetPooledObject(0).GetComponent<ParticleSystem>();
        deathParticle.gameObject.SetActive(true);
        deathParticle.transform.position = transform.position;
        deathParticle.Play();
        Destroy(gameObject);
    }

    public void Damage()
    {
    }

    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        base.OnTriggerEnter2D(collision);
        if(collision.gameObject.CompareTag("Wall"))
        {
            OnWallHit?.Invoke();
        }
    }

}
