using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class pickup : MonoBehaviour
{
    public pickup toggle;
    private void OnMouseUpAsButton()
    {
        Destroy(gameObject);
    }

    private void Start()
    {

    }
}