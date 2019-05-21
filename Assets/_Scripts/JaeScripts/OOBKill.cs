using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;

public class OOBKill : MonoBehaviour {

    public float yLevelKill;
    public ItemController ic;

    float yPos;

    public AnalyticsTracker at;

	// Use this for initialization
	void Awake () {
        yPos = transform.position.y + 2;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (transform.position.y <= yLevelKill)
        {
            DestroyFood();
        }
        if (transform.position.y <= -4)
        {
            //transform.position += new Vector3 (0,6,0);
            transform.position = new Vector3(transform.position.x, yPos, transform.position.z);
            GetComponent<Rigidbody>().velocity = Vector3.zero;
            //Analytics.CustomEvent("Item Respawned", new Dictionary<string, int> { {"Sew Time", variable } });
            at.TriggerEvent();
            //print("RESPAWN");
            if (ic.beingFired)
            {
                DestroyFood();
            }
        }
	}

    void DestroyFood()
    {
        Destroy(gameObject);
        FindObjectOfType<JaeGameManager>().foodCount--;
    }
}
