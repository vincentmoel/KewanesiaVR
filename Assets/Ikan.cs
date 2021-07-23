using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;
using Random = UnityEngine.Random;

public class Ikan : MonoBehaviour
{
    public GameObject ikans;
    public GameObject bombs;
    public Vector3 center;
    public Vector3 size;
    public bool state;

    [SerializeField] public List<GameObject> totIkan;
    [SerializeField] public List<GameObject> totBomb;
    public float nextActionTime = 0.0f;
    public float period = 1f;
 
    void Update () {
        if (!state)
        {
            return;
        }
        if (Time.time > nextActionTime ) { //
            nextActionTime += period;
            if (totIkan.Count < 35 || totBomb.Count < 5) SpawnObjectAtRandom();
        }
    }

    void SpawnObjectAtRandom()
    {
        Vector3 randomPos = center + new Vector3(UnityEngine.Random.Range(-size.x / 2, size.x / 2), 
            UnityEngine.Random.Range(-size.y / 2, size.y / 2), 
            UnityEngine.Random.Range(-size.z / 2, size.z / 2));

        GameObject objeckSpawn = new GameObject();
        switch (Random.Range(0,2))
        {
            case 0 :
                if (totBomb.Count < 5)
                {
                    objeckSpawn = Instantiate(bombs, randomPos, Quaternion.identity);
                    objeckSpawn.tag = "Bomb";
                    objeckSpawn.SetActive(true);
                    totBomb.Add(objeckSpawn);
                }
                else
                {
                    objeckSpawn = Instantiate(ikans, randomPos, Quaternion.identity);
                    objeckSpawn.tag = "Ikan";
                    objeckSpawn.SetActive(true);
                    totIkan.Add(objeckSpawn);
                }

                break;
            
            case 1 :
                objeckSpawn= Instantiate(ikans, randomPos, Quaternion.identity);
                objeckSpawn.tag = "Ikan";
                objeckSpawn.SetActive(true);
                totIkan.Add(objeckSpawn);
                
                break;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = new Color(0, 1, 0, 0.5f);
        Gizmos.DrawCube(center, size);
    }
}
