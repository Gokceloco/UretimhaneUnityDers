using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDirector : MonoBehaviour
{
    public InputManager inputManager;
    public EnemyManager enemyManager;

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

    // Start is called before the first frame update
    public void StartGame()
    {
        Cursor.lockState = CursorLockMode.Locked;
        isGameStarted = true;
        enemyManager.SpawnWaveDelayed(5);
        ingameControlsLocked = false;
    }

    // Update is called once per frame
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

    //Methods
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
}
