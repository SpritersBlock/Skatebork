using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpin : MonoBehaviour {
    
    public GameObject playerNull;
    //Rigidbody rb;
    Animator anim;

    public float spinSpeed;

	// Use this for initialization
	void Start () {
        //rb = playerNull.GetComponent<Rigidbody>();
        //rb.angularVelocity = new Vector3(0, spinSpeed, 0);
        anim = playerNull.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        if (spinSpeed != 1)
        {
            if (!anim.GetBool("Spinning"))
            {
                anim.SetBool("Spinning", true);
            }
        } else
        {
            if (anim.GetBool("Spinning"))
            {
                anim.SetBool("Spinning", false);
            }
        }

        playerNull.transform.eulerAngles += new Vector3(0, spinSpeed * Time.timeScale, 0);
    }

    public void UpdateDogSpeed(float newSpeed)
    {
        //rb.angularVelocity = new Vector3(0, newSpeed, 0);
        spinSpeed = newSpeed;
        if (newSpeed > 7)
        {
            anim.SetFloat("SquashAmount", 1);
        } else if (newSpeed > 4)
        {
            anim.SetFloat("SquashAmount", 0.66f);
        }
        else if (newSpeed > 1)
        {
            anim.SetFloat("SquashAmount", 0.33f);
        }
        else
        {
            anim.SetFloat("SquashAmount", 0f);
        }
    }
}
