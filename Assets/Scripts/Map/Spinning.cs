using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spinning : MonoBehaviour
{
    private bool test;

    private void Update() {
        if (test)
        gameObject.transform.Rotate(Vector3.up * 1);
    }

    public void Off(bool a) {
        test = a;
    }

}
