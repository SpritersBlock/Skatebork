using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Analytics;

public class JaeGameManager : MonoBehaviour {

    public PlayerMovement_2 player;
    private CameraShake cameraShake;
    public CameraFollow camFollow;
    public AnalyticsTracker playerDeathAT;
    public TextDisplayer txtDp;
    public GameObject pauseCanvas;
    //public TutorialManager tutMan;

    //public Slider hpBar;
    public PlayerHealthDisplayer playerHp;
    public GameObject deathCanvas;
    public GameObject winCanvas;
    public GameObject qToMenuText;
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
        winCanvas.SetActive(false);
        pauseCanvas.SetActive(false);
    }
	
	void Update () {
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (Time.timeScale == 0)
            {
                PauseMenuOff();
                gameOn = false;
            }
            else
            {
                PauseMenuOn();
                gameOn = true;
            }
        }
    }

    public void PauseMenuOn()
    {
        Time.timeScale = 0;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        pauseCanvas.SetActive(true);
    }

    public void PauseMenuOff()
    {
        Time.timeScale = 1;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        pauseCanvas.SetActive(false);
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
        playerHp.UpdateHealthText(playerHealth);
        if (playerHealth <= 0)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            deathCanvas.SetActive(true);
            aimReticle.SetActive(false);
            camFollow.mouseSensitivity = 0;
            qToMenuText.SetActive(false);
            gameOn = false;
            playerDeathAT.TriggerEvent();
        }
    }

    public void CameraShake()
    {
        StartCoroutine(cameraShake.Shake(.15f, .4f));
    }

    public void BossJustDied()
    {
        player.invincible = true;
    }

    public void BossIsNowDead()
    {
        gameOn = false;
        ChangeTrolleyTargetsToBoss();
        Invoke("DisplayWinCanvas", 1);
    }

    public void DisplayWinCanvas()
    {
        winCanvas.SetActive(true);
        qToMenuText.SetActive(false);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        camFollow.mouseSensitivity = 0;
        //player.walkSpeed = 0;
        //player.turnSmoothTime = 0;
        //player.speedSmoothTime = 0;
    }

    public void BackToMainMenu()
    {
        PauseMenuOff();
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        SceneTransition st;
        st = FindObjectOfType<SceneTransition>();
        StartCoroutine(st.LoadScene("MainMenu"));
    }
}
