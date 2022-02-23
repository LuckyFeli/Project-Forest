using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pauseManager : MonoBehaviour
{
    public static pauseManager instance;
    public static bool pause;
    public Movement movement;
    public GameObject canvas;
    public Settings settings;
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
    public Vector3 loadGame()
    {
        Debug.Log("loading");
        PlayerData data = SaveSystem.loadPlayer();
        Vector3 position;
        position.x = data.position[0];
        position.y = data.position[1];
        position.z = data.position[2];
        
        return position;
    }
}
