using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDirector : MonoBehaviour
{
    public InputManager inputManager;
    public EnemyManager enemyManager;
    public DiamondManager diamondManager;

    public MainUI mainUI;
    public WinUI winUI;

    public Transform enemy;
    public Player playerHolder;
    public Rigidbody playerRb;

    public Vector2 turn;

    public Bullet bulletPrefab;
    public Transform bulletSpawnPoint;

    public bool isGameStarted;

    public int bulletCount;

    public float maxSpread;

    public bool ingameControlsLocked;

    private void Start()
    {
        ingameControlsLocked = true;
        mainUI.Show();
        winUI.Hide();
    }

    public void StartGame()
    {
        Cursor.lockState = CursorLockMode.Locked;
        isGameStarted = true;
        enemyManager.SpawnWave();
        ingameControlsLocked = false;
    }
    void Update()
    {
        if (isGameStarted && !ingameControlsLocked)
        {
            turn.x += Input.GetAxis("Mouse X");
            turn.y += Input.GetAxis("Mouse Y");
            playerHolder.RotatePlayer(turn);            
        }        
    }

    public void SpawnBullets()
    {
        for (int i = 0;
            i < bulletCount;
            i++)
        {
            SpawnBullet();
        }
    }

    public void SpawnBullet()
    {
        var spread = new Vector3(Random.Range(-maxSpread,maxSpread),
            0,
            Random.Range(-maxSpread, maxSpread));

        var newBullet = Instantiate(bulletPrefab);
        newBullet.transform.position = bulletSpawnPoint.position;
        newBullet.transform.LookAt(bulletSpawnPoint.position + bulletSpawnPoint.forward + spread);
    }
    public void LevelCompleted()
    {
        ingameControlsLocked = true;
        Cursor.lockState = CursorLockMode.None;
        winUI.Show();
    }

    public void DiamondCollected()
    {
        LevelCompleted();        
    }
}
