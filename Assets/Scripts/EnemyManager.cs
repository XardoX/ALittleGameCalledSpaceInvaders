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
    private List<List<Enemy>> enemies = new();


    private void Start()
    {
        SpawnEnemies();
    }

    private void SpawnEnemies()
    {
        var spawnPosition = Vector3.zero;
        for (int i = 0; i < columns; i++)
        {
            spawnPosition += new Vector3(xOffset, 0f, 0f);
            spawnPosition = new Vector3(spawnPosition.x, 0f, 0f);

            enemies.Add(new List<Enemy>());
            for(int j = 0; j < rows; j++)
            {
                var newEnemy = Instantiate(enemyPrefab, enemiesParent);
                spawnPosition -= new Vector3(0f, yOffset, 0f);
                newEnemy.transform.position = spawnPosition;
                enemies[i].Add(newEnemy);
            }
        }
    }
}
