using UnityEngine;
using UnityEngine.Events;
using ScriptableObjectArchitecture;
using UnityEngine.EventSystems;

public class InteractiveElement : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] Vector3Event onSelected;
    [SerializeField] UnityEvent onRaycastHoverStart;
    [SerializeField] UnityEvent onRaycastHoverEnd;

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

    public void OnPointerClick(PointerEventData eventData)
    {
        Selected(eventData.pressPosition);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        RayHoverStart();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        RayHoverEnded();
    }
}