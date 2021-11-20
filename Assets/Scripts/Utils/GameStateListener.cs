using System.Collections.Generic;
using UnityEngine;
using ScriptableObjectArchitecture;
using UnityEngine.Events;

public class GameStateListener : MonoBehaviour
{
    [Header("Listening to Events")]
    public GameStateSOGameEvent gameStateChangedEvent;

    [Header("Enabled & Disabled Shortcuts")]
    public MonoBehaviour[] components;
    public Collider[] colliders;
    public List<GameStateSO> enabledStates;
    public List<GameStateSO> disabledStates;

    [Header("Actions")]
    public StateActions[] stateActions;

    private void OnEnable()
    {
        this.gameStateChangedEvent.AddListener(GameStateChanged);
    }

    private void OnDisable()
    {
        this.gameStateChangedEvent.RemoveListener(GameStateChanged);
    }

    private void GameStateChanged(GameStateSO newGameState)
    {
        InvokeShortcuts(newGameState);
        InvokeActions(newGameState);
    }

    private void InvokeShortcuts(GameStateSO newGameState)
    {
        foreach(var component in components)
        {
            if (this.enabledStates.Contains(newGameState))
            {
                component.enabled = true;
            }
            if (this.disabledStates.Contains(newGameState))
            {
                component.enabled = false;
            }
        }

        foreach(var collider in colliders)
        {
            if (this.enabledStates.Contains(newGameState))
            {
                collider.enabled = true;
            }
            if (this.disabledStates.Contains(newGameState))
            {
                collider.enabled = false;
            }
        }
    }

    private void InvokeActions(GameStateSO newGameState)
    {
        for (int i = 0; i < stateActions.Length; i++)
        {
            if (newGameState == stateActions[i].gameState)
            {
                stateActions[i]?.onStateEvent?.Invoke();
            }
        }
    }

    [System.Serializable]
    public class StateActions {
        public GameStateSO gameState;
        public UnityEvent onStateEvent;
    }
}
