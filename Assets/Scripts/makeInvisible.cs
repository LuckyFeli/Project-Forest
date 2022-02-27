using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class makeInvisible : MonoBehaviour
{
    public GameObject plattform;
    // Start is called before the first frame update
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "UnsichtbarMacher")
        {
            plattform.SetActive(false);
            this.gameObject.layer = 0;
        }
        
    }
}
