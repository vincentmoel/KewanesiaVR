// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
//
// public class Movement : MonoBehaviour
// {
//     public Transform vrCamera;
//     public float speed = 5.0f;
//     public float toggleAngle = 30.0f;
//     public bool move;
//     private CharacterController cc;
//     private int count;
//
//     // Untuk mengambil object Character Controller
//     void Start() {
//         cc = GetComponent<CharacterController>();
//         speed *= GlobalVar.GetSpeedMovement();
//     }
//
//     void Update() {
//
//         // Ketika sudut pandangan lebih dari 30 derajat dan tidak lebih dari 90 derajat maka akan jalan
//         if (vrCamera.eulerAngles.x >= toggleAngle && vrCamera.eulerAngles.x < 90.0f) {
//             move = true;
//         } else {
//             move = false;
//         } 
//
//         // Saat jalan bernilai betul maka player akan bergerak maju
//         if (move) {
//             Vector3 forward = vrCamera.TransformDirection(Vector3.forward);
//             cc.SimpleMove(forward * speed);
//         }
//     }
// }

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public Transform vrCamera;
    public float speed = 5.0f;
    public float toggleAngle = 30.0f;
    public bool move;
    private CharacterController cc;
    private int count;

    private float mouseSensitive = 100f;

    float xRotation = 0f;

    public float gravitiy = -9.18f;
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    Vector3 velocity;
    bool isGrounded;
    void Start() {
        cc = GetComponent<CharacterController>();
        speed *= GlobalVar.GetSpeedMovement();

        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update() {

        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if(isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float mouseX = Input.GetAxis("Mouse X") * Time.deltaTime * mouseSensitive;
        float mouseY = Input.GetAxis("Mouse Y") * Time.deltaTime * mouseSensitive;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
        vrCamera.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        transform.Rotate(Vector3.up * mouseX);

        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        cc.Move(move * (speed * Time.deltaTime));

        velocity.y += gravitiy * Time.deltaTime;
        cc.Move(velocity * Time.deltaTime);

    }

    public void NormalMovement()
    {
        speed = 5;
    }
}