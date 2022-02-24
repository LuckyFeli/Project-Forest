using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MakeItButton : MonoBehaviour
{
    private Outline outline;
    public UnityEvent unityEvent = new UnityEvent();
    public GameObject button;
    // Start is called before the first frame update
    void Start()
    {
        button = this.gameObject;
        outline = GetComponent<Outline>();
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit) && hit.collider.gameObject == gameObject)
        {
            outline.enabled = true;
            if(Input.GetKeyDown(KeyCode.E))
            {
                unityEvent.Invoke();
            }
        }
        else
        {
            outline.enabled = false;    
        }
       
    }
}
