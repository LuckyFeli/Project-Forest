using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameState : MonoBehaviour
{
    public GameObject[] Abilities;
    public GameObject[] Factions;
    public  GameObject[] Key_Objects;
    public  bool[] Objects;
    public bool[] getKeyObject()
    {
        Objects = new bool[4];
        for (int i = 0; i < Key_Objects.Length; i++)
        {
            Debug.Log((Key_Objects[i].activeSelf));
            Objects[i] = Key_Objects[i].activeSelf;
            
        }
        return Objects;
    }
}
