using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolumeSetting : MonoBehaviour
{
    private float earVolume = 1f;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<AudioListener>();
    }

    // Update is called once per frame
    void Update()
    {
        AudioListener.volume = earVolume;
    }

    public void SetVolume(float vol) {
        earVolume = vol;
    }
}
