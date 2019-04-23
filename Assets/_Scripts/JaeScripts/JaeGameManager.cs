using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JaeGameManager : MonoBehaviour {

    public PlayerMovement_2 player;

    public Slider hpBar;

    public int playerHealth = 3;

	void Start () {
		
	}
	
	void Update () {
		
	}

    public void UpdateHealth()
    {
        hpBar.value = playerHealth;
    }
}
