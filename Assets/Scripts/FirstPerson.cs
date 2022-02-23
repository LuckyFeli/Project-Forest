using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class FirstPerson : MonoBehaviour
{
    private float nickWinkel = 0f;
    public int camera_movement_horizontal = 100;
    public int camera_movement_vertical = 20;
    private Vector2 camera_movement;
    PlayerControls controls;
    public Transform playerbody;
    // Start is called before the first frame update
    void Start()
    {
        controls = new PlayerControls();
        controls.Enable();
    }

    // Update is called once per frame
    public void cameraControl()
    {
        camera_movement = controls.Gameplay.Camera.ReadValue<Vector2>();
        nickWinkel += -camera_movement.y * camera_movement_vertical * Time.deltaTime;
        nickWinkel = Mathf.Clamp(nickWinkel, -90f, 90f);
        transform.localRotation = Quaternion.AngleAxis(nickWinkel, Vector3.right);
        playerbody.Rotate(Vector3.up * camera_movement.x * Time.deltaTime * camera_movement_horizontal);

    }
    private void Update()
    {
        
    }
}
