using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JaeGameManager : MonoBehaviour {

    public PlayerMovement_2 player;
    private CameraShake cameraShake;
    //public TutorialManager tutMan;

    public Slider hpBar;
    public GameObject deathCanvas;
    public GameObject aimReticle;
    public TrolleyBoyController[] trolleyBoys;

    public int playerHealth = 3;
    public bool gameOn = true;

    public GameObject finalTarget;

    public int foodCount;
    public int foodMax;

	void Start () {
        cameraShake = FindObjectOfType<CameraShake>();
        deathCanvas.SetActive(false);
    }
	
	void Update () {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            ButtonScripts bs;
            bs = FindObjectOfType<ButtonScripts>();
            bs.st.sceneName = "MainMenu";
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
        trolleyBoys = FindObjectsOfType<TrolleyBoyController>();
        for (int i = 0; i < trolleyBoys.Length; i++)
        {
            trolleyBoys[i].targetTransform = finalTarget.transform;
        }
    }

    public void UpdateHealth()
    {
        hpBar.value = playerHealth;
        if (playerHealth <= 0)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            deathCanvas.SetActive(true);
            aimReticle.SetActive(false);
        }
    }

    public void CameraShake()
    {
        StartCoroutine(cameraShake.Shake(.15f, .4f));
    }
}
