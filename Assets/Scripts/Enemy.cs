using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : Ship, IDamagable
{
    private void Start()
    {
        StartCoroutine(ConstantShoot());
    }
    IEnumerator ConstantShoot()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);
            Shoot(Vector3.down);
        }
    }

    protected override void OnDamage()
    {

    }

    public void Damage()
    {
    }
}
