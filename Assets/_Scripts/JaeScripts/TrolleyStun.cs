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
        if (collision.gameObject.tag == "Food" && !collision.gameObject.GetComponent<ItemController>().beingFired && !trolleyCon.stunned)
        {
            trolleyCon.FoodStun();
            Debug.Log("HIT WITH FOOD");
        }
    }
}
