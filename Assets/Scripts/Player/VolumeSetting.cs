using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class VolumeSetting : MonoBehaviour
{

    [SerializeField] private Slider slider;

    [SerializeField] private TextMeshProUGUI txtSpeed;
    void Start()
    {
        txtSpeed.text = ((GlobalVar.GetSpeedMovement() - 1) / 0.25 + 1).ToString() + "x";
        GetComponent<AudioListener>();
        slider.value = GlobalVar.GetAudioVolume();
    }

    public void SetVolume(float vol)
    {
        GlobalVar.SetAudioVolume(vol);
        AudioListener.volume = GlobalVar.GetAudioVolume();
    }

    public void UpVolume()
    {
        slider.value += 0.1f;
        SetVolume(slider.value);
    }

    public void DownVolume()
    {
        slider.value -= 0.1f;
        SetVolume(slider.value);
    }


    /// <summary>
    /// fungsi menambah speed
    /// </summary>
    public void UpSpeed()
    {
        if (GlobalVar.GetSpeedMovement() >= 1.75f)
            return;
        float plus = 0.25f;
        float speed = GlobalVar.GetSpeedMovement() + plus;
        SetSpeed(speed);
    }

    /// <summary>
    /// fungsi menurunkan speed
    /// </summary>
    public void DownSpeed()
    {
        if (GlobalVar.GetSpeedMovement() <= 1)
            return;
        float minus = 0.25f;
        float speed = GlobalVar.GetSpeedMovement() - minus;
        SetSpeed(speed);
    }

    public void SetSpeed(float speed)
    {
        GlobalVar.SetSpeedMovement(speed);
        txtSpeed.text = ((GlobalVar.GetSpeedMovement() - 1) / 0.25 + 1).ToString() + "x";
    }
}
