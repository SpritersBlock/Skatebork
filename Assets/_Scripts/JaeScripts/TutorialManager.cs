using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialManager : MonoBehaviour {

    public GameObject[] jumpTexts;
    public GameObject throwText;
    public TextDisplayer txtDp;
    
    public JaeGameManager gm;

	// Use this for initialization
	void Start () {
        TurnOffThrow();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void TurnOffJump()
    {
        jumpTexts = GameObject.FindGameObjectsWithTag("JumpText");
        for (int i = 0; i < jumpTexts.Length; i++)
        {
            jumpTexts[i].SetActive(false);
        }
        TurnOnThrow();
        txtDp.ShowText("Double Jump Off Enemies!");
        gm.JumpTextOff();
    }

    public void ItemThrowTut()
    {
        if (txtDp.anim.GetBool("ShowingText"))
        {
            Invoke("ItemThrowTut", 0.1f);
        } else
        {
            txtDp.ShowText("Knock Him Off The Roof!");
        }
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
