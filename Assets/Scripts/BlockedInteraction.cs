using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockedInteraction : MonoBehaviour
{
    public GameObject brücke;
    public bool[] blocked;
   
    public int counter = 0;

    private void OnTriggerStay(Collider other)
    {
        
        if(other.gameObject.tag == "Blocker")
        {
            brücke.GetComponent<MeshCollider>().enabled = false;
        }
        else
        {
            brücke.GetComponent<MeshCollider>().enabled=true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "Blocker")
        {
            brücke.GetComponent<MeshCollider>().enabled = true;
        }
    }
    private void Update()
    {
          
    }

}
