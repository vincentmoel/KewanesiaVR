using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ClickSystem : MonoBehaviour
{
    public float range = 100f;
    Camera cam;

    private void Awake()
    {
        cam = GetComponent<Camera>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            RaycastHit[] hit;
            RaycastHit[] f = Physics.RaycastAll(transform.position, transform.forward, range);

            foreach (var a in f)
            {
                if (a.transform.GetComponent<Button>())
                {
                    a.transform.GetComponent<Button>().onClick.Invoke();
                }
                else
                {

                    ExecuteEvents.Execute<IPointerClickHandler>(a.transform.gameObject, new PointerEventData(EventSystem.current), ExecuteEvents.pointerClickHandler);
                    ExecuteEvents.Execute<IPointerDownHandler>(a.transform.gameObject, new PointerEventData(EventSystem.current), ExecuteEvents.pointerDownHandler);
                }
                
                if (a.transform.CompareTag("Home"))
                {
                    
                    a.transform.GetComponent<ChangeSceneInGame>().ChangeScene("MainMenu");
                }
            }
        }
    }
}
