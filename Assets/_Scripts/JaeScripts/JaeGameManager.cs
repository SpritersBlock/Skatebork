using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JaeGameManager : MonoBehaviour {

    public PlayerMovement_2 player;
    private CameraShake cameraShake;

    public Slider hpBar;

    public int playerHealth = 3;

	void Start () {
        cameraShake = FindObjectOfType<CameraShake>();
    }
	
	void Update () {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            ButtonScripts bs;
            bs = FindObjectOfType<ButtonScripts>();
            bs.MoveToGame();
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }

    public void UpdateHealth()
    {
        hpBar.value = playerHealth;
        
    }

    public void CameraShake()
    {
        StartCoroutine(cameraShake.Shake(.15f, .4f));
    }
}
