using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    List<Enemy> enemies = new List<Enemy>();

    public Enemy enemyPrefab;
    [SerializeField] Transform playerPosition;

    public float EnemySpawnDistance = 0;
    public float EnemySpawnrate = 0;
    public float NextEnemySpawn = 0;

    public void EnemyUpdate()
    {
        if(NextEnemySpawn >= 0.5)
        {
            SpawnEnemyRandom();
            NextEnemySpawn = 0;
        }
        else
        {
            NextEnemySpawn += Time.deltaTime * EnemySpawnrate;
        }

        foreach (Enemy enemy in enemies)
        {
            enemy.UpdateEnemy();
        }
    }

    public void SpawnEnemyRandom()
    {
        Vector3 spawnPos = Random.insideUnitCircle.normalized;
        spawnPos *= EnemySpawnDistance;
        SpawnEnemy(playerPosition.position + spawnPos);
    }

    public void SpawnEnemy(Vector3 aPosition)
    {
        Enemy e = Instantiate(enemyPrefab, aPosition, Quaternion.identity);
        e.player = playerPosition;
        enemies.Add(e);
        e.OnKilled.AddListener(EnemyKilled);
    }

    public void EnemyKilled(Enemy anEnemy)
    {
        anEnemy.OnKilled.RemoveAllListeners();

        if(enemies.Contains(anEnemy))
        {
            enemies.Remove(anEnemy);
        }

        Destroy(anEnemy.gameObject);
    }
}
