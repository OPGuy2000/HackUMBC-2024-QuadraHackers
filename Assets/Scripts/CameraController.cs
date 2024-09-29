using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static PlayerController;

public class CameraController : MonoBehaviour
{
    public Transform player; 
    float cameraVerticalRotation = 0f; 
    public float cameraSpeed = 1f;

    public enum PlayerNumber
    {
        Player1,
        Player2,
        Player3,
        Player4
    }
    public PlayerNumber playerNumber;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        float inputX;
        float inputY;

       // Debug.Log(Input.GetAxis("VerticalR2"));

        switch (playerNumber)
        {
            case PlayerNumber.Player1:
                inputX = Input.GetAxis("HorizontalR");
                inputY = Input.GetAxis("VerticalR");
                break;
            case PlayerNumber.Player2:
                inputX = Input.GetAxis("HorizontalR2");
                inputY = Input.GetAxis("VerticalR2");
                break;
            case PlayerNumber.Player3:
                inputX = Input.GetAxis("HorizontalR3");
                inputY = Input.GetAxis("VerticalR3");
                break;
            case PlayerNumber.Player4:
                inputX = Input.GetAxis("HorizontalR4");
                inputY = Input.GetAxis("VerticalR4");
                break;
            default:
                inputX = 0;
                inputY = 0;
                break;
        }

        cameraVerticalRotation -= inputY;
        cameraVerticalRotation = Mathf.Clamp(cameraVerticalRotation, -90f, 90f);
        transform.localEulerAngles = Vector3.right*cameraVerticalRotation * cameraSpeed;

        player.Rotate(Vector3.up*inputX);

        transform.position = player.position;
    }

    
}
