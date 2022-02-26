using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameState : MonoBehaviour
{
    public GameObject[] Abilities;
    public static GameObject[] Key_Objects;
    public static bool[] Objects;
    public static bool[] getKeyObject()
    {
        Objects = new bool[Key_Objects.Length];
        for(int i = 0; i < Key_Objects.Length; i++)
        {
            Objects[i] = Key_Objects[i].activeSelf;
        }
        return Objects;
    }
}
