using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerControllerSide : PlayerController
{
    // declare references to external components
    private CameraHandlerSide cameraHandlerSide;

    // to set position depending on the camera
    private float playerPosX;
    private float playerPosZ;

    void Start()
    {
        playerAnim = GetComponent<Animator>();
        playerRb = GetComponent<Rigidbody>();
        playerPosX = -6.0f;
        playerPosZ = -1.0f;
        cameraHandlerSide = GameObject.Find("CameraHandler").GetComponent<CameraHandlerSide>();
        gameManger = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    void Update()
    {
        // jump
        if (Input.GetKeyDown(KeyCode.UpArrow) && isOnGround && !gameOver)
        {
            Jump();
        }
        // ground pound
        if (Input.GetKeyDown(KeyCode.DownArrow)){
            GroundPound();
        }

        transform.position = new Vector3(playerPosX, transform.position.y, playerPosZ);

        playerPosX = cameraHandlerSide.isCameraRotated ? -4.0f : -6.0f;
        playerPosZ = cameraHandlerSide.isCameraFlipped ? 1.0f : -1.0f;

        if (cameraHandlerSide.isCameraRotated == true)
        {
            transform.position = new Vector3(-4, transform.position.y, transform.position.z);
        }
        
        
    }
}
