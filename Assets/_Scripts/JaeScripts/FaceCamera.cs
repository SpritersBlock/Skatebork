using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceCamera : MonoBehaviour {

    void LateUpdate()
    {
        var target = Camera.main.transform.position;
        transform.LookAt(target);
    }
}
