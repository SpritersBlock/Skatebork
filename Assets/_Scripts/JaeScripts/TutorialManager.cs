using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialManager : MonoBehaviour {

    public GameObject[] jumpTexts;
    public GameObject throwText;
    public TextDisplayer txtDp;

	// Use this for initialization
	void Start () {
        TurnOffThrow();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void TurnOffJump()
    {
        for (int i = 0; i < jumpTexts.Length; i++)
        {
            jumpTexts[i].SetActive(false);
        }
        TurnOnThrow();
        txtDp.ShowText("Double Jump Off Enemies!");
    }

    public void ItemThrowTut()
    {
        txtDp.ShowText("Knock Him Off The Roof!");
    }

    void TurnOnThrow()
    {
        throwText.SetActive(true);
    }

    public void TurnOffThrow()
    {
        throwText.SetActive(false);
    }
}
