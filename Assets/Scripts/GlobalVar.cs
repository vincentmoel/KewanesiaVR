﻿using System.Collections;
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
        return PlayerPrefs.GetFloat("AudioVolume", 1);
    }
    #endregion

    #region Save & Load Data Hewan
    public static void SaveDataHewan(string namaHewan, int value)
    {
        PlayerPrefs.SetInt(namaHewan, value);
    }
    public static int LoadDataHewan(string namaHewan)
    {
        return PlayerPrefs.GetInt(namaHewan, 0);
    }
    #endregion

    public static void SetSpeedMovement(float value)
    {
        PlayerPrefs.SetFloat("SpeedMovement", value);
    }

    public static float GetSpeedMovement()
    {
        return PlayerPrefs.GetFloat("SpeedMovement", 1);
    }

    //save load highscore hiu
    public static void SetHighScoreHiu(int value)
    {
        PlayerPrefs.SetInt("HighScoreHiu", value);
    }

    public static int GetHighScoreHiu()
    {
        return PlayerPrefs.GetInt("HighScoreHiu", 0);
    }

    public static float GetTimeDog()
    {
        return PlayerPrefs.GetFloat("ScoreTimer", 99999f);
    }
    
    public static void SetTimeDog(float value)
    {
        PlayerPrefs.SetFloat("ScoreTimer", value);
    }
}
