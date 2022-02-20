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
    private Vector2 movement;
    private Vector2 camera_movement;
    // Start is called before the first frame update
    private void Start()
    {
        controls = new PlayerControls();
        Figur = GameObject.Find("Spielfigur");
        controls.Enable();
    }

    // Update is called once per frame
    private void Update()
    {
        
        movement = controls.Gameplay.Movement.ReadValue<Vector2>();
        camera_movement = controls.Gameplay.Camera.ReadValue<Vector2>();
        Debug.Log(camera_movement.x);
        Figur.transform.localPosition += transform.TransformDirection(Vector3.forward) *movement.y * Time.deltaTime;
        Figur.transform.localPosition += transform.TransformDirection(Vector3.right) *movement.x * Time.deltaTime;
        Figur.transform.Rotate(new Vector3(0,camera_movement.x,0) *camera_movement_horizontal* Time.deltaTime);
        Figur.transform.Rotate(new Vector3(-camera_movement.y,0,0)*camera_movement_vertical*Time.deltaTime);
        
    }
}
