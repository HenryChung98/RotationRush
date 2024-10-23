using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetVectorZ : MonoBehaviour
{
    private CameraHandlerSide cameraHandlerSide;
    [SerializeField] private bool isDragon;
    void Start()
    {
        cameraHandlerSide = GameObject.Find("CameraHandler").GetComponent<CameraHandlerSide>();
    }

    void Update()
    {
        if (isDragon)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, cameraHandlerSide.isCameraFlipped ? -2.0f : -4.0f);
        }
        else{
            transform.position = new Vector3(transform.position.x, transform.position.y, cameraHandlerSide.isCameraFlipped ? 1.0f : -1.0f);
        }
    }
}
