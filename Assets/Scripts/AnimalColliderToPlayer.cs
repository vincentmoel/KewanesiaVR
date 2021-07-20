using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class AnimalColliderToPlayer : MonoBehaviour
{
    [System.Serializable]
    public class PapanSetting
    {

        [Header("Event untuk reset papan ketika papan masuk")]
        public UnityEvent papanEvent;


        public void ResetTampilanPapan()
        {
            papanEvent.Invoke();
            
        }
    }
    public PapanSetting papan;

    //data hewan
    public HewanScriptable animal_data;


    //public Animator anim_papan;
    public bool isPlayerNear;
    public bool closePapan;

    public GameObject confetyPrefab;
    public GameObject obj_papan;
    // pengecekan status yang sudah keisi
    public bool ciri;
    public bool tempatTinggal;
    public bool makanan;
    public bool gambar;

    public GameObject obj_ciriDone;
    public GameObject obj_tempatTinggalDone;
    public GameObject obj_makananDone;
    public GameObject obj_gambarDone;


    public bool miniGame;
    public GameObject btn_maingames;
    private void Awake()
    {
        if (animal_data.getStatusHewan())
        {
            TurnOnAllButton();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            papan.ResetTampilanPapan();
            isPlayerNear = true;
            closePapan = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            papan.ResetTampilanPapan();
            isPlayerNear = false;
            closePapan = true;
        }
    }

    public void ClosePapan()
    {
        closePapan = true;
    }

    public void DoneCiri()
    {
        if (!ciri)
        {
            ciri = true;
            SpawnConfety();
            CheckStatusActive();
            obj_ciriDone.SetActive(true);
        }

    }

    public void DoneTempatTinggal()
    {
        if (!tempatTinggal)
        {
            tempatTinggal = true;
            SpawnConfety();
            CheckStatusActive();
            obj_tempatTinggalDone.SetActive(true);
        }
    }

    public void DoneMakanan()
    {
        if (!makanan)
        {
            makanan = true;
            SpawnConfety();
            CheckStatusActive();
            obj_makananDone.SetActive(true);
        }
    }

    public void DoneGambar()
    {
        if (!gambar)
        {
            gambar = true;
            SpawnConfety();
            CheckStatusActive();
            obj_gambarDone.SetActive(true);
        }
    }

    void SpawnConfety()
    {
        GameObject spawnConfeti = Instantiate(confetyPrefab, obj_papan.transform);
        Destroy(spawnConfeti, 4f);
    }

    void CheckStatusActive() // check, data apa yg masih belum terisi
    {
        bool[] checkStatus = new bool[4];
        checkStatus[0] = ciri;
        checkStatus[1] = makanan;
        checkStatus[2] = tempatTinggal;
        checkStatus[3] = gambar;

        bool allClear = true;
        foreach(var a in checkStatus)
        {
            if(!a)
            {
                allClear = false;
                break;
            }
        }

        if (allClear)
        {
            animal_data.ActivedHewan(1);
            animal_data.SetStatusHewan(true);
            if (miniGame)
                btn_maingames.SetActive(true);
                
            

        }
    }

    void TurnOnAllButton() // digunakan kalau hewan sudah terbuka
    {
        ciri = true;
        tempatTinggal = true;
        makanan = true;
        gambar = true;

        obj_ciriDone.SetActive(true);
        obj_tempatTinggalDone.SetActive(true);
        obj_makananDone.SetActive(true);
        obj_gambarDone.SetActive(true);

        animal_data.SetStatusHewan(true);
        if (miniGame)
            btn_maingames.SetActive(true);

    }
}
