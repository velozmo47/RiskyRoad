using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ScriptableObjectArchitecture;
using System;

public class ScreenInput : MonoBehaviour
{
    [SerializeField] LayerMask interactionLayers;
    [SerializeField] StringGameEvent debugGameEvent;
    [SerializeField] GameObject groundPointer;

    InteractiveElement interactiveElement;
    InteractiveElement InteractiveElement
    {
        get => interactiveElement;
        set {
            if (value != interactiveElement)
            {
                interactiveElement?.RayHoverEnded();
                interactiveElement = value;
                interactiveElement?.RayHoverStart();
            }
        }
    }
    bool objectDetected;

    void Update()
    {
        Vector2 screenPosition = GetScreenCenter();
        RaycastHit hit = CheckGroundWithRay(screenPosition);
        TriggerGroundResponse(hit);
        DrawGroundPointer(hit);

        if (Input.touchCount > 0 || Input.GetMouseButtonDown(0))
        {
            // screenPosition = Input.GetTouch(0).position;
            // screenPosition = Input.mousePosition;
            SelectOnInput(hit);
        }
    }

    private void TriggerGroundResponse(RaycastHit hit)
    {
        if (objectDetected)
        {
            InteractiveElement = hit.transform.GetComponent<InteractiveElement>();
        }
        else
        {
            InteractiveElement = null;
        }
    }

    private static Vector2 GetScreenCenter()
    {
        float midleWidth = Screen.width * 0.5f;
        float midleHeigth = Screen.height * 0.5f;

        Vector2 screenPosition = new Vector2(midleWidth, midleHeigth);
        return screenPosition;
    }

    void SelectOnInput(RaycastHit hit)
    {
        if (objectDetected)
        {
            debugGameEvent?.Raise(hit.transform.name);
            hit.transform.GetComponent<InteractiveElement>()?.Selected();
        }
    }

    RaycastHit CheckGroundWithRay(Vector2 screenPosition)
    {
        Ray ray = Camera.main.ScreenPointToRay(screenPosition);
        RaycastHit hit;

        objectDetected = Physics.Raycast(ray, out hit, Mathf.Infinity, interactionLayers);

        return hit;
    }

    public void DrawGroundPointer(RaycastHit hit)
    {
        groundPointer.SetActive(objectDetected);

        if (objectDetected)
        {
            groundPointer.transform.position = Vector3.Lerp(groundPointer.transform.position, hit.point, Time.deltaTime * 4);
            groundPointer.transform.rotation = Quaternion.FromToRotation(Vector3.up, hit.normal);
        }
    }

    void OnDisable()
    {
        InteractiveElement = null;
        groundPointer.SetActive(false);
    }
}
