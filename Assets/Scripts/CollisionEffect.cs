using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionEffect : MonoBehaviour
{
    public GameObject swapper;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {

        Instantiate(swapper);
        swapper.transform.position = gameObject.transform.position;
        Destroy(gameObject);
    }

}
