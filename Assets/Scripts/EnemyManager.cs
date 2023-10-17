using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [SerializeField]
    private Enemy enemyPrefab;

    [SerializeField]
    private int columns,
         rows;

    [SerializeField]
    private float xOffset, yOffset;

    [SerializeField]
    private Transform enemiesParent;

    [SerializeField]
    private List<List<Enemy>> enemies;


    private void Start()
    {
        SpawnEnemies();
    }

    private void SpawnEnemies()
    {
        var startPosition = Vector3.zero;
        for (int i = 0; i < columns; i++)
        {
            for(int j = 0; j < rows; j++)
            {
                var newEnemy = Instantiate(enemyPrefab, enemiesParent);
            }
        }
    }
}
