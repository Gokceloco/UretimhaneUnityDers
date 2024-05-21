using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public GameDirector gameDirector;
    public Enemy enemyPrefab;

    public int enemyCount;

    public List<Enemy> activeEnemies = new List<Enemy>();

    public int waveCount;

    private void Start()
    {
        waveCount = 0;
    }

    public void SpawnWaveDelayed(float delay)
    {
        Invoke(nameof(SpawnWave), delay);
    }

    public void SpawnWave()
    {
        waveCount += 1;
        for (int i = 0; i < enemyCount * waveCount; i++) 
        {
            SpawnEnemy(i);
        }        
    }
    public void SpawnEnemy(int i)
    {
        var newEnemy = Instantiate(enemyPrefab);
        var circleOffset = Random.onUnitSphere;
        Vector3 offset = new Vector3(circleOffset.x, 0, circleOffset.y);
        newEnemy.transform.position = gameDirector.playerHolder.transform.position + offset * 20;
        newEnemy.StartEnemy(gameDirector.playerHolder.transform, this);
        activeEnemies.Add(newEnemy);
    }

    public void EnemyDied(Enemy e)
    {
        activeEnemies.Remove(e);
        if (activeEnemies.Count == 0)
        {
            if (waveCount < 3)
            {
                SpawnWave();
            }
            else
            {
                gameDirector.LevelCompleted();
            }
        }
    }
}
