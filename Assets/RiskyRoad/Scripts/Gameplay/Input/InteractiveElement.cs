using UnityEngine;
using UnityEngine.Events;
using ScriptableObjectArchitecture;

public class InteractiveElement : MonoBehaviour
{
    [SerializeField] Vector3Event onSelected;
    [SerializeField] UnityEvent onRaycastHoverStart;
    [SerializeField] UnityEvent onRaycastHoverEnd;

    void Start()
    {

    }

    public void Selected(Vector3 position)
    {
        if (enabled == true)
            onSelected?.Invoke(position);
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