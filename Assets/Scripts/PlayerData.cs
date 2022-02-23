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
    
    public PlayerData(Movement player,Settings settings)
    {
        position = new float[3];
        position[0] = player.transform.position.x;
        position[1] = player.transform.position.y;
        position[2] = player.transform.position.z;
        volume = settings.GetVolume();
        screenMode = settings.GetScreenMode();
        qualityIndex = settings.GetQuality();
        resolutionIndex = settings.GetResolution();
        
    }

    

}
