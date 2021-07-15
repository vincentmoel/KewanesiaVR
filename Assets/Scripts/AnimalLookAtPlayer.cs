using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PolyPerfect;
using UnityEngine.AI;


public class AnimalLookAtPlayer : MonoBehaviour
{
    public GameObject papan;
    public Transform player;
    public Animal_WanderScript animal_Wander;
    public Animator anim;
    public NavMeshAgent agent;
    public bool isPlayerNear;
    public bool clicked;

    
    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        animal_Wander = GetComponent<Animal_WanderScript>();
        anim = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
     //   papan.SetActive(clicked);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNear = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            CancelInteraktive();
        }
    }

    public void AnimalClick()
    {
        if (!isPlayerNear)
            return;

        clicked = true;
        transform.LookAt(player);
        //animal_Wander.enabled = false;
        //anim.enabled = false;
        agent.enabled = false;
        papan.GetComponent<Transform>().rotation = Quaternion.Euler(gameObject.transform.rotation.x, papan.GetComponent<Transform>().rotation.y, papan.GetComponent<Transform>().rotation.z);
    }

    public void CancelInteraktive()
    {
        isPlayerNear = false;
           clicked = false;
        //animal_Wander.enabled = true;
     //   anim.enabled = true;
        agent.enabled = true; 
    }
}
