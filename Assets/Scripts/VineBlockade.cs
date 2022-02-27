using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
public class VineBlockade : MonoBehaviour
{
    public Outline[] outlines;
    public inventar inventory;
    public UnityEvent unityEvent = new UnityEvent();
    public GameObject toggle;
    private bool fire;
    public float t = 0f;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit) && hit.collider.gameObject == gameObject && Vector3.Distance(hit.point, player.transform.position) <= 3)
        {
            for (int i = 0; i < outlines.Length; i++) {
                outlines[i].enabled = true; }
            if (Input.GetKeyDown(KeyCode.E) && inventory.changeAbility == 4)
            {
                fire = true;
                inventory.toggles[4].gameObject.SetActive(false);
                inventory.ability5 = false;
                inventory.throwableObjects[4].SetActive(false);
                toggle.GetComponent<Toggle>().isOn = false;
                
            }
        }
        else
        {
            for (int i = 0; i < outlines.Length; i++)
            {
                outlines[i].enabled = false;
            }
        }
        if (fire)
        {
            t +=Time.deltaTime/5f;
            gameObject.transform.localScale = Vector3.Lerp(gameObject.transform.localScale, Vector3.zero, t);
            if (t > 1f)
            {
                gameObject.SetActive(false);
            }
        }
    }
   
}
