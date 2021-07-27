using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogMinigame : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Dog"))
        {
            other.gameObject.SetActive(false);
        }
    }
}
