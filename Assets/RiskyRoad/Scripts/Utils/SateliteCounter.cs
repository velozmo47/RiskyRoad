using UnityEngine;
using ScriptableObjectArchitecture;
using UnityEngine.UI;

public class SateliteCounter : MonoBehaviour
{
    [SerializeField] IntReference sateliteCounter;
    [SerializeField] IntReference maxSatellites;
    [SerializeField] Text text;
    
    void FixedUpdate()
    {
        if (text != null && sateliteCounter != null)
        {
            text.text = sateliteCounter.Value.ToString() + "/" + maxSatellites.Value.ToString();
        }
    }
}
