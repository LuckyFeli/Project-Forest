using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class CollisionEffects : MonoBehaviour
{    

    // Start is called before the first frame update
    void Start()
    {

    }

    private IEnumerator Destroy()
    {
        
        yield return new WaitForSeconds(2f);
        Destroy(this.gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        //swapper.transform.position = gameObject.transform.position;
        //Debug.Log("Gespawned in " + gameObject.transform.position);
        //Destroy(gameObject);
        //Instantiate(swapper);
        FindObjectOfType<AudioManager>().Play("Impact");
        this.GetComponent<VisualEffect>().enabled = true;
        StartCoroutine(Destroy());
    }

}