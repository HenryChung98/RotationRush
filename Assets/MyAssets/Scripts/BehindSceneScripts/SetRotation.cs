using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetRotation : MonoBehaviour
{
    [SerializeField] private float rotX;
    [SerializeField] private float rotY;
    [SerializeField] private float rotZ;

    void Start()
    {
        gameObject.transform.rotation = Quaternion.Euler(rotX, rotY, rotZ);
    }

    
    void Update()
    {
        
    }
}
