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
        else if (collision.gameObject.tag == "UnsichtbarMacher")
        {
            plattform.SetActive(false);
            this.gameObject.layer = 0;
        }
    }
}
