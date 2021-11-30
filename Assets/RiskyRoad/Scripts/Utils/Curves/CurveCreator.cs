using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

[RequireComponent (typeof(LineRenderer)), ExecuteInEditMode]
public class CurveCreator : MonoBehaviour
{
    [SerializeField]
    LineRenderer lineRenderer;
    [SerializeField, Range (0, 50)]
    int pointsNumber;
    [SerializeField, Range(0f, 1f)]
    float fillAmount;
    [SerializeField]
    Curve curve;

    public Curve Curve => curve;

    void Update()
    {
#if UNITY_EDITOR
        DrawCurve();
#endif
    }

    public void DrawCurve()
    {
        int totalPoints = pointsNumber + 1;

        if (pointsNumber > 0 && lineRenderer != null)
        {
            lineRenderer.positionCount = totalPoints;

            for (int i = 0; i < totalPoints; i++)
            {
                Vector3 point = curve.CurvePoint((float)i / (pointsNumber % totalPoints) * fillAmount);
                lineRenderer.SetPosition(i, point);
            }
        }
    }

    public Vector3 GetPoint(float value, float offset = 0)
    {
        return transform.TransformPoint(Curve.CurvePoint(value, offset));
    }

    public void SetCurveOffset(float offset)
    {
        Curve.Offset = offset;
    }

    public void SetFillAmount(float value)
    {
        fillAmount = value;
        DrawCurve();
    }

    public float GetFillAmount()
    {
        return fillAmount;
    }
}
