using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshRenderer))]
public class FillableBar : MonoBehaviour
{
    [SerializeField] Material parentMaterial;
    [SerializeField] Color color = Color.white;
    Material materialInstance;
    MeshRenderer meshRenderer;

    void Awake ()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        parentMaterial = GetComponent<MeshRenderer>().sharedMaterial;

        materialInstance = new Material (parentMaterial);
        meshRenderer.material = materialInstance;

        SetColor(color);
    }

    private void SetColor(Color color)
    {
        materialInstance?.SetColor("_Color", color);
    }

    public float GetFillAmount()
    {
        return materialInstance.GetFloat("_FillAmount");
    }

    public void SetFillAmount (float value)
    {
        materialInstance?.SetFloat("_FillAmount", value);
    }
}
