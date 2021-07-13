using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "Nama Hewan", menuName = "Hewan")]
public class HewanScriptable : ScriptableObject
{
    //attribute item
    [Header("Attribute Data Hewan")]
    public string namaHewan;
    public bool statusHewan;


    public void Awake()
    {
        statusHewan = getStatusHewan();
    }
    public void SetStatusHewan(bool value)
    {
        statusHewan = value;
    }
    public void ActivedHewan(int value)
    {
        GlobalVar.SaveDataHewan(namaHewan, value);
    }
    public bool getStatusHewan()
    {
      
        return GlobalVar.LoadDataHewan(namaHewan) == 0 ? false : true;
    }
}
