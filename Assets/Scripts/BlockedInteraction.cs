using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockedInteraction : MonoBehaviour
{
    public GameObject br�cke;
    public bool[] blocked;
   
    public int counter = 0;

    private void OnTriggerStay(Collider other)
    {
        
        if(other.gameObject.tag == "Blocker")
        {
            br�cke.GetComponent<MeshCollider>().enabled = false;
        }
        else
        {
            br�cke.GetComponent<MeshCollider>().enabled=true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "Blocker")
        {
            br�cke.GetComponent<MeshCollider>().enabled = true;
        }
    }
    private void Update()
    {
          
    }

}
