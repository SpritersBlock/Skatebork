﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextDisplayer : MonoBehaviour {

    public Text fxText;
    public Animator anim;

	// Use this for initialization
	void Start () {
        anim = fxText.GetComponent<Animator>();
	}
	
	public void ShowText(string flavourText)
    {
        fxText.text = flavourText;
        anim.SetTrigger("ShowText");
        anim.SetBool("ShowingText", true);
        Invoke("TurnShowingTextOff", 2f);
    }

    public void TurnShowingTextOff()
    {
        anim.SetBool("ShowingText", false);
    }
}
