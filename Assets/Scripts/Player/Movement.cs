using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public Transform vrCamera;
    public float speed = 3.0f;
    public float toggleAngle = 30.0f;
    public bool move;
    private CharacterController cc;
    private int count;

    // Untuk mengambil object Character Controller
    void Start() {
        cc = GetComponent<CharacterController>();
    }

    void Update() {

        // Ketika sudut pandangan lebih dari 30 derajat dan tidak lebih dari 90 derajat maka akan jalan
        if (vrCamera.eulerAngles.x >= toggleAngle && vrCamera.eulerAngles.x < 90.0f) {
            move = true;
        } else {
            move = false;
        }

        // Saat jalan bernilai betul maka player akan bergerak maju
        if (move) {
            Vector3 forward = vrCamera.TransformDirection(Vector3.forward);
            cc.SimpleMove(forward * speed);
        }
    }
}
