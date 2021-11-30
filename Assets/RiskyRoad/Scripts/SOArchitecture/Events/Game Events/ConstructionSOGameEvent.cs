using UnityEngine;

namespace ScriptableObjectArchitecture
{
	[System.Serializable]
	[CreateAssetMenu(
	    fileName = "ConstructionSOGameEvent.asset",
	    menuName = SOArchitecture_Utility.GAME_EVENT + "Custom/ConstructionSO",
	    order = 120)]
	public sealed class ConstructionSOGameEvent : GameEventBase<ConstructionSO>
	{
	}
}