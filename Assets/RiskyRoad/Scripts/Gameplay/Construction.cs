using UnityEngine;
using ScriptableObjectArchitecture;
using UnityEngine.Events;

public class Construction : MonoBehaviour
{
    [SerializeField] AbilityCheckBase abilityCheck;

    [Header ("Actions")]
    [SerializeField] GameObjectEvent onConstructionComplete;
    
    ConstructionSO constructionRequest;

    public void StartConstruction(ConstructionSO constructionRequest)
    {
        this.constructionRequest = constructionRequest;
        abilityCheck.StartCheck();
    }

    public void ConstructionComplete()
    {
        var node = Instantiate(constructionRequest.nodePrefab, transform, false);
        onConstructionComplete?.Invoke(node);
    }
}