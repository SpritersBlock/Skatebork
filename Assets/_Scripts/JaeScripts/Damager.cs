using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damager : MonoBehaviour {

    private Rigidbody rb;
    PlayerMovement_2 player;
    JaeGameManager gm;
    TrolleyBoyController trolley;

    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody>();
        player = FindObjectOfType<PlayerMovement_2>();
        gm = FindObjectOfType<JaeGameManager>();
        trolley = transform.parent.GetComponentInParent<TrolleyBoyController>();
        if (trolley == null)
        {
            return;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "PlayerHurt")
        {
            if (!player.invincible && !trolley.stunned)
            {
                player.TakeDamage();
                gm.CameraShake();
                FindObjectOfType<AudioPlayer>().Play("Punch");
                if (player.speedSmoothTime < 1f)
                {
                    player.speedSmoothTime = 1;
                }
            }
        }
    }

    //private void OnTriggerExit(Collider other)
    //{
    //    if (other.tag == "PlayerHurt")
    //    {
    //        if (player.speedSmoothTime > 0.1f)
    //        {
    //            player.speedSmoothTime = 0.1f;
    //        }
    //    }
    //}
}
