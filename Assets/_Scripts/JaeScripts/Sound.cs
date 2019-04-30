﻿using UnityEngine.Audio;
using UnityEngine;

[System.Serializable]
public class Sound : MonoBehaviour {

    public string soundName;
    
    public AudioClip clip;
    [Range(0f, 1f)]
    public float volume = 1;
    [Range(-3f, 3f)]
    public float pitch = 1;

    [HideInInspector]
    public AudioSource source;
}
