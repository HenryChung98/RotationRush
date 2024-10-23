using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraHandlerSide : MonoBehaviour
{
    // camera position handling
    [SerializeField] private Camera mainCamera;
    private float cameraPosX = 0f;
    private float cameraPosY = 1.0f;
    private float cameraPosZ = -9.5f;
    [SerializeField] private float rotateSpeed = 3f;

    // when start zoom out camera
    private Vector3 startPos = new(-5.85f, -2.5f, -1.5f);
    private float duration = 0.5f;

    // check camera is flipped or rotated to set player's position
    public bool isCameraFlipped = false;
    public bool isCameraRotated = false;

    

    void Start()
    {
        Vector3 targetPos = new(cameraPosX, cameraPosY, cameraPosZ);
        StartCoroutine(ZoomOutAnimation(startPos, targetPos));
        mainCamera.transform.position = new Vector3(cameraPosX, cameraPosY, cameraPosZ);
    }
    void Update()
    {
        Camera.main.transform.position = new Vector3(cameraPosX, cameraPosY, cameraPosZ);

            // check if camera is flipped
            cameraPosZ = isCameraFlipped ? 9.5f : -9.5f;

            // check camera is rotated
            cameraPosY = isCameraRotated ? 4.0f : 1.0f;

        if (Input.GetKeyDown(KeyCode.Z))
        {
            HandleCameraFlip(180);
        }
        
    }
    public void HandleCameraRotateSide(float degree)
    {
        StartCoroutine(CameraRotateSide(degree));
        isCameraRotated = !isCameraRotated;
    }
    public void HandleCameraRotateTwiceSide(float degree)
    {
        StartCoroutine(CameraRotateSide(degree));
    }

    public void HandleCameraFlip(float degree)
    {
        StartCoroutine(CameraFlipSide(degree));
    }

    private IEnumerator ZoomOutAnimation(Vector3 startPos, Vector3 targetPos)
    {
        float elapsedTime = 0f;
        mainCamera.transform.position = startPos;
        while (elapsedTime < duration)
        {
            mainCamera.transform.position = Vector3.Lerp(startPos, targetPos, elapsedTime / duration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        mainCamera.transform.position = targetPos;
    }
    private IEnumerator CameraFlipSide(float targetAngle)
    {
        isCameraFlipped = !isCameraFlipped;

        Vector3 currentRotation = Camera.main.transform.rotation.eulerAngles;
        float startAngle = currentRotation.y;
        float endAngle = startAngle + targetAngle;
        float t = 0;

        while (t < 1f)
        {
            t += Time.deltaTime * rotateSpeed;
            float currentAngle = Mathf.Lerp(startAngle, endAngle, t);

            Camera.main.transform.rotation = Quaternion.Euler(currentRotation.x, currentAngle, currentRotation.z);
            yield return null;
        }

        Camera.main.transform.rotation = Quaternion.Euler(currentRotation.x, endAngle, currentRotation.z);
    }

    private IEnumerator CameraRotateSide(float targetAngle)
    {
        Vector3 currentRotation = Camera.main.transform.rotation.eulerAngles;
        float startAngle = currentRotation.z;
        float endAngle = startAngle + targetAngle;
        float t = 0;

        while (t < 1f)
        {
            t += Time.deltaTime * rotateSpeed;
            float currentAngle = Mathf.Lerp(startAngle, endAngle, t);

            Camera.main.transform.rotation = Quaternion.Euler(currentRotation.x, currentRotation.y, currentAngle);
            yield return null;
        }

        Camera.main.transform.rotation = Quaternion.Euler(currentRotation.x, currentRotation.y, endAngle);
    }

}
