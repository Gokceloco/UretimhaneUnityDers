using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public EnemyManager enemyManager;
    public Transform playerTransform;

    public float enemySpeed;

    public void StartEnemy(Transform pTransform, EnemyManager eManager)
    {
        playerTransform = pTransform;
        enemyManager = eManager;
    }

    // Update is called once per frame
    void Update()
    {
        var direction = playerTransform.position - transform.position;
        var directionNormalized = direction.normalized;
        transform.position += directionNormalized * enemySpeed;
    }

    public void EnemyGotHit()
    {
        gameObject.SetActive(false);
        enemyManager.EnemyDied(this);
    }
}
