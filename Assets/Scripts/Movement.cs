using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class Movement : MonoBehaviour
{
    private PlayerControls controls;
    
    
    private Vector2 movement;
    private Vector3 move;
    private bool isGrounded = true;
    private Rigidbody rb;

    public float JumpForce = 1.0f;
    private Vector3 jump;
    
    private void Start()
    {
        controls = new PlayerControls();
        
        controls.Enable();
        rb = GetComponent<Rigidbody>();
        jump = new Vector3(0, 1, 0);
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void OnCollisionStay(Collision collision)
    {
        isGrounded = true;
    }
   
        
       
    
    
    private void Update()
    {
        
        movement = controls.Gameplay.Movement.ReadValue<Vector2>();

        if (Keyboard.current.leftShiftKey.isPressed || Gamepad.current.leftStickButton.isPressed)
        {
            move = new Vector3(1 * movement.x, 0, 1 * movement.y) * Time.deltaTime + new Vector3(0.5f * movement.x, 0, 0.5f * movement.y)*Time.deltaTime;
        }
        else
        { move = new Vector3(1 * movement.x, 0, 1 * movement.y) * Time.deltaTime; }

        transform.Translate(move);
        if (isGrounded && (Keyboard.current.spaceKey.isPressed || Gamepad.current.aButton.isPressed))
        {
            isGrounded = false;
            rb.AddForce(jump*JumpForce, ForceMode.Impulse);
            
        }
        
       
    }
}
