using UnityEngine;
using UnityEngine.UI;

public class SteelCounter : MonoBehaviour
{
    [SerializeField] InventorySO inventorySO;
    [SerializeField] Text steelText;

    void FixedUpdate()
    {
        if (inventorySO != null && steelText != null)
        {
            steelText.text = inventorySO.steelAvailable.ToString();
        }
    }
}
