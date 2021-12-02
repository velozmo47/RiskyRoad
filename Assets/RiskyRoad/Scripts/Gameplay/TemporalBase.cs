using UnityEngine;
using UnityEngine.Events;
using ScriptableObjectArchitecture;

public class TemporalBase : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] TweenEffect tween;
    [SerializeField] GameObject mineButton;
    
    [Header ("Actions")]
    [SerializeField] OnStateChangeEvent[] onStateChangeEvents;

    TemporalBaseStateSO currentState;
    TemporalBaseSO temporalBaseSO;

    void OnEnable()
    {
        TriggerAnimation(currentState);
    }

    public void StartTemporalBase(TemporalBaseSO temporalBaseSO)
    {
        tween.transform.localScale = Vector3.one;
        EnterState(temporalBaseSO.initialState);
        this.temporalBaseSO = temporalBaseSO;
    }

    public void SetupMine()
    {
        if (temporalBaseSO == null) { return; }
        mineButton?.SetActive(temporalBaseSO.mine);
    }

    public void TriggerAnimation(TemporalBaseStateSO state)
    {
        if (state == null)
            return;
            
        animator?.SetTrigger(state.name);
    }

    public void EnterState(TemporalBaseStateSO state)
    {
        if (state == null)
            return;

        foreach(var stateChange in onStateChangeEvents)
        {
            if (stateChange.state.Equals(state))
            {
                currentState = state;
                TriggerAnimation(state);
                stateChange?._event?.Invoke();
                return;
            }
        }
    }

    [System.Serializable]
    public class OnStateChangeEvent
    {
        public TemporalBaseStateSO state;
        public UnityEvent _event;
    }
}
