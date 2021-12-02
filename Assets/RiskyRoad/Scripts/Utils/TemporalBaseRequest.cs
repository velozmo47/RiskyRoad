using UnityEngine;
using ScriptableObjectArchitecture;

public class TemporalBaseRequest : MonoBehaviour
{
    [SerializeField] TemporalBaseSOGameEvent temporalBaseSOGameEvent;

    [Header ("Parameters")]
    [SerializeField] TemporalBaseSO temporalBaseSO;
    [SerializeField] TemporalBaseStateSO initialState;
    [SerializeField] MineStatus mineStatus = MineStatus.available;
    [SerializeField] bool mineAvailable = true;

    public void RequestTemporalBase()
    {
        temporalBaseSO.initialState = initialState;
        temporalBaseSO.mine = GetMineStatus();
        temporalBaseSOGameEvent?.Raise(temporalBaseSO);
    }

    public enum MineStatus { available, empty, random }

    bool GetMineStatus()
    {
        if (mineStatus == MineStatus.random)
        {
            return Random.Range(0, 1000) < 500;
        }
        else
        {
            return mineStatus == MineStatus.available;
        }
    }
}
