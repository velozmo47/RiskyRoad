using UnityEngine;
using UnityEngine.Events;
using ScriptableObjectArchitecture;

public class TemporalBase : MonoBehaviour
{
    GameStateSO currentState;    
    [SerializeField] EntryAnimationOnState[] entryAnimations;

    [Header ("Actions")]
    [SerializeField] StringEvent onBaseEntry;

    public void ChangeState(GameStateSO gameState)
    {
        currentState = gameState;
    }

    public void PlayEntryAnimationOnState()
    {
        for (int i = 0; i < entryAnimations.Length; i++)
        {
            if (currentState == entryAnimations[i].state)
            {
                onBaseEntry?.Invoke(entryAnimations[i].animationName);
            }
        }
    }

    [System.Serializable]
    public class EntryAnimationOnState
    {
        public GameStateSO state;
        public string animationName;
    }
}
