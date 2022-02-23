using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pauseManager : MonoBehaviour
{
    public static pauseManager instance;
    public static bool pause;
    public Movement movement;
    private void Awake()
    {
        if (instance != null)
        {
            Destroy(this.gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(this);
    }
    public void resumeGame()
    {
        movement.resume();
    }
    public void loadGame(Vector3 position)
    {
        movement.gameObject.transform.position = position;
    }
}
