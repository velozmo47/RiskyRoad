using UnityEngine;
using ScriptableObjectArchitecture;
using UnityEngine.Events;

public class Construction : MonoBehaviour
{
    [SerializeField] AbilityCheckBase abilityCheck;
    [SerializeField] GameObjectEvent onConstructionComplete;
    [SerializeField] Transform sceneTransform;
    
    ConstructionSO constructionRequest;

    public void StartConstruction(ConstructionSO constructionRequest)
    {
        this.constructionRequest = constructionRequest;
        abilityCheck.StartCheck();
    }

    public void ConstructionComplete()
    {
        var node = Instantiate(constructionRequest.nodePrefab, sceneTransform, false);
        onConstructionComplete?.Invoke(node);
    }
}