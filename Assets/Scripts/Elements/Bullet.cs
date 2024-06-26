using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float bulletSpeed;
    public float bulletTime;

    private float _bulletStartTime;

    private void Start()
    {
        _bulletStartTime = Time.time;
    }

    private void Update()
    {
        Move();
        if (Time.time - _bulletStartTime > bulletTime)
        {
            gameObject.SetActive(false);
        }
    }

    void Move()
    {
        transform.position += transform.forward * bulletSpeed * Time.deltaTime;
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
