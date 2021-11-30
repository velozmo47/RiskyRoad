using UnityEngine;
using UnityEngine.Events;
using ScriptableObjectArchitecture;

public class AbilityCheckBase : MonoBehaviour
{
    [Header ("Dependencies")]
    [SerializeField]
    CurveCreator checkBar;
    [SerializeField]
    CurveCreator successBar;
    [SerializeField]
    GameObject handle;
    [SerializeField]
    float fillSuccessAmount = 0.34f;

    [Header ("Parameters")]
    [SerializeField, Range (0f, 2f)]
    float speedHandleValue = 0.25f;
    [SerializeField, Range (0f, 2f)]
    float speedSuccessUpdate = 0.25f;
    [SerializeField, Range(0.1f, 1f)]
    float checkSafeZone = 0.1f;

    [Header ("Actions")]
    [SerializeField]
    FloatEvent onValueChange;
    [SerializeField]
    UnityEvent onSuccessfullCheck;
    [SerializeField]
    UnityEvent onSuccesAbilityCheck;
    
    public float checkValue;
    float handleValue = 0f;
    float successValue = 0f;

    float HandleValue
    {
        get { return handleValue; }
        set
        {
            this.handleValue = value;
            RotateHandle(this.handleValue);
            onValueChange?.Invoke(this.handleValue);
        }
    }

    void OnEnable()
    {
        checkBar?.SetFillAmount(0);
        successBar?.SetFillAmount(0);
        successValue = 0f;
        RandomizeCheckZone();
    }

    void FixedUpdate()
    {
        UpdateHandle();
        UpdateSuccessBar();
        UpdateCheckZone();
    }

    private void UpdateSuccessBar()
    {
        successBar?.SetFillAmount(
            Mathf.Clamp (successBar.GetFillAmount() + Time.deltaTime * speedSuccessUpdate, 0, successValue)
        );

        if (successBar?.GetFillAmount() >= 1)
        {
            onSuccesAbilityCheck?.Invoke();
        }
    }

    private void UpdateCheckZone()
    {
        if (checkBar == null) { return; }

        checkBar.SetFillAmount(checkSafeZone);
        checkBar.SetCurveOffset(checkValue - checkSafeZone * 0.5f);
    }

    public void RandomizeCheckZone()
    {
        checkValue = Random.value;
    }

    private void UpdateHandle()
    {
        HandleValue = Mathf.Repeat(HandleValue + speedHandleValue * Time.deltaTime, 1);
    }

    public void RotateHandle(float value)
    {
        if (handle == null) { return; }
        
        handle.transform.position = checkBar.GetPoint(handleValue);
    }

    public void TestCheck()
    {
        float angle = Mathf.Abs(Mathf.DeltaAngle(360 * checkValue, 360 * HandleValue) / 360f);
        if (angle < checkSafeZone * 0.5f)
        {
            FillSuccessBar(fillSuccessAmount);
            RandomizeCheckZone();
            onSuccessfullCheck?.Invoke();
        }
    }

    public void FillSuccessBar(float value)
    {
        successValue = Mathf.Clamp(successValue + value, 0, 1);
    }
}
