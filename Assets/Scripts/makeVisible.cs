using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class makeVisible : MonoBehaviour
{
    public GameObject plattform;


    //If the right object hits the trigger it will activate the gameObject and sets it
    private void OnTriggerEnter(Collider collision)
    {
        
        if (collision.gameObject.tag == "SichtbarMacher")
        {
            plattform.SetActive(true);
            plattform.layer = 6;

        }
        
        
    }
    
}
