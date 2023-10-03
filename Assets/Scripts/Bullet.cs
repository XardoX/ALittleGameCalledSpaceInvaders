using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField]
    private float speed = 20f;

    [SerializeField]
    private Rigidbody2D rb;

    public void Shoot(Vector3 direction)
    {
        rb.velocity = direction * speed;
    }

   


}
