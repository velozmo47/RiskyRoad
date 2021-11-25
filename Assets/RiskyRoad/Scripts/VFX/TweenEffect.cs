using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TweenEffect : MonoBehaviour
{
    [SerializeField, Range (0f, 5f)]
    float highlightedScale = 1.5f,
    normalScale = 1f,
    highlightedTime = 0.5f,
    normalTime = 0.5f;

    [SerializeField]
    AnimationCurve animationCurve;

    void Start()
    {

    }

    public void PlayTweenToHighlighted ()
    {
        var tween = LeanTween.scale(gameObject, Vector3.one * highlightedScale, highlightedTime);
        tween.setEase(animationCurve);
    }

    public void PlayTweenToNormal()
    {
        var tween = LeanTween.scale(gameObject, Vector3.one * normalScale, normalTime);
        tween.setEase(animationCurve);
    }
}
