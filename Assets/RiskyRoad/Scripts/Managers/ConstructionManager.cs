using UnityEngine;
using ScriptableObjectArchitecture;
using UnityEngine.Events;
using System.Collections.Generic;

public class ConstructionManager : MonoBehaviour
{
    [SerializeField] Construction construction;
    [SerializeField] Transform nodeParent;

    [Header ("Actions")]
    [SerializeField] UnityEvent onConstructionStart;
    
    List<Node> nodes = new List<Node>();

    public void StartConstruction(ConstructionSO constructionRequest)
    {
        construction.StartConstruction(constructionRequest);

        onConstructionStart?.Invoke();
    }

    public void ConstructionComplete(GameObject node)
    {
        var newNode = node.GetComponent<Node>();

        if (newNode)
        {
            newNode.transform.SetParent(nodeParent, true);
            nodes.Add(newNode);
            newNode.InitializeNode();
        }
    }
}
