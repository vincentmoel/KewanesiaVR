using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PapanRotation : MonoBehaviour
{

    public Transform player;
    public float rotateKurangDari;
    public float rotateLebihDari;


    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Transform>();



        rotateLebihDari = transform.rotation.eulerAngles.y;
        rotateKurangDari = transform.rotation.eulerAngles.y + 180 ;
    }

    void Update()
    {

        PapanRotate();
    }


    void PapanRotate()
    {
         if(transform.position.z < player.position.z)
        {
            transform.rotation = Quaternion.Euler(transform.rotation.x, rotateKurangDari, transform.rotation.z);
            
        }
        else
        {
            transform.rotation = Quaternion.Euler(transform.rotation.x, rotateLebihDari, transform.rotation.z);
        }
    }
}
