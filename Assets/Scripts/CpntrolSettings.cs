using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class CpntrolSettings : MonoBehaviour
{
    private InputActionRebindingExtensions.RebindingOperation rebindingOperation;
    public InputActionReference movement;
    public InputBinding[] move_binding;
    public InputAction inputAction;
    // Start is called before the first frame update
    void Start()
    {
        
        
    }

   public void StartInteractiveRebind()
    {
        rebindingOperation = inputAction.PerformInteractiveRebinding().OnComplete(operation => RebindCompleted());
        rebindingOperation.Start();
    }
    void RebindCompleted()
    {
        rebindingOperation.Dispose();
    }
   
}
