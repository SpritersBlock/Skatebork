using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReticleChanger : MonoBehaviour {

    public Image reticle;
    public Color reticleActive;
    public Color reticleInactive;
    public Text retText;

    bool reticleOn;

    public PlayerMovement_2 player;

    private void Start()
    {
        ReticleOff();
    }

    private void Update()
    {
        if (player.hasFood)
        {
            if (!reticleOn)
            {
                ReticleOn();
            }
        }
        else
        {
            if (reticleOn)
            {
                ReticleOff();
            }
        }
    }

    void ReticleOn()
    {
        reticleOn = true;
        reticle.color = reticleActive;
        retText.text = " ";
        retText.color = reticleActive;
    }

    void ReticleOff()
    {
        reticleOn = false;
        reticle.color = reticleInactive;
        retText.text = "X";
        retText.color = reticleInactive;
    }
}
