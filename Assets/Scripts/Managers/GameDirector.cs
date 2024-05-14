using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDirector : MonoBehaviour
{
    public InputManager inputManager;

    public MainUI mainUI;

    public Transform enemy;
    public Player playerHolder;
    public Rigidbody playerRb;

    public Vector2 turn;

    public Bullet bulletPrefab;
    public Transform bulletSpawnPoint;

    public bool isGameStarted;

    // Start is called before the first frame update
    public void StartGame()
    {
        Cursor.lockState = CursorLockMode.Locked;
        isGameStarted = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (isGameStarted)
        {
            turn.x += Input.GetAxis("Mouse X");
            turn.y += Input.GetAxis("Mouse Y");
            playerHolder.RotatePlayer(turn);
        }        
    }

    //Methods
    public void SpawnBullet()
    {
        var newBullet = Instantiate(bulletPrefab);
        newBullet.transform.position = bulletSpawnPoint.position;
        newBullet.transform.LookAt(bulletSpawnPoint.position + bulletSpawnPoint.forward);
    }
}
