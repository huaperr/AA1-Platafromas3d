using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public Transform target;
    public float distance = 5f;
    public float height = 2f;
    public float mouseSensitivity = 2f;
    public LayerMask obstacleLayer;

    private float rotationX = 0f;
    private float rotationY = 0f;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void LateUpdate()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;

        rotationX += mouseX;
        rotationY -= mouseY;
        rotationY = Mathf.Clamp(rotationY, -90f, 90f);

        Vector3 desiredPosition = target.position - Quaternion.Euler(rotationY, rotationX, 0f) * Vector3.forward * distance + Vector3.up * height;

        RaycastHit hit;
        if (Physics.Raycast(target.position, desiredPosition - target.position, out hit, distance, obstacleLayer))
        {
            desiredPosition = hit.point;
        }

        transform.position = desiredPosition;

        transform.LookAt(target);
    }
}
