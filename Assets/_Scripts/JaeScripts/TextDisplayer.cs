using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextDisplayer : MonoBehaviour {

    public Text fxText;
    Animator anim;

	// Use this for initialization
	void Start () {
        anim = fxText.GetComponent<Animator>();
	}
	
	public void ShowText(string flavourText)
    {
        fxText.text = flavourText;
        anim.SetTrigger("ShowText");
    }
}
