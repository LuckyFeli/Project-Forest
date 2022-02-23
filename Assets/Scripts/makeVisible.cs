using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class makeVisible : MonoBehaviour
{
    public GameObject plattform;



    private void OnTriggerEnter(Collider collision)
    {
        
        if (collision.gameObject.tag == "SichtbarMacher")
        {
            plattform.SetActive(true);
            plattform.layer = 6;

        }
        
        
    }
    
}
