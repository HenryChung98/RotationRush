using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VIewSwitcherBehind : MonoBehaviour
{
    [SerializeField] private enum Direction { clockWiseBehind, counterClockWiseBehind, clockWiseTwiceBehind, SceneSwitch };
    [SerializeField] private Direction switchTo;
    private CameraHandlerBehind cameraHandlerBehind;

    void Start()
    {
        cameraHandlerBehind = GameObject.Find("CameraHandler").GetComponent<CameraHandlerBehind>();
    }
    private void SetDirectionBehind(Direction direction)
    {

        switch (direction)
        {
            case Direction.clockWiseBehind:
                cameraHandlerBehind.HandleCameraRotateBehind(-90);
                break;
            case Direction.counterClockWiseBehind:
                cameraHandlerBehind.HandleCameraRotateBehind(90);
                break;
            case Direction.clockWiseTwiceBehind:
                cameraHandlerBehind.HandleCameraRotateBehind(180);
                break;
            case Direction.SceneSwitch:
                if (SceneManager.GetActiveScene().name == "SideScene")
                    SceneManager.LoadScene("BehindScene");
                else if (SceneManager.GetActiveScene().name == "BehindScene")
                    SceneManager.LoadScene("SideScene");
                break;

        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            SetDirectionBehind(switchTo);
        }
    }
}
