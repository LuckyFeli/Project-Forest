using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Schlucht : MonoBehaviour
{
    public GameObject sicherheit;
    public CharacterController characterController;
    private void OnTriggerEnter(Collider other)
    {Debug.Log(other);
        if(other.gameObject.tag == "Player")
        {
            Debug.Log("port");
            characterController = other.gameObject.GetComponent<CharacterController>();
            characterController.enabled = false;
            other.gameObject.transform.position = sicherheit.transform.position;
            characterController.enabled = true; 
        }
    }
}
