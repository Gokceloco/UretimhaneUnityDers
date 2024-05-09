using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDirector : MonoBehaviour
{
    public Transform enemy;
    public Transform player;
    public Transform playerHolder;
    public Rigidbody playerRb;

    public float enemySpeed;
    public float playerSpeed;
    public float jumpForce;

    public Vector2 turn;

    public float mouseSensitivity;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
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
            var direction = -player.forward;
            direction.y = 0;
            MovePlayer(direction);
        }
        if (Input.GetKey(KeyCode.W))
        {
            var direction = player.forward;
            direction.y = 0;
            MovePlayer(direction);
        }
        if (Input.GetKey(KeyCode.A))
        {
            var direction = -player.right;
            direction.y = 0;
            MovePlayer(direction);
        }
        if (Input.GetKey(KeyCode.D))
        {
            var direction = player.right;
            direction.y = 0;
            MovePlayer(direction);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            MakePlayerJump();
        }
        turn.x += Input.GetAxis("Mouse X");
        turn.y += Input.GetAxis("Mouse Y");
        RotatePlayer();
    }
    //Methods
    void MoveEnemy()
    {
        enemy.position = enemy.position + new Vector3(0, 0, 1) * enemySpeed;
    }
    void MovePlayer(Vector3 direction)
    {
        playerHolder.position = playerHolder.position + direction * playerSpeed;
    }
    void MakePlayerJump()
    {
        playerRb.AddForce(new Vector3(0,1,0) * jumpForce);
    }

    void RotatePlayer()
    {
        player.localRotation = Quaternion.Euler(-turn.y * mouseSensitivity, turn.x * mouseSensitivity, 0);
    }
}
