using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField]
    private float speed = 20f;

    [SerializeField]
    private Rigidbody2D rb;


    private void FixedUpdate()
    {
        rb.velocity = new Vector3(0f, speed, 0f);
    }
}
