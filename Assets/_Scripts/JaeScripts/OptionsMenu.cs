using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class OptionsMenu : MonoBehaviour {

    public AudioMixer audioMixer;
    public Image volumeBar;
    public float localVolume;
    public Toggle fsToggle;

    public float volMin = -80;
    public float volMax = 0;
    float audioValue;
    float audioValueIncrement;

    public void Awake()
    {
        audioValueIncrement = (Mathf.Abs(volMin) / 16);
        audioMixer.GetFloat("Volume", out audioValue);
        if (audioValue > -5)
        {
            audioMixer.SetFloat("Volume", 0);
        }
        volumeBar.fillAmount = 1-(0.0625f * (Mathf.Abs(audioValue) / audioValueIncrement));
        localVolume = 0 - (5f * (Mathf.Abs(audioValue) / audioValueIncrement));
        if (volumeBar.fillAmount > 0.9375)
        {
            volumeBar.fillAmount = 1;
            localVolume = 0;
        }
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
            audioMixer.GetFloat("Volume", out audioValue);
        }
    }

    public void SubVolume(int volume)
    {
        if ((localVolume - volume) >= volMin)
        {
            audioMixer.SetFloat("Volume", localVolume - volume);
            localVolume -= volume;
            volumeBar.fillAmount -= 0.0625f;
            audioMixer.GetFloat("Volume", out audioValue);
        }
    }

    public void SetFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }
}
