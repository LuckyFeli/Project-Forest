using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class Movement : MonoBehaviour
{
    private PlayerControls controls;
    public CharacterController controller;
    public float speed = 10f;
    public float sprint = 1f;
    private Vector2 movement;
    private Vector3 move;
   
    
    public float gravity = -9.81f;
    public float JumpForce = 1.0f;
    public float jumpHeight = 1.0f;
    private Vector3 jump;
    private Vector3 velocity;
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    private bool isGrounded;
    public LayerMask fataMorgana;
    public bool isFake = false;
    public Transform morganaCheck;
    public float morganaDistance = 0.7f;
    private void Start()
    {
        controls = new PlayerControls();
        
        controls.Enable();
       
        jump = new Vector3(0, 1, 0);
        Cursor.lockState = CursorLockMode.Locked;
        groundCheck = GameObject.Find("GroundCheck").GetComponent<Transform>();
        controller = GetComponent<CharacterController>();
    }

   



   
    private void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        isFake = Physics.CheckSphere(morganaCheck.position, morganaDistance, fataMorgana);
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -1f;
        }

        movement = controls.Gameplay.Movement.ReadValue<Vector2>();


        if (controls.Gameplay.sprinting.IsPressed())
        {
            move = transform.right * movement.x + transform.forward * movement.y + transform.right * movement.x * sprint + transform.forward * movement.y * sprint;
        }
        else
        { move = transform.right * movement.x + transform.forward * movement.y; }
        if (controls.Gameplay.crouching.IsPressed())
        {
            controller.height = Mathf.Clamp(controller.height / 2, 1f, 2f);
            move = move / 2;
        }
        else
        {
            controller.height = 2f;

        }

        controller.Move(move * speed * Time.deltaTime);
        if (isGrounded && controls.Gameplay.jumping.IsPressed())
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);

        }

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }
    public void pauseControls()
    {
        controls.Disable();
        gameObject.GetComponent<PlayerInput>().enabled = false;
    }
    
}

