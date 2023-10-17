using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bunker : Ship
{
    [SerializeField]
    private int health = 3;

    public Action OnDeath;
    protected override void OnDamage()
    {
        health--;
        if(health <=0 )
        {
            OnDeath?.Invoke();
            Destroy(gameObject);
        }
    }
}
