using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InputManager : MonoBehaviour
{
    public GameDirector gameDirector;
    public Transform playerMesh;

    public float mouseSensitivity;

    // Update is called once per frame
    void Update()
    {
        if(!gameDirector.ingameControlsLocked)
        {
            if (Input.GetKey(KeyCode.S))
            {
                var direction = -playerMesh.forward;
                direction.y = 0;
                gameDirector.playerHolder.MovePlayer(direction);
            }
            if (Input.GetKey(KeyCode.W))
            {
                var direction = playerMesh.forward;
                direction.y = 0;
                gameDirector.playerHolder.MovePlayer(direction);
            }
            if (Input.GetKey(KeyCode.A))
            {
                var direction = -playerMesh.right;
                direction.y = 0;
                gameDirector.playerHolder.MovePlayer(direction);
            }
            if (Input.GetKey(KeyCode.D))
            {
                var direction = playerMesh.right;
                direction.y = 0;
                gameDirector.playerHolder.MovePlayer(direction);
            }
            if (Input.GetKeyDown(KeyCode.Space))
            {
                gameDirector.playerHolder.MakePlayerJump();
            }
            if (Input.GetMouseButtonDown(0))
            {
                gameDirector.SpawnBullets();
            }
            if (Input.GetKeyDown(KeyCode.F1))
            {
                gameDirector.mainUI.Show();
                Cursor.lockState = CursorLockMode.None;
            }
            if (Input.GetKeyDown(KeyCode.F5))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
            if (Input.GetKeyDown(KeyCode.P))
            {
                gameDirector.enemyManager.SpawnWave();
            }
        }        
    }
}
