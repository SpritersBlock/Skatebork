using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RandomDeathText : MonoBehaviour {

    [TextArea(3,10)]
    public string[] randomText;
    public Text deathText;

	// Use this for initialization
	void Start () {
        deathText.text = randomText[Random.Range(0, randomText.Length)];
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
