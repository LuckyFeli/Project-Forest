using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class pauseManager : MonoBehaviour
{
    public static pauseManager instance;
    public static bool pause;
    public Movement movement;
    public GameObject canvas;
    public Settings settings;
    public inventar inventar;
    public Toggle[] toggles;
    public gameState gameState;
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
        Debug.Log(data.inventory);
        inventar.SetInventor(data.inventory);
        toggles[0].isOn = data.inventory[0];
        toggles[1].isOn = data.inventory[1];
        toggles[2].isOn = data.inventory[2];
        toggles[3].isOn = data.inventory[3];
        toggles[4].isOn = data.inventory[4];
        gameState.Abilities[0].SetActive(!data.inventory[0]);
        gameState.Abilities[1].SetActive(!data.inventory[1]);
        gameState.Abilities[2].SetActive(!data.inventory[2]);
        gameState.Abilities[3].SetActive(!data.inventory[3]);
        gameState.Abilities[4].SetActive(!data.inventory[4]);
        return position;
    }
}
