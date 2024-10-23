using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatBackground : MonoBehaviour
{

    void Update()
    {
        if (transform.position.x < -31)
        {
            transform.position = new Vector3(50.5f, 0, 0);
        }
    }
}
