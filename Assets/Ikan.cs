using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class Ikan : MonoBehaviour
{
    public GameObject ikans;
    public Vector3 center;
    public Vector3 size;
    
    
    private float nextActionTime = 0.0f;
    public float period = 1f;
 
    void Update () {
        if (Time.time > nextActionTime ) { //
            nextActionTime += period;
            SpawnObjectAtRandom();
        }
    }

    void SpawnObjectAtRandom()
    {
        Vector3 randomPos = center + new Vector3(UnityEngine.Random.Range(-size.x / 2, size.x / 2), 
            UnityEngine.Random.Range(-size.y / 2, size.y / 2), 
            UnityEngine.Random.Range(-size.z / 2, size.z / 2));

        Instantiate(ikans, randomPos, Quaternion.identity);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = new Color(0, 1, 0, 0.5f);
        Gizmos.DrawCube(center, size);
    }
}
