using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : Ship, IDamagable
{
    public Action<Enemy> OnDeath;
    private void Start()
    {
    }

    protected override void OnDamage()
    {
        OnDeath?.Invoke(this);
        Destroy(gameObject);
    }

    public void Damage()
    {
    }
}
