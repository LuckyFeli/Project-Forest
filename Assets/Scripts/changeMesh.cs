using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changeMesh : MonoBehaviour
{
    public Mesh mesh;
    // Start is called before the first frame update
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Morph")
        {
            gameObject.GetComponent<MeshFilter>().mesh = mesh;
            gameObject.GetComponent<MeshCollider>().sharedMesh = mesh;
        }
    }
}
