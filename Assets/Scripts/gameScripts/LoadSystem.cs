using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadSystem : MonoBehaviour
{
    public Movement movement;
    public inventar inventory;
    public FirstPerson camera;
    public Toggle[] toggles;
    public GameObject[] objects = new GameObject[4];
    public GameObject[] abilitys;
    
    public void Start()
    {
        movement.LoadState();
        inventory.SetInventor(pauseManager.instance.toggleState);
        for (int i = 0; i < toggles.Length; i++)
        {
            toggles[i].isOn = pauseManager.instance.toggleState[i];
        }
        for (int i = 0; i < abilitys.Length; i++)
        {

            abilitys[i].SetActive(!pauseManager.instance.toggleState[i]);
        }
        for (int i = 0; i < 4; i++)
        {
            Debug.Log(objects[i]);Debug.Log(i); Debug.Log(pauseManager.instance.toggleState[i]);
            objects[i].SetActive(pauseManager.instance.keyObjectState[i]);
        }
        camera.LoadState();
    }
}
