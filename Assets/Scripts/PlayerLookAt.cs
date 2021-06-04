using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// fungsi untuk membikin player melihat kedepan ketika ganti scene
/// </summary>
public class PlayerLookAt : MonoBehaviour
{
    public ChangeScene changeScene;

    public Transform playerLookTarget;
    public float speed = 5f;

    private void Update()
    {
        if (changeScene.startAnim)
        {
            var targetRotation = Quaternion.LookRotation(playerLookTarget.transform.position - transform.position);

            // Smoothly rotate towards the target point.
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, speed * Time.deltaTime);
        }
        else
            return;
    }
}
