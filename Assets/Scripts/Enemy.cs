using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : Ship, IDamagable
{
    public Action<Enemy> OnDeath;

    [SerializeField]
    private ParticleSystem deathParticle;
    private void Start()
    {
    }

    protected override void OnDamage()
    {
        OnDeath?.Invoke(this);
        deathParticle.transform.parent = null;
        deathParticle.Play();
        Destroy(gameObject);
    }

    public void Damage()
    {
    }

}
