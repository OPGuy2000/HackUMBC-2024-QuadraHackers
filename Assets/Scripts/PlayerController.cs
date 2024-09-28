using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Movement")]
    public float playerSpeed = 1f;
    public float groundDrag;

    [Header("Ground Check")]
    public float playerHeight;
    public LayerMask ground;
    bool grounded;

    public Transform orientation;
    Vector3 moveDirection;
    Rigidbody rb;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }

    // Update is called once per frame
    void Update()
    {
        grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.2f, ground);
        
        float inputX = Input.GetAxis("HorizontalL");
        float inputY = Input.GetAxis("VerticalL");

        if (grounded) {
            rb.drag = groundDrag;
        } else {
            rb.drag = 0;
        }

        moveDirection = orientation.forward * inputY - orientation.right * inputX;
        rb.AddForce(moveDirection.normalized * playerSpeed, ForceMode.Force);
    }
}
