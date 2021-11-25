using UnityEngine;
using ScriptableObjectArchitecture;

[CreateAssetMenu (fileName = "GameManager", menuName = "Scriptable Objects/Game Manager")]
public class GameManagerSO : ScriptableObject
{
    [SerializeField]
    GameStateSOGameEvent gameStateChanged;

    GameStateSO currentState;
    GameStateSO previousState;

    public void SetGameState(GameStateSO gameState)
    {
        previousState = currentState == null ? gameState : currentState;
        currentState = gameState;

        gameStateChanged?.Raise(gameState);
    }

    public void RestorePreviousState()
    {
        currentState = previousState;
        gameStateChanged?.Raise(currentState);
    }
}
