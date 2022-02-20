using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class Movement : MonoBehaviour
{
    private PlayerControls controls;
    public int camera_movement_horizontal =100;
    public int camera_movement_vertical = 20;
    private GameObject Figur;
    private GameObject Kopf;
    private Vector3 movement;
    private Vector2 camera_movement;
    private float nickWinkel = 0f;
    private bool grounded = true;
    private Rigidbody rb;
    public float JumpForce = 1.0f;
    private Vector3 jump;
    // Start is called before the first frame update
    private void Start()
    {
        controls = new PlayerControls();
        Figur = GameObject.Find("Spielfigur");
        Kopf = GameObject.Find("kopf");
        controls.Enable();
        rb = GetComponent<Rigidbody>();
        jump = new Vector3(0, 1, 0);
    }

    private void OnCollisionStay(Collision collision)
    {
        grounded = true;
    }
   
        
       
    
    // Update is called once per frame
    private void Update()
    {
        
        movement = controls.Gameplay.Movement.ReadValue<Vector3>();
        camera_movement = controls.Gameplay.Camera.ReadValue<Vector2>();
        
        Figur.transform.localPosition += transform.TransformDirection(Vector3.forward) *movement.z * Time.deltaTime;
       
        Figur.transform.localPosition += transform.TransformDirection(Vector3.right) *movement.x * Time.deltaTime;
        if (grounded && Keyboard.current.spaceKey.isPressed)
        {
            grounded = false;
            rb.AddForce(jump*JumpForce, ForceMode.Impulse);
            
        }
        Figur.transform.Rotate(new Vector3(0,camera_movement.x,0) *camera_movement_horizontal* Time.deltaTime);

        nickWinkel += -camera_movement.y *camera_movement_vertical*Time.deltaTime;
        nickWinkel = Mathf.Clamp(nickWinkel, -25f, 30f);
        Kopf.transform.localRotation = Quaternion.AngleAxis(nickWinkel, Vector3.right);
       
    }
}
