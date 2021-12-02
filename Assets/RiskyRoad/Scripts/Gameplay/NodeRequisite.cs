using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class NodeRequisite : MonoBehaviour
{
    [SerializeField] SpriteRenderer spriteRenderer;
    [SerializeField] Color complete = Color.green;
    [SerializeField] Color incomplete = Color.red;
    [SerializeField] InventorySO inventory;
    [SerializeField] int steelRequiered = 2;

    [SerializeField] UnityEvent onRequirementFullfiled;

    void OnEnable()
    {
        if (inventory.steelAvailable >= steelRequiered)
        {
            spriteRenderer.color = complete;
        }
        else
        {
            spriteRenderer.color = incomplete;
        }
    }

    public void TestRequierements()
    {
        if (inventory.steelAvailable >= steelRequiered)
        {
            inventory.steelAvailable -= steelRequiered;
            onRequirementFullfiled?.Invoke();
        }
    }
}
