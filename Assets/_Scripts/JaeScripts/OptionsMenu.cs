using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class OptionsMenu : MonoBehaviour {

    public AudioMixer audioMixer;
    public Image volumeBar;
    public int localVolume;
    public Toggle fsToggle;

    public float volMin = -80;
    public float volMax = 0;

    public void Awake()
    {
        audioMixer.SetFloat("Volume", volMax);
        //I can't figure out how to get the volume bar to stay consistent when you exit/enter scenes so for now I'm just resetting the volume. Bluh.
        if (Screen.fullScreen)
        {
            fsToggle.isOn = true;
        } else
        {
            fsToggle.isOn = false;
        }
        
    }

    public void AddVolume (int volume)
    {
        if ((localVolume + volume) <= volMax)
        {
            audioMixer.SetFloat("Volume", localVolume + volume);
            localVolume += volume;
            volumeBar.fillAmount += 0.0625f;
        }
    }

    public void SubVolume(int volume)
    {
        if ((localVolume - volume) >= volMin)
        {
            audioMixer.SetFloat("Volume", localVolume - volume);
            localVolume -= volume;
            volumeBar.fillAmount -= 0.0625f;
        }
    }

    public void SetFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }
}
