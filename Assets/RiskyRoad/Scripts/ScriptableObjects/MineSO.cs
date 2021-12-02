using UnityEngine;

[CreateAssetMenu (fileName = "Mine", menuName = "Scriptable Objects/Mine")]
public class MineSO : ScriptableObject
{
    public Mine mine;
    public int steelAvailable = 2;
    public InventorySO inventory;
}
