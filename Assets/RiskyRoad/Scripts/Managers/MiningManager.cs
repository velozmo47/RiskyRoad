using UnityEngine;
using UnityEngine.Events;

public class MiningManager : MonoBehaviour
{
    [SerializeField] Mine mine;

    [Header ("Actions")]
    [SerializeField] UnityEvent onMineStarted;

    public void StartMine(MineSO mineSO)
    {
        mine?.StartMine(mineSO);
        onMineStarted?.Invoke();
    }
}
