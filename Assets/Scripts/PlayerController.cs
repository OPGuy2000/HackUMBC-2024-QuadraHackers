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

    public enum PlayerNumber
    {
        Player1,
        Player2,
        Player3,
        Player4
    }
    public PlayerNumber playerNumber;

    //Jumping
    //PlayerControl playerControl;

    void Awake() {
        //playerControl = new PlayerControl();
    }
    
    private void OnDisable() {
        //playerControl.Disable();
    }

    private void OnEnable() {
        //playerControl.Enable();
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

        float inputX = 0;
        float inputY = 0;
        bool inputJump = false;

        string h = "";
        foreach (string s in Input.GetJoystickNames())
            h += s + ", ";

        //Debug.Log(Input.GetAxis("HorizontalL4") + ", " + Input.GetAxis("VerticalL4"));

        switch (playerNumber)
        {
            case PlayerNumber.Player1:
                inputX = Input.GetAxis("HorizontalL");
                inputY= Input.GetAxis("VerticalL");
                inputJump = Input.GetButtonDown("Jump1");
                break;
            case PlayerNumber.Player2:
                inputX = Input.GetAxis("HorizontalL2");
                inputY = Input.GetAxis("VerticalL2");
                inputJump = Input.GetButtonDown("Jump2");
                break;
            case PlayerNumber.Player3:
                inputX = Input.GetAxis("HorizontalL3");
                inputY = Input.GetAxis("VerticalL3");
                inputJump = Input.GetButtonDown("Jump3");
                break;
            case PlayerNumber.Player4:
                inputX = Input.GetAxis("HorizontalL4");
                inputY = Input.GetAxis("VerticalL4");
                inputJump = Input.GetButtonDown("Jump4");
                break;
            default:
                inputX = 0;
                inputY = 0;
                inputJump = false;
                break;
        }

        //Debug.Log(playerNumber + " " + inputJump);
        

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


        if (isGroundeded && inputJump) {
           Jump();
           Invoke(nameof(ReadyToJump), jumpCooldown);
        }

        float reloadInput;
        switch (playerNumber)
        {
            case PlayerNumber.Player1:
                reloadInput = Input.GetAxis("Reload1");
                break;
            case PlayerNumber.Player2:
                reloadInput = Input.GetAxis("Reload2");
                break;
            case PlayerNumber.Player3:
                reloadInput = Input.GetAxis("Reload3");
                break;
            case PlayerNumber.Player4:
                reloadInput = Input.GetAxis("Reload4");
                break;
            default:
                reloadInput = 0;
                break;
        }

        
        if (transform.GetChild(0).GetChild(1) && reloadInput > 0)
        {
            transform.GetChild(0).GetChild(1).GetComponent<Gun>().ExReload();
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
