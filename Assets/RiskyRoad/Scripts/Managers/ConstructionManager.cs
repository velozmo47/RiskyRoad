using UnityEngine;
using ScriptableObjectArchitecture;
using UnityEngine.Events;
using System.Collections.Generic;

public class ConstructionManager : MonoBehaviour
{
    [SerializeField] Construction construction;
    [SerializeField] NodeConecter nodeConecter;
    [SerializeField] Transform nodeParent;

    [Header ("Actions")]
    [SerializeField] UnityEvent onConstructionStart;

    public void StartConstruction(ConstructionSO constructionRequest)
    {
        if (nodeConecter.isFull == false)
        {
            construction.StartConstruction(constructionRequest);

            onConstructionStart?.Invoke();
        }
    }

    public void ConstructionComplete(GameObject node)
    {
        var newNode = node.GetComponent<Node>();

        if (newNode)
        {
            newNode.transform.SetParent(nodeParent, true);

            newNode.InitializeNode(() => nodeConecter.ConnectNode(newNode));
        }
    }
}
