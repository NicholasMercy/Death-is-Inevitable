using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerStates
{
    walkState, runState, jumpState
}

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    public float intialSpeed;
    public float moveSpeed;
    public float doubleSpeed;
    public float groundDrag; 

    public float jumpForce;
    public float jumpCooldown;
    public float airMultiplier;
    bool readyToJump;
    [Header("Keybinds")]
    public KeyCode jumpKey = KeyCode.Space;
    public KeyCode speedKey = KeyCode.LeftShift;


    [Header("Ground Check")]
    public float playerHeight;
    public LayerMask whatIsGround;
    bool grounded;

    public Transform orientation;

    float horizontalInput;
    float verticalInput;

    Vector3 moveDirection;

    [Header("PlayerStates")]
    public PlayerStates playerState;

    [Header("CanvasPlaying")]
    CanvasType playingCanvas; 
    AudioManager audioManager;
    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {     
        playingCanvas = GameObject.FindGameObjectWithTag("Playing").GetComponent<CanvasType>();
        audioManager = GameObject.Find("AudioManager").GetComponent<AudioManager>();
        readyToJump = true;
        rb = GetComponent<Rigidbody>(); 
        rb.freezeRotation = true;   
    }
    private void FixedUpdate()
    {
        if (GameManager.Instance.gameState == GameStates.playing)
            MovePlayer();
    }
    // Update is called once per frame
    void Update()
    {
        if(GameManager.Instance.gameState == GameStates.playing)
        {
            //groundCheck
            
            grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f, whatIsGround);
            // Debug.Log(grounded);

            MyInput();
            SpeedControl();
            if (grounded)
                rb.drag = groundDrag;
            else
            {
                rb.drag = 0;
            }
            //print(moveSpeed);
        }
        
    }

    private void MyInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
        //run
        if(Input.GetKey(speedKey) && grounded)
        {

            playerState = PlayerStates.runState;
            moveSpeed = doubleSpeed;
            Debug.Log("working");
        }
        //walk
        else
        {
            playerState = PlayerStates.walkState;
            moveSpeed = intialSpeed;
        }
        //jump
        if(Input.GetKey(jumpKey) && readyToJump && grounded)
        {

          readyToJump = false;
            Jump();
            playerState = PlayerStates.jumpState;   
            Invoke(nameof(ResetJump), jumpCooldown);
        }
    }
    private void MovePlayer()
    {
        //calculate movement direction 
        moveDirection = orientation.forward*verticalInput + orientation.right*horizontalInput;  

        if(grounded)
        rb.AddForce(moveDirection.normalized*moveSpeed*10f,ForceMode.Force);

        //in air
        else if(!grounded)
            rb.AddForce(moveDirection.normalized * moveSpeed * 10f*airMultiplier, ForceMode.Force);
    }

    private void SpeedControl()
    {
        Vector3 flatVel = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        //limit v
        if(flatVel.magnitude > moveSpeed)
        {
            Vector3 limitedVel = flatVel.normalized*moveSpeed;
            rb.velocity = new Vector3(limitedVel.x, rb.velocity.y, limitedVel.z);
           
        }
      
    }
    private void Jump()
    {
        //reset y velocity
        audioManager.Play("Jump");
        rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);
        //Debug.Log(rb.velocity.x);
        rb.AddForce(transform.up*jumpForce,ForceMode.Impulse);    
    }
    private void ResetJump()
    {
        readyToJump = true;
    }

    public void speedChanger(float age)
    {

        if(age< 25f)
        {
            intialSpeed = 15f;
            doubleSpeed = 18f;
            playingCanvas.updateUI(moveSpeed, age);
            


        }
        else if(age< 60f)
        {

            intialSpeed = 10f;
            doubleSpeed = 13f;
            playingCanvas.updateUI(moveSpeed, age);

        }
        else if(age < 100f)
        {

            intialSpeed = 5f;
            doubleSpeed = 8f;
            playingCanvas.updateUI(moveSpeed, age);

        }
    }
}

