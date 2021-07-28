using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonHomeAnimate : MonoBehaviour
{

    public float yMax;
    public float yMin;

    bool naik = false;

    public Vector3 distanceNaik;
    public Vector3 distanceTurun;
    private void Start()
    {
        distanceNaik = new Vector3(transform.position.x, yMax, transform.position.z);
        distanceTurun = new Vector3(transform.position.x, yMin, transform.position.z);
    }
    public void Update()
    {

        if (Vector3.Distance(transform.position, distanceNaik) <= 0.1)
        {
            naik = false;
        }
        else if (Vector3.Distance(transform.position, distanceTurun) <= 0.1)
        {
            naik = true;
        }

        if (naik)
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x, yMax, transform.position.z), 1 * Time.deltaTime);

        }
        else
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x, yMin, transform.position.z), 1 * Time.deltaTime);


        transform.rotation = Quaternion.Euler(0, transform.rotation.eulerAngles.y + (100 * Time.deltaTime), 0);
    }
}
