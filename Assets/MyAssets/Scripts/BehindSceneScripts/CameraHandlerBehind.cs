using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraHandlerBehind : MonoBehaviour
{
    // camera position handling
    [SerializeField] private Camera mainCamera;
    private float cameraPosX = -10.0f;
    private float cameraPosY = 0f;
    private float cameraPosZ = 0f;
    [SerializeField] private float rotateSpeed = 3f;

    // when start zoom out camera
    private Vector3 startPos = new(-6.3f, -3f, 0f);
    private float duration = 0.5f;

    void Start()
    {
        mainCamera.transform.position = new Vector3(cameraPosX, cameraPosY, cameraPosZ);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 targetPos = new(cameraPosX, cameraPosY, cameraPosZ);
        StartCoroutine(ZoomOutAnimation(startPos, targetPos));
        Camera.main.transform.position = new Vector3(cameraPosX, cameraPosY, cameraPosZ);
    }
    public void HandleCameraRotateBehind(float degree)
    {
        StartCoroutine(CameraRotateBehind(degree));
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
    private IEnumerator CameraRotateBehind(float targetAngle)
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
