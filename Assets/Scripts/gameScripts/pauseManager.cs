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
        //Spieler wird an die Position des Speicherns gestellt. 
        Debug.Log("loading");
        PlayerData data = SaveSystem.loadPlayer();
        Vector3 position;
        position.x = data.position[0];
        position.y = data.position[1];
        position.z = data.position[2];
        Debug.Log(data.inventory);

        //Im folgenden werden die wichtigen daten, welche für das inventar system gespeichert wurden wieder abgerufen und die aufgehobenen Objekte dementsprechend auch in der Welt Deaktiviert
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

        //Hier passiert das Selbe wie mit dem Inventar nur das es hier vor allem Schlüssel sind welche man benötigt um Level abzuschließen.
        for (int i = 0; i < gameState.Key_Objects.Length; i++)
        {
            gameState.Key_Objects[i].SetActive(!data.key_Objects[i]);
            //TODO Schalte gesammelte Schlüsselobjekte im HUD wieder ein.
            
        }
        return position;
    }
}
