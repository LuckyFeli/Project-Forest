using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class pauseManager : MonoBehaviour
{
    public static pauseManager instance;
    public Vector3 position;
    public Vector3 rotation;
    public static bool pause;
    public Movement movement;
    public GameObject canvas;
    public FirstPerson camera;
    public gameState gameState;
    public Settings settings;
    public inventar inventar;
    public Toggle[] toggles;
    
    public LoadSystem loadSystem;
    public bool[] toggleState = new bool[5];
    public bool[] abilityState = new bool[5];
    public bool[] keyObjectState = new bool[4];
    private void Awake()
    {
        if (instance != null)
        {
            instance.movement = movement;
            instance.canvas = canvas;
            instance.settings = instance.gameObject.GetComponent<Settings>();
            instance.gameState = gameState;
            instance.movement = movement;
            instance.canvas = canvas;
            instance.inventar = inventar;
            
            instance.settings.resolutionDropdown = settings.resolutionDropdown;
            instance.settings.qualityDropdown = settings.qualityDropdown;
            instance.settings.volumeSlider = settings.volumeSlider;
            //for(int i = 0; i<abilityState.Length; i++)
            //{
                
            //    instance.abilityState[i] = abilityState[i];
            //}
            //for(int i = 0; i<keyObjectState.Length; i++)
            //{
            //    Debug.Log(keyObjectState[i]);
            //    instance.keyObjectState[i] = keyObjectState[i];
            //}
            instance.camera = camera;
            instance.settings.enabled = true;
            instance.loadSystem = loadSystem;
            for(int i = 0; i < toggles.Length; i++)
            {
                instance.toggles[i] = toggles[i];
            }
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
    public void newGame()
    {
        SceneManager.LoadScene("Terrain");
        instance.position = new Vector3(76, 2, 47);
        instance.rotation = new Vector3(0, -25, 0);
        for (int i = 0; i < instance.toggleState.Length; i++)
        {
            instance.toggleState[i] = false;
        }
        for(int i = 0; i < abilityState.Length; i++)
        {
            instance.abilityState[i] = false;
        }
        for(int i = 0; i<keyObjectState.Length; i++)
        {
            instance.keyObjectState[i] = true;
            Debug.Log(instance.keyObjectState[i]);
        }
        
        
    }
    public void loadGame()
    {
        SceneManager.LoadScene("Terrain");
        //Spieler wird an die Position des Speicherns gestellt. 
        Debug.Log("loading");
        PlayerData data = SaveSystem.loadPlayer();
        
        if (data.position != null)
        {
            
            position.x = data.position[0];
            position.y = data.position[1];
            position.z = data.position[2];
           
            
        }
        if(data.rotation != null)
        {
            Debug.Log("camera");
            rotation.x = data.rotation[0];
            rotation.y = data.rotation[1];
            rotation.z = data.rotation[2];
            Debug.Log(rotation); 
        }

        //Im folgenden werden die wichtigen daten, welche für das inventar system gespeichert wurden wieder abgerufen und die aufgehobenen Objekte dementsprechend auch in der Welt Deaktiviert
       
            
            for(int i = 0; i<data.inventory.Length; i++)
            {
                instance.toggleState[i] = data.inventory[i];
            }
            for(int i = 0; i<data.inventory.Length; i++)
            {
                instance.abilityState[i] = !data.inventory[i];
            }
            for(int i = 0; i<data.key_Objects.Length; i++)
            {
                Debug.Log(data.key_Objects[i]);
                instance.keyObjectState[i] = data.key_Objects[i];
            }
            

            ////Hier passiert das Selbe wie mit dem Inventar nur das es hier vor allem Schlüssel sind welche man benötigt um Level abzuschließen.
            //for (int i = 0; i < gameState.Key_Objects.Length; i++)
            //{
            //    gameState.Key_Objects[i].SetActive(!data.key_Objects[i]);
            //    //TODO Schalte gesammelte Schlüsselobjekte im HUD wieder ein.

            //}
            
        
        
    }
}
