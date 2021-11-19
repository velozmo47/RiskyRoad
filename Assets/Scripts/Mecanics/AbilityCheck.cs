using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class AbilityCheck : MonoBehaviour
{
    [Header ("Dependencies")]
    [SerializeField]
    Image scrollBarImage;
    [SerializeField]
    Image successBarImage;
    [SerializeField]
    RectTransform handle;

    [Header ("Parameters")]
    [SerializeField, Range (0f, 2f)]
    float speedHandleValue = 0.25f;
    [SerializeField, Range (0f, 2f)]
    float speedSuccessUpdate = 0.25f;
    [SerializeField, Range(0.1f, 1f)]
    float checkSafeZone = 0.1f;

    [SerializeField]
    UnityEventFloat onValueChange;
    [SerializeField]
    UnityEvent onSuccessfullCheck;
    [SerializeField]
    UnityEvent onSuccesAbilityCheck;

    float checkValue;
    float handleValue = 0f;
    float successValue = 0f;

    float HandleValue
    {
        get { return handleValue; }
        set
        {
            this.handleValue = value;
            onValueChange?.Invoke(this.handleValue);
        }
    }

    void OnEnable()
    {
        successBarImage.fillAmount = 0;
        successValue = 0f;
        RandomizeCheckZone();
    }

    void FixedUpdate()
    {
        UpdateProgressBar();
        UpdateSuccessBar();
        UpdateCheckZone();
    }

    private void UpdateSuccessBar()
    {
        successBarImage.fillAmount = Mathf.Clamp (successBarImage.fillAmount + Time.deltaTime * speedSuccessUpdate, 0, successValue);
        if (successBarImage.fillAmount >= 1)
        {
            onSuccesAbilityCheck?.Invoke();
        }
    }

    private void UpdateCheckZone()
    {
        if (scrollBarImage == null)
        {
            Debug.LogWarning("There's no scrollBarImage assigned");
            return;
        }

        scrollBarImage.fillAmount = checkSafeZone;
        Quaternion imageRotation = Quaternion.Euler(-Vector3.forward * 360 * (0.5f + checkValue - checkSafeZone * 0.5f));
        scrollBarImage.rectTransform.rotation = imageRotation;
    }

    public void RandomizeCheckZone()
    {
        checkValue = Random.value;
    }

    private void UpdateProgressBar()
    {
        HandleValue = Mathf.Repeat(HandleValue + speedHandleValue * Time.deltaTime, 1);
    }

    public void RotateHandle(float value)
    {
        Quaternion handleRotation = Quaternion.Euler(-Vector3.forward * 360 * value);

        if (handle != null)
        {
            handle.rotation = handleRotation;
        }
        else
        {
            Debug.LogWarning("There's no handle assigned");
        }
    }

    public void TestCheck()
    {
        float angle = Mathf.Abs(Mathf.DeltaAngle(360 * checkValue, 360 * HandleValue) / 360f);
        if (angle < checkSafeZone * 0.5f)
        {
            onSuccessfullCheck?.Invoke();
        }
    }

    public void FillSuccessBar(float value)
    {
        successValue = Mathf.Clamp(successValue + value, 0, 1);
    }

    [System.Serializable]
    public class UnityEventFloat : UnityEvent<float> {}
}
