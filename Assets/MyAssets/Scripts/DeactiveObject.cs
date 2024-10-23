using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class DeactiveObject : MonoBehaviour
{
    private GameManager gameManager;
    [SerializeField] private int score = 5;
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }
    void Update()
    {
        if (transform.position.x < -10.0f)
        {
            gameObject.SetActive(false);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (gameObject.CompareTag("Switcher"))
            {
                gameManager.AddScore(score);
                gameObject.SetActive(false);
            }
        }
    }
}
