using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrolleyStun : MonoBehaviour {

    public TrolleyBoyController trolleyCon;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Food" && !trolleyCon.stunned && collision.transform.position.y > -1.5f)
        {   
            trolleyCon.FoodStun();
            Debug.Log("HIT WITH FOOD");
        }
    }
}
