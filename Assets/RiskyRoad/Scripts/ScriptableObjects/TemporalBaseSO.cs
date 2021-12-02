using UnityEngine;

[CreateAssetMenu(fileName = "TemporalBase", menuName = "Scriptable Objects/Temporal Base")]
public class TemporalBaseSO : ScriptableObject
{
    public TemporalBaseStateSO initialState;
    public bool mine;
}