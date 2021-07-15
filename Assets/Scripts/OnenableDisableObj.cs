using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class OnenableDisableObj : MonoBehaviour
{
    public UnityEvent onEnableFunc;
    public UnityEvent onDisableFunc;

    private void OnEnable()
    {
        onEnableFunc.Invoke();
    }

    private void OnDisable()
    {
        onDisableFunc.Invoke();
    }
}
