using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniGame3Movement : MonoBehaviour
{
    public Transform vrCamera;
    public float speed = 10.0f;
    public Rigidbody rb;

    public Animator sharkAnim;
    void Start()
    {
        sharkAnim.SetBool("isSwimming", true);
        
    }

    // Update is called once per frame
    void Update()
    {
        

        //transform.Translate(forward * speed * Time.deltaTime);


        //Vector3 vector3 = new Vector3();
        //vector3.x = vrCamera.localRotation.x;
        //vector3.y = vrCamera.localRotation.y;
        //vector3.z = vrCamera.localScale.z;
        //transform.Rotate(vector3);

        transform.localRotation = Quaternion.Euler(vrCamera.localRotation.eulerAngles.x, vrCamera.localRotation.eulerAngles.y, vrCamera.localRotation.eulerAngles.z);

        vrCamera.localRotation = Quaternion.Euler(Vector3.zero);


        //Vector3 forward = transform.TransformDirection(Vector3.forward);
        //rb.velocity = forward * speed;
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }
}
