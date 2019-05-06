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
        if (tb == null) // This is just in case we want to put a jump trigger on something other than a trolley boy.
        {
            return;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "PlayerJump")
        {
            // Originally, you couldn't jump on enemies if you were invincible. This has since been changed.
            if (tb != null && !tb.stunned/* && !player.invincible*/)
            {
                player.Jump(2);
                StartCoroutine(tb.Stun(5));
                GameObject poofClone;
                poofClone = Instantiate(poofRing, transform.position, transform.rotation);
                // We should probably make this particle system its own script but for now, it's part of this one.
            }
        }
    }
}
