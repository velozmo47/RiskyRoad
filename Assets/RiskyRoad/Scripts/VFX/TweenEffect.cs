using UnityEngine;
using UnityEngine.Events;

public class TweenEffect : MonoBehaviour
{
    [SerializeField] TweenSettings normal;
    [SerializeField] TweenSettings highlighted;
    [SerializeField] TweenSettings selected;

    public void PlayTweenToHighlighted ()
    {
        highlighted.PlayTween(gameObject);
    }

    public void PlayTweenToNormal()
    {
        normal.PlayTween(gameObject);
    }

    public void PlayTweenToSelected()
    {
        selected.PlayTween(gameObject);
    }

    public void Reset()
    {
        transform.position = Vector3.zero;
        transform.rotation = Quaternion.identity;
        transform.localScale = Vector3.one;
    }

    [System.Serializable]
    public class TweenSettings
    {
        public float scale = 1.0f;
        public float time = 1.0f;
        public AnimationCurve animationCurve;
        public UnityEvent onTweenEnd;

        public void PlayTween(GameObject gameObject)
        {
            var tween = LeanTween.scale(gameObject, Vector3.one * scale, time);
            tween.setEase(animationCurve);
            tween.setOnComplete(() => onTweenEnd?.Invoke());
        }
    }
}
