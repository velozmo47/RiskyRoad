using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CurveCreator))]
public class FillableBar : MonoBehaviour
{
    [SerializeField]
    CurveCreator curve;

    public float GetFillAmount()
    {
        return curve.GetFillAmount();
    }

    public void SetFillAmount(float value)
    {
        curve?.SetFillAmount(value);
    }
}
