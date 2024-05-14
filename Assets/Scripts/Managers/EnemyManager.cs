using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public GameDirector gameDirector;
    public Enemy enemyPrefab;

    public int enemyCount;
    public void SpawnWave()
    {
        for (int i = 0; i < enemyCount; i++) 
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
        newEnemy.StartEnemy(gameDirector.playerHolder.transform);
    }
}
