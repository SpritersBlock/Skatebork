using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;

public class OOBKill : MonoBehaviour {

    public float yLevelKill;

    float yPos;

    public AnalyticsTracker at;

	// Use this for initialization
	void Awake () {
        yPos = transform.position.y;
	}
	
	// Update is called once per frame
	void Update () {
		if (transform.position.y <= yLevelKill)
        {
            Destroy(gameObject);
            FindObjectOfType<JaeGameManager>().foodCount--;
        }
        if (transform.position.y <= -4)
        {
            //transform.position += new Vector3 (0,3,0);
            transform.position = new Vector3(transform.position.x, yPos, transform.position.z);
            GetComponent<Rigidbody>().velocity = Vector3.zero;
            //Analytics.CustomEvent("Item Respawned", new Dictionary<string, int> { {"Sew Time", variable } });
            at.TriggerEvent();
            print("RESPAWN");
        }
	}
}
