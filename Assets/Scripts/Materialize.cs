using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Materialize : MonoBehaviour
{
    // Start is called before the first frame update
    public void OnCollisionEnter(Collision collision)
    {
        Debug.Log("test");
        if (collision.gameObject.tag == "Materialize")
        {
            gameObject.layer = 6;
        }

    }
}
