using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
public class Movement : MonoBehaviour
{   //InputSystem
    private PlayerControls controls;
    public CharacterController controller;
    
    private Vector2 movement;
    private Vector3 move;

    //Data for Physics 
    public float speed = 10f;
    public float sprint = 1f;
    public float gravity = -9.81f;
    public float JumpForce = 1.0f;
    public float jumpHeight = 1.0f;
    private Vector3 velocity;

    //Important data for jump and gravity system
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    private bool isGrounded;

    //Important data for "fake" Objects
    public LayerMask fataMorgana;
    public bool isFake = false;
    public Transform morganaCheck;
    public float morganaDistance = 0.7f;

    private void Start()
    {
        
        Cursor.lockState = CursorLockMode.Locked;
        groundCheck = GameObject.Find("GroundCheck").GetComponent<Transform>();
        controller = GetComponent<CharacterController>();
    }

    //sets the control and loads the important data in the save file
    private void Awake()
    {
        controls = new PlayerControls();
        
        

    }
    public void LoadState()
    {
        transform.position = pauseManager.instance.position;
    }
    //Activates the control scheme
    private void OnEnable()
    {
        controls.Enable();
    }

    //Character Movement is controlled here
    private void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        isFake = Physics.CheckSphere(morganaCheck.position, morganaDistance, fataMorgana);
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -1f;
            
        }

        movement = controls.Gameplay.Movement.ReadValue<Vector2>();
        if (movement != new Vector2(0, 0))
            FindObjectOfType<AudioManager>().Play("PlayerWalk");



        if (controls.Gameplay.sprinting.IsPressed())
        {
            move = transform.right * movement.x + transform.forward * movement.y + transform.right * movement.x * sprint + transform.forward * movement.y * sprint;
            
        }
        else
        { 
            move = transform.right * movement.x + transform.forward * movement.y;
            

        }
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

    //When exiting the pause menu, give players the control back 
    public void resume()
    {
        controls.Enable();
        gameObject.GetComponent<PlayerInput>().enabled = true;
        Time.timeScale = 1;
        Cursor.lockState = CursorLockMode.Locked;
    }

    //Deactivates the playerControls as soon as the game gets paused
    public void pauseControls(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Debug.Log("Pause");
            pauseManager.instance.canvas.SetActive(true);

            controls.Gameplay.Disable();
            
            this.GetComponent<PlayerInput>().enabled = false;
            Time.timeScale = 0;
            Cursor.lockState = CursorLockMode.None;
            
        }
    }
    public void gameLoaded(Vector3 savePosition)
    {
        controller.transform.position = savePosition;
    }
}

