using UnityEngine;

namespace ScriptableObjectArchitecture
{
	[System.Serializable]
	[CreateAssetMenu(
	    fileName = "TemporalBaseSOGameEvent.asset",
	    menuName = SOArchitecture_Utility.GAME_EVENT + "Custom/TemporalBaseSO",
	    order = 120)]
	public sealed class TemporalBaseSOGameEvent : GameEventBase<TemporalBaseSO>
	{
	}
}