using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpTrigger : MonoBehaviour {

    public PlayerMovement_2 player;
    private TrolleyBoyController tb;
    public GameObject poofRing;
    public GameObject[] itemArray;
    public float itemSpawnSpeed;

    private void Start()
    {
        tb = gameObject.transform.parent.parent.GetComponentInParent<TrolleyBoyController>();
        if (tb == null)
        {
            return;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "PlayerJump")
        {
            //player.rb.velocity = new Vector3(player.rb.velocity.x, 0, player.rb.velocity.z);
            
            if (tb != null && !tb.stunned && !player.invincible)
            {
                player.Jump(2);
                StartCoroutine(tb.Stun(2));
                GameObject poofClone;
                poofClone = Instantiate(poofRing, transform.position, transform.rotation);
                GameObject itemClone;
                itemClone = Instantiate(itemArray[Random.Range(0, itemArray.Length)], transform.position, transform.rotation);
                itemClone.GetComponent<Rigidbody>().velocity += Vector3.up * itemSpawnSpeed;
            }
        }
    }
}
