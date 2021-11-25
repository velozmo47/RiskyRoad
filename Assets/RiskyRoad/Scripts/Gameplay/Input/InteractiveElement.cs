using System;
using UnityEngine;
using UnityEngine.Events;

public class InteractiveElement : MonoBehaviour
{
    [SerializeField] UnityEvent onSelected;
    [SerializeField] UnityEvent onRaycastHoverStart;
    [SerializeField] UnityEvent onRaycastHoverEnd;

    void Start()
    {

    }

    public void Selected()
    {
        if (enabled == true)
            onSelected?.Invoke();
    }

    public void RayHoverStart()
    {
        if (enabled == true)
            onRaycastHoverStart?.Invoke();
    }

    internal void RayHoverEnded()
    {
        if (enabled == true)
            onRaycastHoverEnd?.Invoke();
    }
}