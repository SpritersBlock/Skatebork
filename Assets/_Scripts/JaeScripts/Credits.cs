using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Credits : MonoBehaviour {

    public GameObject creditsTexts1;
    public GameObject creditsTexts2;

    public Text buttonText;

    public int creditsIndex;

	// Use this for initialization
	void Start () {
        creditsTexts2.SetActive(false);
        buttonText.text = "Assets";
        creditsIndex = 1;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SwitchCredits()
    {
        if (creditsIndex == 1)
        {
            creditsIndex = 2;
            creditsTexts1.SetActive(false);
            creditsTexts2.SetActive(true);
            buttonText.text = "Devs";
        }
        else if (creditsIndex == 2)
        {
            creditsIndex = 1;
            creditsTexts1.SetActive(true);
            creditsTexts2.SetActive(false);
            buttonText.text = "Assets";
        }
    }
}
