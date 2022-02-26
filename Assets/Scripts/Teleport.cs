using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    public GameObject pos1;
    public GameObject pos2;
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Teleporter" )
        {
            if (gameObject.transform.parent == pos1.transform)
            {
                gameObject.transform.parent = pos2.transform;
                gameObject.transform.localPosition = Vector3.zero;
            }
            else if(gameObject.transform.parent == pos2.transform)
            {
                gameObject.transform.parent = pos1.transform;
                gameObject.transform.localPosition = Vector3.zero;
            }
        }
    }
}
