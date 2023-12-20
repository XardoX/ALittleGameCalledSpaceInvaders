using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Ship, IDamagable
{
    [SerializeField]
    private PlayerData data;

    [SerializeField]
    private Vector2 bounds;

    private float inputX;

    private int currentHealth;

    private void Start()
    {
        currentHealth = data.Health;
    }

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

        transform.position += new Vector3(inputX * data.Speed * Time.deltaTime, 0f, 0f);

        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -bounds.x, bounds.x), transform.position.y); 
    }


    public void Damage()
    {
        Debug.Log("damage");
    }

    protected override void OnDamage()
    {
        SoundManager.PlayOnHit();
        currentHealth--;
        GameManager.instance.UIManager.SetEnergy(currentHealth);
        if(currentHealth <= 0)
        {
            GameManager.instance.ResetGame();
        }
    }
}
