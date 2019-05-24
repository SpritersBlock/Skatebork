using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuOOBKill : MonoBehaviour {

    public float yLevelKill;
    Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.angularVelocity = new Vector3(Random.Range(-3, 3), Random.Range(-3, 3), Random.Range(-3, 3));
    }

    // Update is called once per frame
    void FixedUpdate () {
        if (transform.position.y <= yLevelKill)
        {
            Destroy(gameObject);
        }
    }
}
