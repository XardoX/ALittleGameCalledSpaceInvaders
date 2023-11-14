using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using DG.Tweening;

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

    [Space]
    [Header("Enemy Movement")]
    [SerializeField]
    private float distance = 0.1f, 
        
        moveInterval = 0.1f,
        enemyMoveRange = 5f;

    [Space]
    [Header("Fluff")]
    [SerializeField]
    private Ease enemiesSpawnEase;

    [SerializeField]
    private float enemiesYStartPos = 14f, enemiesYTargetPos =5f;

    private int direciton = 1;

    private void Start()
    {
        SpawnEnemies();
        enemiesParent.position = new Vector3(enemiesParent.position.x, enemiesYStartPos, enemiesParent.position.z);
        StartCoroutine(StartEnemies());
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

    private IEnumerator StartEnemies()
    {
        yield return new WaitForSeconds(.5f);
        enemiesParent.DOMoveY(enemiesYTargetPos, 1f).SetEase(enemiesSpawnEase);
        yield return new WaitForSeconds(1f);
        StartCoroutine(ControlEnemyShooting());
        StartCoroutine(MoveEnemies());
    }

    private IEnumerator ControlEnemyShooting()
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

    private IEnumerator MoveEnemies()
    {
        while(true)
        {
            if(Mathf.Abs(enemiesParent.transform.position.x) >= enemyMoveRange)
            {
                direciton = direciton * -1;
            }
            for (var i = 0; i < rows; i++)
            {
                foreach (var column in enemies)
                {
                    for (var j = 0; j < column.Count; j++)
                    {
                        var newPosition = column[j].transform.position + (Vector3.right * distance) *direciton;
                        column[j].transform.position = newPosition;
                        yield return new WaitForSeconds(moveInterval/2);

                    }
                }
            }
            yield return new WaitForSeconds(moveInterval);
        }
    }

    private void OnEnemyDeath(Enemy enemy)
    {
        enemies.ForEach(_ => _.Remove(enemy));
        GameManager.instance.AddScore(10);
    }

}
