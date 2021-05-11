using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalVar
{
    #region Audio Volume Save
    public static void SetAudioVolume(float value)
    {
        PlayerPrefs.SetFloat("AudioVolume", value);
    }
    public static float GetAudioVolume()
    {
        return PlayerPrefs.GetFloat("AudioVolume",1);
    }
    #endregion

    #region Save & Load Data Hewan
    public static void SaveDataHewan(string namaHewan,int value)
    {
        PlayerPrefs.SetInt(namaHewan, value);
    }
    public static int LoadDataHewan(string namaHewan)
    {
        return PlayerPrefs.GetInt(namaHewan, 0);
    }
    #endregion



}
