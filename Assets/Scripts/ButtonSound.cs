using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSound : MonoBehaviour
{

    public AudioSource myFx;
    public AudioClip hoverClip;
    public AudioClip clickClip;

    public void Hover()
    {
        myFx.PlayOneShot(hoverClip);
    }

    public void Click()
    {
        myFx.PlayOneShot(clickClip);
    }
}
