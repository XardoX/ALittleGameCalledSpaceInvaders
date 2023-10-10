using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.InteropServices;
using UnityEngine;

public class Player : Ship, IDamagable
{
    [SerializeField]
    private float speed = 10f;

    [SerializeField]
    private Vector2 bounds;

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

        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -bounds.x, bounds.x), transform.position.y); 
    }

    private void Shoot()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            var newBullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
            newBullet.Shoot(Vector3.up);
        }
    }

    public void Damage()
    {
        Debug.Log("damage");
    }
}
