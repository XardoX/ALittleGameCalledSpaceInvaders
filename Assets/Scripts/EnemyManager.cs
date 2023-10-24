using System.Collections;
using System.Collections.Generic;
using System.Linq;
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

    private Vector2 globalOffset;

    [SerializeField]
    private Transform enemiesParent;

    [SerializeField]
    private List<List<Enemy>> enemies = new();


    private void Start()
    {
        SpawnEnemies();
        StartCoroutine(ControlEnemyShooting());
    }

    private void SpawnEnemies()
    {
        globalOffset = new Vector3(((-xOffset * columns) - yOffset)/2 , -yOffset * rows, 0f);
        Vector3 spawnPosition = globalOffset;

        for (int i = 0; i < columns; i++)
        {
            spawnPosition += new Vector3(xOffset, 0f, 0f);
            spawnPosition = new Vector3(spawnPosition.x, 0f, 0f);

            enemies.Add(new List<Enemy>());
            for(int j = 0; j < rows; j++)
            {
                var newEnemy = Instantiate(enemyPrefab, enemiesParent);
                spawnPosition -= new Vector3(0f, yOffset, 0f);
                newEnemy.transform.localPosition = spawnPosition;
                enemies[i].Add(newEnemy);
                newEnemy.OnDeath += OnEnemyDeath;
            }
        }
    }

    private void OnEnemyDeath(Enemy enemy)
    {
        enemies.ForEach(_ => _.Remove(enemy));
        GameManager.instance.AddScore(10);
    }

    IEnumerator ControlEnemyShooting()
    {
        while (true)
        {
            var enemiesOnfront = new List<Enemy>();

            foreach(var enemyList in enemies)
            {
                if (enemyList.Count == 0) continue;
                enemiesOnfront.Add(enemyList.Last());
            }
            var randomEnemy = enemiesOnfront[Random.Range(0, enemiesOnfront.Count)];
            randomEnemy.Shoot(Vector2.down);
            yield return new WaitForSeconds(1f);
            
        }
    }
}
