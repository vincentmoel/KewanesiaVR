using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AnimalRunningScript : MonoBehaviour
{
    [Tooltip("Check, apakah player dekat atau tidak")]
    public bool isPlayerNear = false;
    public NavMeshAgent agent;

    public Transform playerPos;


    public void Update()
    {
        if (isPlayerNear)
        {
            float distance = Vector3.Distance(playerPos.position, transform.position);

            //make AI run away
            Vector3 dirToPlayer = transform.position - playerPos.position;
            Vector3 newpos = transform.position + dirToPlayer;
            agent.SetDestination(newpos);
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            isPlayerNear = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNear = false;
        }
    }


}
