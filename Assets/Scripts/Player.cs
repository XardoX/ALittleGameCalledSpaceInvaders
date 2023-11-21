using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.InteropServices;
using UnityEngine;

public class Player : Ship, IDamagable
{
    [SerializeField]
    private int health = 3;

    [SerializeField]
    private float speed = 10f;

    [SerializeField]
    private Vector2 bounds;

    private float inputX;

    public void ToggleGodMode(bool toggle)
    {
        singleBulletMode = !toggle;
    }
    // Update is called once per frame
    void Update()
    {
        Move();
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot(Vector3.up);
        }

    }

    private void Move()
    {
        inputX = Input.GetAxis("Horizontal");

        transform.position += new Vector3(inputX * speed * Time.deltaTime, 0f, 0f);

        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -bounds.x, bounds.x), transform.position.y); 
    }


    public void Damage()
    {
        Debug.Log("damage");
    }

    protected override void OnDamage()
    {
        health--;
        GameManager.instance.UIManager.SetEnergy(health);
        if(health <=0)
        {
            GameManager.instance.ResetGame();
        }
    }
}
