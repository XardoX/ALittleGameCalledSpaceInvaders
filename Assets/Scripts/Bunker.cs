using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        Color spriteColor = spriteRenderer.color;
        Debug.Log((float)currentHealth / (float)health);
        spriteColor.a = (currentHealth / health) * 255f;
        spriteRenderer.color = spriteColor;
        if(currentHealth <=0 )
        {
            OnDeath?.Invoke();
            Destroy(gameObject);
        }
    }
}
