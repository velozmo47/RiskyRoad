using UnityEngine;
using ScriptableObjectArchitecture;
using UnityEngine.Events;

public class Construction : MonoBehaviour
{
    [SerializeField] AbilityCheckBase abilityCheck;
    [SerializeField] TweenEffect tweenEffect;

    [Header ("Actions")]
    [SerializeField] GameObjectEvent onConstructionComplete;
    
    ConstructionSO constructionRequest;

    public void StartConstruction(ConstructionSO constructionRequest)
    {
        gameObject.SetActive(true);
        tweenEffect.transform.localScale = Vector3.zero;
        this.constructionRequest = constructionRequest;
        abilityCheck.gameObject.SetActive(false);
        tweenEffect.PlayTweenToNormal();
    }

    public void ConstructionComplete()
    {
        var node = Instantiate(constructionRequest.nodePrefab, transform, false);
        onConstructionComplete?.Invoke(node);
        gameObject.SetActive(false);
    }
}