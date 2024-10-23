using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerBehind : PlayerController
{
    [SerializeField] private float moveSpeed = 5.0f;
    private float horizontalInput;
    private const float zRange = 1.5f;

    void Start()
    {
        playerAnim = GetComponent<Animator>();
        playerRb = GetComponent<Rigidbody>();
        gameManger = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow) && isOnGround && !gameOver)
        {
            Jump();
        }

        // ground pound
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            GroundPound();
        }

        if (transform.position.z < -zRange)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -zRange);
        }

        if (transform.position.z > zRange)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, zRange);
        }
        horizontalInput = Input.GetAxis("Horizontal");

        if (!gameOver)
        {
            transform.Translate(Vector3.right * Time.deltaTime * moveSpeed * horizontalInput);
        }
    }
}
