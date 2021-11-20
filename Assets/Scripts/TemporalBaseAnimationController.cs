using UnityEngine;
using UnityEngine.Events;
using ScriptableObjectArchitecture;

public class TemporalBaseAnimationController : MonoBehaviour
{
    [SerializeField] Animator animator;
    string currentTrigger;
    
    public void PlayEntryAnimation()
    {
        if (currentTrigger != null)
        {
            animator.SetTrigger(currentTrigger);
        }
    }

    public void TriggerAnimation(string trigger)
    {
        currentTrigger = trigger;
        animator.SetTrigger(trigger);
    }
}
