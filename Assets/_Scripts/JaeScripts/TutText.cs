using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutText : MonoBehaviour {

    void LateUpdate()
    {
        var target = Camera.main.transform.position;
        target.y = transform.position.y;
        transform.LookAt(target);
    }

    public void RemoveText()
    {
        Destroy(gameObject);
    }
}
