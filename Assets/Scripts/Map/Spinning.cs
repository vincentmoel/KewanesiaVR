using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spinning : MonoBehaviour
{

    private void Update() {
        gameObject.transform.Rotate(Vector3.up * 1);
    }

}
