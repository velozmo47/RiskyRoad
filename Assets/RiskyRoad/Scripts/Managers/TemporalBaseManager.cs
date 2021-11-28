using UnityEngine;
using UnityEngine.Events;
using ScriptableObjectArchitecture;

public class TemporalBaseManager : MonoBehaviour
{
    [SerializeField] TemporalBase baseController;

    [Header ("Actions")]
    [SerializeField] UnityEvent onBaseCreated;
    
    public void CreateTemporalBase(TemporalBaseSO temporalBaseRequest)
    {
        baseController.EnterState(temporalBaseRequest.initialState);
        onBaseCreated?.Invoke();
    }
}
