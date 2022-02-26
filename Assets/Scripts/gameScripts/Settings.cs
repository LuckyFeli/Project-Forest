using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using System.Linq;
using UnityEngine.SceneManagement;
using TMPro;

public class Settings : MonoBehaviour
{
    public AudioMixer audioMixer;
    public TMP_Dropdown resolutionDropdown;
    public TMP_Dropdown qualityDropdown;
    
    public Slider volumeSlider;
    private float currentVolume;
    private int currentQuality;
    private int currentScreenMode;
    private int currentScreenResolution;
    private int currentrefreshIndex;
    private Resolution[] resolutions;
    private int[] rates;
    private FullScreenMode[] modes;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Test");
        
        modes = new FullScreenMode[] {FullScreenMode.MaximizedWindow,FullScreenMode.Windowed,FullScreenMode.FullScreenWindow, FullScreenMode.ExclusiveFullScreen };
        resolutions = Screen.resolutions.Select(resolution => new Resolution { width = resolution.width, height = resolution.height }).Distinct().ToArray();
        resolutionDropdown.ClearOptions();
        rates = new int[5]{ 30, 60, 90, 120, 144 };
        List<string> options = new List<string>();
        int currentResolutionIndex = 0;
        for (int i = 0; i< resolutions.Length; i++)
        {
            string option = resolutions[i].width  + " x " + resolutions[i].height ;
            options.Add(option);
            if(resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height)
            {
                currentResolutionIndex = i;
            }
        }

        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();
    }
    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("Volume", volume);
        currentVolume = volume;
    }
    public float GetVolume()
    {
        return currentVolume;
    }

    public void SetScreenMode(int ScreenMode)
    {if (modes != null)
        {
            Screen.fullScreenMode = modes[ScreenMode];
            currentScreenMode = ScreenMode;
        }
    }
    public int GetScreenMode()
    {
        return currentScreenMode;
    }
    
    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
        currentQuality = qualityIndex;
    }
    public int GetQuality()
    {
        return currentQuality;
    }
    public void SetResolution (int resolutionIndex)
    {
        if (resolutions != null)
        {
            Debug.Log(resolutions[resolutionIndex]);
            Resolution resolution = resolutions[resolutionIndex];
            Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
            currentScreenResolution = resolutionIndex;
        }
    }
    public int GetResolution()
    {
        return currentScreenResolution;
    }
   
    
   
    
}
   
