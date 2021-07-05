using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TesRaycast : MonoBehaviour
{

    // See Order of Execution for Event Functions for information on FixedUpdate() and Update() related to physics queries
    void FixedUpdate()
    {
        Vector3 fwd = transform.TransformDirection(Vector3.forward);

        if (Physics.Raycast(transform.position, fwd, 10))
        {

            Debug.Log("There is something in front of the object!");
        }
    }

}
