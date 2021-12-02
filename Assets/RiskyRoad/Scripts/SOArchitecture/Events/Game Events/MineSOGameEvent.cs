using UnityEngine;

namespace ScriptableObjectArchitecture
{
	[System.Serializable]
	[CreateAssetMenu(
	    fileName = "MineSOGameEvent.asset",
	    menuName = SOArchitecture_Utility.GAME_EVENT + "Custom/MineSO",
	    order = 120)]
	public sealed class MineSOGameEvent : GameEventBase<MineSO>
	{
	}
}