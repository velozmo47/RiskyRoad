using UnityEngine;
using UnityEngine.Events;

public class Node : MonoBehaviour
{
    [SerializeField] UnityEvent onNodeInitialized;

    public void InitializeNode()
    {
        onNodeInitialized?.Invoke();
    }
}
