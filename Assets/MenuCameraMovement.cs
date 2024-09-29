using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuCameraMovement : MonoBehaviour
{
    public float mainCameraSpeed;

    void Update()
    {
        transform.Rotate(0, mainCameraSpeed * Time.deltaTime, 0);
    }
}


