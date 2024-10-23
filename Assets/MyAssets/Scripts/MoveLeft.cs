using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveLeft : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5.0f;
    [SerializeField] private float posY;
    [SerializeField] private float posZ;
    private GameManager gameManger;
    private SpawnManager spawnManager;

    void Start()
    {
        // if either of these are not set, no need to set start position
        if (posY != 0 || posZ != 0)
        {
            transform.position = new Vector3 (transform.position.x, posY, posZ);
        }
        gameManger = GameObject.Find("GameManager").GetComponent<GameManager>();
        spawnManager = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
    }
    void Update()
    {
        //if (spawnManager.spawnedNum % 3 == 0)
        //{
        //    moveSpeed += 0.5f;
        //    spawnManager.spawnedNum = 0;
        //    Debug.Log("speed up: " + moveSpeed);
        //}
        if (gameManger.setGameOver == false)
        {
            transform.position += Vector3.left * moveSpeed * Time.deltaTime;
        }  
    }
}
