using UnityEngine;
using ScriptableObjectArchitecture;

public class EventRaiser : MonoBehaviour
{
    public void ActivateEvent(GameEvent gameEvent)
    {
        gameEvent?.Raise();
    }
}
