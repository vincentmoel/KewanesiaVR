using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AnimalRunningScript : MonoBehaviour
{
    [Tooltip("Check, apakah player dekat atau tidak")]
    public bool isPlayerNear = false;
    public NavMeshAgent agent; //Variabel agent

    public Transform playerPos;


    public void Update()
    {
        if (isPlayerNear)
        {
            float distance = Vector3.Distance(playerPos.position, transform.position); //To get player position and this object position

            //make AI run away
            Vector3 dirToPlayer = transform.position - playerPos.position; //To get a new position for target
            Vector3 newpos = transform.position + dirToPlayer; //To make a new position based on dirToPlayer distance
            agent.SetDestination(newpos); //Move the object
        }
    }


    private void OnTriggerEnter(Collider other) //To check if the player is near or not
    {
        if(other.CompareTag("Player"))
        {
            isPlayerNear = true;
        }
    }

    private void OnTriggerExit(Collider other) //To check if the player is near or not
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNear = false;
        }
    }


}
