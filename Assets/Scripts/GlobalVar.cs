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
}
