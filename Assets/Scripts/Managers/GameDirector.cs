using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDirector : MonoBehaviour
{
    public Transform enemy;
    public Transform player;
    public Rigidbody playerRb;

    public float enemySpeed;
    public float playerSpeed;
    public float jumpForce;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (enemy.position.z > 2)
        {
            MoveEnemy();
        }
        if (Input.GetKey(KeyCode.S))
        {
            MovePlayer(new Vector3(0, 0, -1));
        }
        if (Input.GetKey(KeyCode.W))
        {
            MovePlayer(new Vector3(0, 0, 1));
        }
        if (Input.GetKey(KeyCode.A))
        {
            MovePlayer(new Vector3(-1, 0, 0));
        }
        if (Input.GetKey(KeyCode.D))
        {
            MovePlayer(new Vector3(1,0,0));
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            MakePlayerJump();
        }
    }
    //Methods
    void MoveEnemy()
    {
        enemy.position = enemy.position + new Vector3(0, 0, 1) * enemySpeed;
    }
    void MovePlayer(Vector3 direction)
    {
        player.position = player.position + direction * playerSpeed;
    }

    void MakePlayerJump()
    {
        playerRb.AddForce(new Vector3(0,1,0) * jumpForce);
    }
}
