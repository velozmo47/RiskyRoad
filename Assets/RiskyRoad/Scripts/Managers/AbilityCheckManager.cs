using UnityEngine;
using UnityEngine.Events;

public class AbilityCheckManager : MonoBehaviour
{
    [SerializeField] AbilityCheckBase abilityCheck;

    [Header ("Actions")]
    [SerializeField] UnityEvent onAbilityCheckStart;

    public void InitiateCheck(GameObject abilityCheck)
    {
        this.abilityCheck.StartCheck();

        onAbilityCheckStart?.Invoke();
    }
}
