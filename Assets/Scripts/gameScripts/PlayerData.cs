using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public float[] position;
    public float volume;
    public int screenMode;
    public int qualityIndex;
    public int resolutionIndex;
    public bool[] inventory;
    public bool[] key_Objects;
    public float[] rotation;
    public PlayerData(Movement player, Settings settings, inventar inventoryInfo, FirstPerson camera,gameState stand)
    {
        position = new float[3];
        rotation = new float[3];
        position[0] = player.transform.position.x;
        position[1] = player.transform.position.y;
        position[2] = player.transform.position.z;
        volume = settings.GetVolume();
        screenMode = settings.GetScreenMode();
        qualityIndex = settings.GetQuality();
        resolutionIndex = settings.GetResolution();
        rotation[0] = camera.playerbody.localEulerAngles.x;
        rotation[1] = camera.playerbody.localEulerAngles.y;
        rotation[2] = camera.playerbody.localEulerAngles.z;
        Debug.Log("rot " + rotation[0] + " " + rotation[1] + " "+rotation[2]);
           inventory = new bool[5];
            inventory = inventoryInfo.GetInventory();
        
            key_Objects = new bool[4];
            key_Objects = stand.getKeyObject();
        
       
        
        }
    

}
