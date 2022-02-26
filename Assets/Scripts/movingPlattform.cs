using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class movingPlattform : MonoBehaviour
{
    public Vector3 newPosition = new Vector3(50, 0, 50);
    public GameObject plattform;
    
    public float time;
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("test");
        if (collision.gameObject.tag == "Mover")
        {
           // iTween.MoveTo(plattform,iTween.Hash( "time",time,"position",newPosition,"easetype","linear"));
            //characterController.enabled = false;
            StartCoroutine(noControl());
        }
    }
    private IEnumerator noControl()
    {
        yield return new WaitForSeconds(time);
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            

            other.gameObject.transform.parent = this.transform;
           
        }
    }
   
    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            other.gameObject.transform.parent = null;
            
            
            
        }
    }
}
