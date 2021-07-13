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


    //set animator button
    public string path_Animation;
    public Animator anim_btnCiri;
    public Animator anim_btnTempatTinggal;
    public Animator anim_btnMakanan;
    public Animator anim_btnGambar;

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
            anim_btnCiri.runtimeAnimatorController = Resources.Load(path_Animation) as RuntimeAnimatorController;
            CheckStatusActive();
        }

    }

    public void DoneTempatTinggal()
    {
        if (!tempatTinggal)
        {
            tempatTinggal = true;
            SpawnConfety();
            anim_btnTempatTinggal.runtimeAnimatorController = Resources.Load(path_Animation) as RuntimeAnimatorController;
            CheckStatusActive();
        }
    }

    public void DoneMakanan()
    {
        if (!makanan)
        {
            makanan = true;
            SpawnConfety();
            anim_btnMakanan.runtimeAnimatorController = Resources.Load(path_Animation) as RuntimeAnimatorController;
            CheckStatusActive();
        }
    }

    public void DoneGambar()
    {
        if (!gambar)
        {
            gambar = true;
            SpawnConfety();
            anim_btnGambar.runtimeAnimatorController = Resources.Load(path_Animation) as RuntimeAnimatorController;
            CheckStatusActive();
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
        }
    }

    void TurnOnAllButton() // digunakan kalau hewan sudah terbuka
    {
        ciri = true;
        tempatTinggal = true;
        makanan = true;
        gambar = true;

        anim_btnGambar.runtimeAnimatorController = Resources.Load(path_Animation) as RuntimeAnimatorController;
        anim_btnCiri.runtimeAnimatorController = Resources.Load(path_Animation) as RuntimeAnimatorController;
        anim_btnMakanan.runtimeAnimatorController = Resources.Load(path_Animation) as RuntimeAnimatorController;
        anim_btnTempatTinggal.runtimeAnimatorController = Resources.Load(path_Animation) as RuntimeAnimatorController;

        animal_data.SetStatusHewan(true);
    }
}
