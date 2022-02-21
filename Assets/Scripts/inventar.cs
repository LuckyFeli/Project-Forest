using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class inventar : MonoBehaviour
{
    public GameObject[] toggles;
    private void resetInventory()
    {
        for (int i = 0; i < 5; i++)
        {
            toggles[i].gameObject.SetActive(false);
        }
    }
    public void changethrow(InputAction.CallbackContext context)
    {
        var itemNR = context.control.name.ToString().TrimStart(); ;
        if(itemNR == "1")
        {
            resetInventory();
            toggles[0].gameObject.SetActive(true);
        }
        else if(itemNR == "2")
        {
            resetInventory();
            toggles[1].gameObject.SetActive(true);
        }
        else if(itemNR == "3")
        {
            resetInventory();
            toggles[2].gameObject.SetActive(true);
        }
        else if(itemNR == "4")
        {
            resetInventory();
            toggles[3].gameObject.SetActive(true);
        }
        else
        {
            resetInventory();
            toggles[4].gameObject.SetActive(true);
        }
    }

    
}
