using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Transform playerTransform;

    public float enemySpeed;

    // Update is called once per frame
    void Update()
    {
        var direction = playerTransform.position - transform.position;
        var directionNormalized = direction.normalized;
        transform.position += directionNormalized * enemySpeed;
    }
}
