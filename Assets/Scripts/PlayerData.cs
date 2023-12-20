using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerData", menuName = "Data/Player Data")]
public class PlayerData : ScriptableObject
{
    [SerializeField]
    private int health = 3;

    [SerializeField]
    private float speed = 10f;

    public int Health { 
        get 
        {
            Debug.Log("Health");
            return health; 
        } 
        private set => health = value; 
    }
    public float Speed => speed; 
}
