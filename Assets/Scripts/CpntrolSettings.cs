using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class CpntrolSettings : MonoBehaviour
{
    public InputActionReference movement;
    public InputBinding[] move_binding;
    // Start is called before the first frame update
    void Start()
    {
        
        
    }

    
    public void StartRebinding()
    {
        
       
        for (int i = 0; i < move_binding.Length; i++)
        {
            Debug.Log(move_binding[i].name);
        }
    }
}
