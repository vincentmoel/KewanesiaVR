using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeSetting : MonoBehaviour
{

    [SerializeField] private Slider slider;
    void Start()
    {
        GetComponent<AudioListener>();
        slider.value = GlobalVar.GetAudioVolume();
    }

    public void SetVolume(float vol) {
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
}
