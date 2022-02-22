using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Throw : MonoBehaviour
{

    public GameObject Selection;
    private GameObject SCopy;
    private Rigidbody SCopyRB;
    private Collider SCopyCol;
    private bool cooldown = true;
    public float cd = 1f;
    // Start is called before the first frame update
    public void Start()
    {
        
    }

    public void ThrowObject(UnityEngine.InputSystem.InputAction.CallbackContext context)
    {

        if (context.performed && cooldown)
        {
            Vector3 prePos = Selection.transform.position;
            SCopy = Instantiate(Selection);
            SCopy.transform.position = prePos;
            SCopy.AddComponent<Rigidbody>();
            SCopyCol = SCopy.GetComponent<Collider>();
            SCopyCol.enabled = true;
            SCopyRB = SCopy.GetComponent<Rigidbody>();
            SCopyRB.mass = 0.25f;
            SCopyRB.drag = 3f;
            SCopyRB.AddForce(Camera.main.transform.forward * 250);
            Debug.Log("Throw!" + prePos);
            cooldown = false;
            StartCoroutine(Cooldown());
        }
        
    }
    private IEnumerator Cooldown()
    {
        yield return new WaitForSeconds(cd);
        cooldown = true;
    }
    // Update is called once per frame
    public void Update()
    {
        
    }


}
