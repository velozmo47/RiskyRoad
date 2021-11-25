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
    [SerializeField, Range (0, 10)]
    float size = 1;
    [SerializeField, Range (0, 50)]
    int pointsNumber;
    [SerializeField, Range(0f, 1f)]
    float fillAmount;

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
                Vector3 point = Circle(size, (float)i / (pointsNumber % totalPoints) * fillAmount);
                lineRenderer.SetPosition(i, point);
            }
        }
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

    public static Vector3 Circle(float size, float time)
    {
        float x = size * Mathf.Sin(Mathf.PI * 2 * time);
        float y = size * Mathf.Cos(Mathf.PI * 2 * time);

        return new Vector3 (x, y);
    }
}
