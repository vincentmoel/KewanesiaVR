using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanahLookAt : MonoBehaviour
{
    public GameObject player;
    public int speed = 5;
    void Update()
    {
        //var targetRotation = Quaternion.LookRotation(player.transform.position - transform.position);

        //transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, speed * Time.deltaTime);

        transform.LookAt(player.transform);

        // Same as above, but setting the worldUp parameter to Vector3.left in this example turns the camera on its side
      //  transform.LookAt(player.transform, Vector3.left);
    }
}
