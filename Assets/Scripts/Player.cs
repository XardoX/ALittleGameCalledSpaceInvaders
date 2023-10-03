using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.InteropServices;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float speed = 10f;

    [SerializeField]
    private Bullet bulletPrefab;

    private float inputX;

    // Update is called once per frame
    void Update()
    {
        Move();
        Shoot();
    }

    private void Move()
    {
        inputX = Input.GetAxis("Horizontal");

        transform.position += new Vector3(inputX * speed * Time.deltaTime, 0f, 0f);
    }

    private void Shoot()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            var newBullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        }
    }
}
