using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float bulletSpeed;

    private void Update()
    {
        Move();
    }

    void Move()
    {
        transform.position += transform.forward * bulletSpeed;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy")) 
        {
            other.GetComponent<Enemy>().EnemyGotHit();
            gameObject.SetActive(false);
        }
        else if (other.CompareTag("MapObjects"))
        {
            gameObject.SetActive(false);
        }
    }
}
