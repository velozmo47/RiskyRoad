using System;
using UnityEngine;
using UnityEngine.Events;

public class Node : MonoBehaviour
{
    [SerializeField] Transform connection;
    [SerializeField] TweenEffect tween;

    NodeState state = NodeState.standby;

    public bool Initialized => state == NodeState.initialized;
    public Vector3 Connection => connection ? connection.position : transform.position;

    Action onNodeInitialized;

    // void OnEnable()
    // {
    //     if (state == NodeState.initializing)
    //     {
    //         InitializeNode(onNodeInitialized);
    //     }
    // }

    public void InitializeNode(Action onNodeInitialized = null)
    {
        if (state == NodeState.standby)
        {
            tween?.PlayTweenToNormal();
            this.onNodeInitialized += onNodeInitialized;
            state = NodeState.initializing;
            CompleteInitialization();
        }
    }

    public void CompleteInitialization()
    {
        state = NodeState.initialized;
        onNodeInitialized?.Invoke();
        onNodeInitialized = null;
    }

    public enum NodeState { standby, initializing, initialized }
}
