using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameDirector gameDirector;

    public float playerSpeed;
    public float jumpForce;
    public Rigidbody playerRb;
    public Transform playerMesh;

    public void MovePlayer(Vector3 direction)
    {
        transform.position += direction * playerSpeed * Time.deltaTime;
    }
    public void MakePlayerJump()
    {
        playerRb.AddForce(new Vector3(0, 1, 0) * jumpForce);
    }

    public void RotatePlayer(Vector2 turn)
    {
        var mouseSensitivity = gameDirector.inputManager.mouseSensitivity;
        playerMesh.localRotation = Quaternion.Euler(-turn.y * mouseSensitivity, turn.x * mouseSensitivity, 0);
    }
}
