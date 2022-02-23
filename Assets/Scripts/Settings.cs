using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using System.Linq;
using UnityEngine.SceneManagement;

public class Settings : MonoBehaviour
{
    public AudioMixer audioMixer;
    public Dropdown resolutionDropdown;
    public Dropdown qualityDropdown;
    
    public Slider volumeSlider;
    private float currentVolume;
    private Resolution[] resolutions;
    private int[] rates;
    private FullScreenMode[] modes;
    // Start is called before the first frame update
    void Start()
    {
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

    public void SetScreenMode(int ScreenMode)
    {
        Screen.fullScreenMode = modes[ScreenMode];
    }

    
    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }
    public void SetResolution (int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width,resolution.height,Screen.fullScreen);
    }
    public void SetRefreshRate(int refreshIndex)
    {
        int refreshRate = rates[refreshIndex];
        Screen.SetResolution(Screen.currentResolution.width, Screen.currentResolution.height, Screen.fullScreen, refreshRate) ;
    }
   
    
}
   
