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


        Quaternion tes = transform.localRotation;




        
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    private void LateUpdate()
    {
        transform.localRotation = vrCamera.localRotation;
        vrCamera.localRotation = Quaternion.Euler(0, 0, 0);
    }

}
