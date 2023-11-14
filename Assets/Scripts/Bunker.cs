using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class Bunker : Ship
{
    [SerializeField]
    private SpriteRenderer spriteRenderer;

    [SerializeField]
    private int health = 3;

    private int currentHealth;

    public Action OnDeath;

    private void Awake()
    {
        currentHealth = health;
    }

    protected override void OnDamage()
    {
        currentHealth--;
        spriteRenderer.DOFade((float) currentHealth / (float)health, 0.10f);
        if(currentHealth <=0 )
        {
            OnDeath?.Invoke();
            Destroy(gameObject);
        }
    }
}
