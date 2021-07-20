using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PapanRotation : MonoBehaviour
{

    public Transform player;
    public float rotateKurangDari;
    public float rotateLebihDari;

    public float minY;
    public float maxY;
    public bool spawn = false;

    public Vector3 spawnMax; // nongol ke atas
    public Vector3 spawnMin; // kembali ke dasar

    public float speed = 10f;
    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Transform>();
        rotateLebihDari = transform.rotation.eulerAngles.y;
        rotateKurangDari = transform.rotation.eulerAngles.y + 180;

        spawnMin = transform.localPosition;
    }

    void Update()
    {
        spawn = GetComponentInParent<AnimalColliderToPlayer>().isPlayerNear;
        PapanRotate();
        PapanAnimate();
    }


    void PapanRotate()
    {
        if (transform.position.z < player.position.z)
        {
            transform.rotation = Quaternion.Euler(transform.rotation.x, rotateKurangDari, transform.rotation.z);
            

        }
        else
        {
            transform.rotation = Quaternion.Euler(transform.rotation.x, rotateLebihDari, transform.rotation.z);
        }
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
}
