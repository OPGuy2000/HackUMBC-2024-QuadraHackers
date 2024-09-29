using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

public class PlayerController : MonoBehaviour
{
    [Header("Movement")]
    public float playerSpeed = 1f;
    public float groundDrag;
    public float airMultiplier;

    [Header("Ground Check")]
    public float playerHeight;
    public LayerMask ground;
    bool isGroundeded;
    public Transform orientation;
    Vector3 moveDirection;
    Rigidbody rb;

    public float jumpCooldown;
    public float jumpForce = 1f;
    bool readyToJump = true;

    //Jumping
    PlayerControl playerControl;

    void Awake() {
        playerControl = new PlayerControl();
    }
    
    private void OnDisable() {
        playerControl.Disable();
    }

    private void OnEnable() {
        playerControl.Enable();
    } 

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }

    // Update is called once per frame
    void Update()
    {
        isGroundeded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.2f, ground);
        
        float inputX = Input.GetAxis("HorizontalL");
        float inputY = Input.GetAxis("VerticalL");

        SpeedControl();

        if (isGroundeded) 
            rb.drag = groundDrag;
         else 
            rb.drag = 0;
        

        moveDirection = orientation.forward * inputY - orientation.right * inputX;
        
        if (isGroundeded) 
            rb.AddForce(moveDirection.normalized * playerSpeed, ForceMode.Force);
        else 
            rb.AddForce(moveDirection.normalized * playerSpeed * airMultiplier, ForceMode.Force);


        bool jumpPressed = playerControl.Player.Jump.ReadValue<float>() > 0.5;
        if (isGroundeded && jumpPressed && readyToJump) {
            Jump();
            Invoke(nameof(ReadyToJump), jumpCooldown);
        }
    }
 
    private void SpeedControl() {
        Vector3 flatVel = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        if (flatVel.magnitude > playerSpeed) {
            Vector3 limitedVel = flatVel.normalized * playerSpeed;
             rb.velocity = new Vector3(limitedVel.x, rb.velocity.y, limitedVel.z);
        }
    }
        
    void Jump() {
        rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        readyToJump = false;
    }

    void ReadyToJump() {
        readyToJump = true;
    }
}
