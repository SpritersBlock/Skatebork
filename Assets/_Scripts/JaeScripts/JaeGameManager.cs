﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JaeGameManager : MonoBehaviour {

    public PlayerMovement_2 player;
    private CameraShake cameraShake;

    public Slider hpBar;
    public TrolleyBoyController[] trolleyBoys;

    public int playerHealth = 3;
    public bool gameOn = true;

    public GameObject boss;

	void Start () {
        cameraShake = FindObjectOfType<CameraShake>();
        trolleyBoys = FindObjectsOfType <TrolleyBoyController>();
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
        //if (playerHealth < 1)
        //{
        //    gameOn = false;
        //}
    }

    public void ChangeTrolleyTargetsToBoss()
    {
        for (int i = 0; i < trolleyBoys.Length; i++)
        {
            trolleyBoys[i].targetTransform = boss.transform;
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
