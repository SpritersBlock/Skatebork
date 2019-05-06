﻿using System;
using UnityEngine;
using UnityEngine.Audio;

public class AudioPlayer : MonoBehaviour {

    public Sound[] sounds;
    public AudioMixerGroup mixer;

	// Use this for initialization
	void Awake () {
		foreach (Sound s in sounds)
        {
            s.source =  gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.outputAudioMixerGroup = mixer;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
        }
	}

    //FindObjectOfType<AudioPlayer>().Play("soundname");

    public void Play(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        s.source.Play();
    }
}
