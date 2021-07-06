using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Events;
using UnityEngine.EventSystems;

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



    public Animator anim_papan;
    public bool isPlayerNear;


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            papan.ResetTampilanPapan();
            isPlayerNear = true;
            anim_papan.ResetTrigger("exit");
            anim_papan.SetTrigger("enter");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            papan.ResetTampilanPapan();
            isPlayerNear = false;
            anim_papan.ResetTrigger("enter");
            anim_papan.SetTrigger("exit");
        }
    }
}
