using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FataMorgana : MonoBehaviour
{
    public Movement movement;
    public GameObject fataMorgana;
   
    private IEnumerator illusion()
    {
        yield return new WaitForSeconds(2f);
        fataMorgana.SetActive(true);
    }
    private void Update()
    {
        if (movement.isFake)
        {
            fataMorgana.SetActive(false);
            StartCoroutine(illusion());
        }
        
        
    }
}
