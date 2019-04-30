using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;

public class OOBKill : MonoBehaviour {

    public float yLevelKill;

    public AnalyticsTracker at;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (transform.position.y <= yLevelKill)
        {
            Destroy(gameObject);
        }
        if (transform.position.y <= -4)
        {
            //transform.position += new Vector3 (0,3,0);
            GetComponent<Rigidbody>().velocity = Vector3.zero;
            transform.position = Vector3.zero;
            //Analytics.CustomEvent("Item Respawned", new Dictionary<string, int> { {"Sew Time", variable } });
            at.TriggerEvent();
            print("RESPAWN");
        }
	}
}
