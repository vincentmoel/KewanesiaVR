using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shark : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] private float eulerAngleX;
    [SerializeField] private float eulerAngleY;
    [SerializeField] private float eulerAngleZ;

    public Camera camera;

    private bool turnLeft = false;
    private bool turnRight = false;
    private bool dive = false;
    private bool climb = false;

    public float speed = 5f;
    public float turnSpeed = 0.5f;

    // Update is called once per frame
    void Update()
    {
        GetAngles();
        GetTurn();
        Turn();
        ForwardMove();
    }

    private void ForwardMove()
    {
        transform.position += transform.forward * (Time.deltaTime * speed);
    }

    private void GetAngles()
    {
        eulerAngleX = camera.transform.localEulerAngles.x;
        eulerAngleY = camera.transform.localEulerAngles.y;
        eulerAngleZ = camera.transform.localEulerAngles.z;
    }

    private void Turn()
    {
        if (turnLeft)
        {
            eulerAngleY = eulerAngleY + (Time.deltaTime * speed);
            transform.eulerAngles = new Vector3(eulerAngleX, eulerAngleY, eulerAngleZ);
        }

        if (turnRight)
        {
            eulerAngleY = eulerAngleY - (Time.deltaTime * speed);
            transform.eulerAngles = new Vector3(eulerAngleX, eulerAngleY, eulerAngleZ);
        }

        if (dive)
        {
            eulerAngleX = eulerAngleX + turnSpeed;
            transform.eulerAngles = new Vector3(eulerAngleX, eulerAngleY, eulerAngleZ);
        }

        if (climb)
        {
            eulerAngleX = eulerAngleX + turnSpeed;
            transform.eulerAngles = new Vector3(eulerAngleX, eulerAngleY, eulerAngleZ);
        }
    }

    private void GetTurn()
    {
        if (eulerAngleX < 0) climb = true;
        if (eulerAngleX > 0) dive = true;
        if (eulerAngleY < 0) turnRight = true;
        if (eulerAngleY > 0) turnLeft = true;
    }
}
