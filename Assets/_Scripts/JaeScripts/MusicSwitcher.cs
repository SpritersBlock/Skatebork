using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicSwitcher : MonoBehaviour {

    private MusicManager theMM;
    public int newTrack;
    public bool switchOnStart;

	// Use this for initialization
	void Start () {
        theMM = FindObjectOfType<MusicManager>();

        if (switchOnStart)
        {
            theMM.SwitchTrack(newTrack);
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
