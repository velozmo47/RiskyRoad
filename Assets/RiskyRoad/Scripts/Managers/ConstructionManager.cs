using UnityEngine;
using ScriptableObjectArchitecture;

public class ConstructionManager : MonoBehaviour
{
    public Construction construction;

    public void StartConstruction(ConstructionSO constructionRequest)
    {
        construction.StartConstruction(constructionRequest);
    }
}
