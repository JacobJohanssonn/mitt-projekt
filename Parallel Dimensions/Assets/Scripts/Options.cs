using System;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.UI;



public class Options : MonoBehaviour
{
    public TMP_Text textMesh;
    public Slider AudioSlider;
    public TMP_Dropdown ResolutionDropdown;
    public TMP_Dropdown WindowDropdown;

    public class SaveObject
    {
        public int resolutionWidth;
        public int resolutionHeight;
        public FullScreenMode windowMode;
        public float globalVolume;
    }

    void Start()
    {
        if(!File.Exists(Application.persistentDataPath + "/Saves/Options.sav"))
        {
            return;
        }
        string json = File.ReadAllText(Application.persistentDataPath + "/Saves/Options.sav");
        SaveObject save = JsonUtility.FromJson<SaveObject>(json);

        Screen.SetResolution(save.resolutionWidth, save.resolutionHeight, save.windowMode);
        AudioSlider.value = save.globalVolume * 100;
        AudioListener.volume = save.globalVolume;

        if(save.windowMode == FullScreenMode.Windowed)
        {
            WindowDropdown.value = 0;
        }
        else if(save.windowMode == FullScreenMode.ExclusiveFullScreen)
        {
            WindowDropdown.value = 1;
        }
        else if(save.windowMode == FullScreenMode.FullScreenWindow)
        {
            WindowDropdown.value = 2;
        }

        if(save.resolutionWidth == 1280)
        {
            ResolutionDropdown.value = 0;
        }
        else if(save.resolutionWidth == 1600)
        {
            ResolutionDropdown.value = 1;
        }
        else if(save.resolutionWidth == 1920)
        {
            ResolutionDropdown.value = 2;
        }
        else if(save.resolutionWidth == 2560)
        {
            ResolutionDropdown.value = 3;
        }
        else if(save.resolutionWidth == 3840)
        {
            ResolutionDropdown.value = 4;
        }
        gameObject.SetActive(false);
    }

    public void ChangeGlobalAudio()
    {
        AudioListener.volume = AudioSlider.value / 100;
        textMesh.text = (AudioListener.volume * 100).ToString() + "%";
        string json = JsonUtility.ToJson(new SaveObject
        {
            resolutionWidth = Screen.width,
            resolutionHeight = Screen.height,
            windowMode = Screen.fullScreenMode,
            globalVolume = AudioListener.volume
        });
        File.WriteAllText(Application.persistentDataPath + "/Saves/Options.sav", json);
    }

    public void ChangeResolution()
    {
        string resolutiontext = ResolutionDropdown.options[ResolutionDropdown.value].text;

        string[] Parts = resolutiontext.Split('x');

        int width = int.Parse(Parts[0]);
        int height = int.Parse(Parts[1]);

        Screen.SetResolution(width, height, Screen.fullScreenMode);

        string json = JsonUtility.ToJson(new SaveObject
        {
            resolutionWidth = width,
            resolutionHeight = height,
            windowMode = Screen.fullScreenMode,
            globalVolume = AudioListener.volume
        });
        File.WriteAllText(Application.persistentDataPath + "/Saves/Options.sav", json);
    }

    public void ChangeWindowMode()
    {
        int selectedOption = WindowDropdown.value;
        if(selectedOption == 0)
        {
            Screen.SetResolution(Screen.width, Screen.height, FullScreenMode.Windowed);
        }
        else if(selectedOption == 1)
        {
            Screen.SetResolution(Screen.width, Screen.height, FullScreenMode.ExclusiveFullScreen);
        }
        else if(selectedOption == 2)
        {
            Screen.SetResolution(Screen.width, Screen.height, FullScreenMode.FullScreenWindow);
        }
        string json = JsonUtility.ToJson(new SaveObject
        {
            resolutionWidth = Screen.width,
            resolutionHeight = Screen.height,
            windowMode = Screen.fullScreenMode,
            globalVolume = AudioListener.volume
        });

        File.WriteAllText(Application.persistentDataPath + "/Saves/Options.sav", json);
    }
}
