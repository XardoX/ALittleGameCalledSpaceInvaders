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
            Shoot();
        }
    }

    public void Damage()
    {
    }
}
