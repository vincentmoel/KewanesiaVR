using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class GazeInteraction : MonoBehaviour
{
    public Image imgLoading;
    public float totalTime = 2;
    public int distanceOfRay = 10;

    private bool gvrStatus;
    private float gvrTimer;
    private RaycastHit _hit;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gvrStatus) {
            gvrTimer += Time.deltaTime;
            imgLoading.fillAmount = gvrTimer / totalTime;
        } 
    }

    public void GVRon() {
        gvrStatus = true;
    }

    public void GVROff() {
        gvrStatus = false;
        gvrTimer = 0;
        imgLoading.fillAmount = 0;
    }
}
