using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpin : MonoBehaviour {
    
    public GameObject playerNull;
    //Rigidbody rb;

    public float spinSpeed;

	// Use this for initialization
	void Start () {
        //rb = playerNull.GetComponent<Rigidbody>();
        //rb.angularVelocity = new Vector3(0, spinSpeed, 0);
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Equals))
        {
            UpdateDogSpeed(spinSpeed += 1);
        }

        if (Input.GetKeyDown(KeyCode.Minus))
        {
            UpdateDogSpeed(spinSpeed -= 1);
        }

        playerNull.transform.eulerAngles += new Vector3(0, spinSpeed * Time.timeScale, 0);
    }

    public void UpdateDogSpeed(float newSpeed)
    {
        //rb.angularVelocity = new Vector3(0, newSpeed, 0);
        spinSpeed = newSpeed;
    }
}
