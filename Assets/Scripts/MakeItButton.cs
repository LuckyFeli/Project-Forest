using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MakeItButton : MonoBehaviour
{
    private Outline outline;
    public UnityEvent unityEvent = new UnityEvent();
    public GameObject button;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        button = this.gameObject;
        outline = GetComponent<Outline>();
        player = GameObject.Find("Spielfigur");
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit) && hit.collider.gameObject == gameObject && Vector3.Distance(hit.point, player.transform.position) <= 3) 
        {
            outline.enabled = true;
            if(Input.GetKeyDown(KeyCode.E))
            {
                FindObjectOfType<AudioManager>().Play("FlowerCollected");
                unityEvent.Invoke();
            }
        }
        else
        {
            outline.enabled = false;    
        }
       
    }
}
