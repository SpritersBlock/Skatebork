using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoofSpawner : MonoBehaviour {

    public GameObject poofRing;

    public void SpawnPoofRing(Vector3 spawnPos, Transform spawnTransform)
    {
        GameObject poofClone;
        poofClone = Instantiate(poofRing, spawnTransform.position, spawnTransform.rotation);
    }
}
