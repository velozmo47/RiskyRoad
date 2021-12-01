using System;
using UnityEngine;
using UnityEngine.Events;

public class Node : MonoBehaviour
{
    [SerializeField] Transform connection;

    public bool initialized;
    public bool Initialized => initialized;
    public Vector3 Connection => connection ? connection.position : transform.position;

    public void InitializeNode(Action onNodeInitialized = null)
    {
        initialized = true;
        onNodeInitialized?.Invoke();
    }
}
