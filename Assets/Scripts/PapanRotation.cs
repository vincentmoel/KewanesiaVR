using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PapanRotation : MonoBehaviour
{

    public Transform player;
    public float papanHadapAwal;

    public float minY;
    public float maxY;
    public bool spawn = false;

    public Vector3 spawnMax; // nongol ke atas
    public Vector3 spawnMin; // kembali ke dasar

    public float speed = 10f;
    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Transform>();

        spawnMin = transform.localPosition;
    }

    void Update()
    {
        spawn = GetComponentInParent<AnimalColliderToPlayer>().isPlayerNear;
        PapanAnimate();
    }


    void PapanRotate()
    {

        //if (!spawn)
        //Debug.Log("Z PLAYEr :" +  player.position.z);
        //Debug.Log("Z PAPAN :" + transform.position.z);
        //transform.localRotation = Quaternion.Euler(0, papanHadapAwal, 0);
        //if (transform.position.z < player.position.z)
        //{
        //    transform.localRotation = Quaternion.Euler(0, papanHadapAwal, 0);
        //    Debug.Log("Muter 1");

        //}
        //else
        //{
        //    transform.localRotation = Quaternion.Euler(0, papanHadapAwal+180, 0);

        //}

        transform.localRotation = Quaternion.Euler(0, transform.localRotation.eulerAngles.y + 180, 0);
    }

    void PapanAnimate()
    {


        if (spawn && !GetComponentInParent<AnimalColliderToPlayer>().closePapan) // kalau player masuk ke area hewan. lakukan animasi muncul ke atas
        {
            transform.localPosition = Vector3.MoveTowards(transform.localPosition, spawnMax, Time.deltaTime * speed);
        }
        else
        {
            transform.localPosition = Vector3.MoveTowards(transform.localPosition, spawnMin, Time.deltaTime * speed);
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (!spawn)
                return;
            PapanRotate();
        }
    }
}
