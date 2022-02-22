using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unsichtbar : MonoBehaviour
{
    public GameObject plattform;
    
   

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "SichtbarMacher")
        {
            plattform.SetActive(true);
            this.gameObject.layer = 6;

        }
    }
}
