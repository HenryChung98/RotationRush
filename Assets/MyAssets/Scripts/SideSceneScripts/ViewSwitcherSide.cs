using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ViewSwitcherSide : MonoBehaviour
{
    [SerializeField] private enum Direction { clockWiseSide, counterClockWiseSide, clockWiseTwiceSide, flipCamera, SceneSwitch }
    [SerializeField] private Direction switchTo;
    private CameraHandlerSide cameraHandlerSide;

    void Start()
    {
        cameraHandlerSide = GameObject.Find("CameraHandler").GetComponent<CameraHandlerSide>();
    }
    private void SetDirectionSide(Direction direction)
    {

        switch (direction)
        {
            case Direction.clockWiseSide:
                cameraHandlerSide.HandleCameraRotateSide(-90);
                break;
            case Direction.counterClockWiseSide:
                cameraHandlerSide.HandleCameraRotateSide(90);
                break;
            case Direction.clockWiseTwiceSide:
                cameraHandlerSide.HandleCameraRotateTwiceSide(180);
                break;
            case Direction.flipCamera:
                cameraHandlerSide.HandleCameraFlip(180);
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
            SetDirectionSide(switchTo);

        }
    }
}
