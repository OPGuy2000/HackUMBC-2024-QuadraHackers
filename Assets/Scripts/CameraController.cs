using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform player; 
    float cameraVerticalRotation = 0f; 

    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        float inputX = Input.GetAxis("HorizontalR");
        float inputY = Input.GetAxis("VerticalR");

        cameraVerticalRotation -= inputY;
        cameraVerticalRotation = Mathf.Clamp(cameraVerticalRotation, -90f, 90f);
        transform.localEulerAngles = Vector3.right*cameraVerticalRotation;

        player.Rotate(Vector3.up*inputX);

        transform.position = player.position;
    }
}
