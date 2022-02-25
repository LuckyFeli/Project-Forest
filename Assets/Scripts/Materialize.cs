using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Materialize : MonoBehaviour
{

    
    //If the object is hit by the right GameObject the layer is set to be a real plattform instead of a fake one
    public void OnCollisionEnter(Collision collision)
    {
        
        if (collision.gameObject.tag == "Materialize")
        {
            gameObject.layer = 6;
        }

    }
}
