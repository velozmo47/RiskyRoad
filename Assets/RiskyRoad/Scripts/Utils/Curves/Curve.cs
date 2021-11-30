using UnityEngine;

[System.Serializable]
public class Curve
{
    [Range (0f, 20f)]
    public float size = 1;
    
    public float offset;
    CurveFunction[] curves = { Circle, SemiCircle, Line };

    public float Offset {
        set {
            offset = Mathf.Clamp(value, 0, 1);
        }
    }
    
    public CurveType curveType = CurveType.Circle;
    public enum CurveType { Circle, SemiCircle, Line }
    public delegate Vector3 CurveFunction(float size, float time, float offset);

    public Vector3 CurvePoint(float value)
    {
        return curves[(int) curveType](size, value, offset);
    }

    public Vector3 CurvePoint(float value, float offset)
    {
        return curves[(int) curveType](size, value, offset);
    }

    public static Vector3 Circle(float size, float time, float offset)
    {
        float x = size * Mathf.Sin(Mathf.PI * 2 * (time + offset));
        float y = size * Mathf.Cos(Mathf.PI * 2 * (time + offset));

        return new Vector3 (x, y);
    }

    public static Vector3 SemiCircle(float size, float time, float offset)
    {
        float x = size * Mathf.Sin(Mathf.PI * (time + offset));
        float y = size * Mathf.Cos(Mathf.PI * (time + offset));

        return new Vector3 (x, y);
    }

    public static Vector3 Line(float size, float time, float offset)
    {
        float x = size * time;
        float y = size * Mathf.Cos(Mathf.PI * (time + offset));

        return new Vector3 (x, y);
    }
}