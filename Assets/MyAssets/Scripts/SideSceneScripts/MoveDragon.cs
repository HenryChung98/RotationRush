using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveDragon : MonoBehaviour
{
    public bool isDragonActivate = false;
    
    private Vector3 targetPos = new(0, 2, -4);

    [SerializeField] private bool isSideView;
    [SerializeField] private float startX;
    [SerializeField] private float startY;
    [SerializeField] private float startZ;
    private float endY = 4f;
    private float endX = -5.5f;
    private float duration = 3f;    
    private float timer = 0f;

    void Start()
    {
        transform.position = new Vector3(startX, startY, startZ); 
    }
    void Update()
    {
        if (isDragonActivate)
        {
            timer += Time.deltaTime;
            float t = Mathf.PingPong(timer / duration, 1);
            if (isSideView)
            {
                float newY = Mathf.Lerp(startY, endY, t);
                transform.position = new Vector3(transform.position.x, newY, transform.position.z);
            }
            else
            {
                float newX = Mathf.Lerp(startX, endX, t);
                transform.position = new Vector3(newX, transform.position.y, transform.position.z);
            }
        }
        if (timer * 0.5 >= duration)
        {
            isDragonActivate = false;
            timer = 0f; 
        }
    }
}