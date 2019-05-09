using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvincibilityFlash : MonoBehaviour {

    public Renderer playerRend;
    private float flashCounter;
    public float flashLength = 0.1f;

    public PlayerMovement_2 player;
    public BossController bc;

    private void Update()
    {
        flashCounter -= Time.deltaTime;
        if (player.invincible && player.gm.gameOn && bc.bossHealth > 0)
        {
            if (flashCounter <= 0)
            {
                playerRend.enabled = !playerRend.enabled;
                flashCounter = flashLength;
            }
        }
        else
        {
            playerRend.enabled = true;
        }
    }
}
