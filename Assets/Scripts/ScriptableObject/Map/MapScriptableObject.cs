using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="Nama Map",menuName ="Map")]
public class MapScriptableObject : ScriptableObject
{
    public string namaMap;
    public List<HewanScriptable> listHewan;
    public bool statusMap;

    public void CheckStatusMap()
    {
        foreach(var a in listHewan)
        {
            if (!a.statusHewan)
                return;
        }
        statusMap = true;
    }
}
