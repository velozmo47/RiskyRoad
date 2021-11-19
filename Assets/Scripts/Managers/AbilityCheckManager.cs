using UnityEngine;
using UnityEngine.Events;

public class AbilityCheckManager : MonoBehaviour
{
    [SerializeField] Canvas canvas;

    [Header ("Actions")]
    [SerializeField] UnityEvent onAbilityCheckStart;

    public void InitiateCheck(GameObject abilityCheck)
    {
        onAbilityCheckStart?.Invoke();
        
        // Instantiate(abilityCheck, canvas.transform.position, canvas.transform.rotation, canvas.transform);
    }
}
