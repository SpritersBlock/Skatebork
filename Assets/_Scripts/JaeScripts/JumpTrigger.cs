using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpTrigger : MonoBehaviour {

    public PlayerMovement_2 player;
    private TrolleyBoyController tb;
    public GameObject poofRing;

    private void Start()
    {
        tb = gameObject.transform.parent.parent.GetComponentInParent<TrolleyBoyController>();
        if (tb == null)
        {
            return;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "PlayerJump")
        {
            //player.rb.velocity = new Vector3(player.rb.velocity.x, 0, player.rb.velocity.z);
            
            if (tb != null && !tb.stunned/* && !player.invincible*/)
            {
                player.Jump(2);
                StartCoroutine(tb.Stun(2));
                GameObject poofClone;
                poofClone = Instantiate(poofRing, transform.position, transform.rotation);
            }
        }
    }
}
