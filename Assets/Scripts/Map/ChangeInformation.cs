using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeInformation : MonoBehaviour
{
    public GameObject InfoObject;
    public bool Show = false;

    // Membuat Object Nyala
    public void ShowInfo() {
        if (!Show) {
            InfoObject.SetActive(true);
            Show = true;
        }
    }

    // Membuat Object Mati
    public void HideOther() {
        InfoObject.SetActive(false);
        Show = false;
    }
}
