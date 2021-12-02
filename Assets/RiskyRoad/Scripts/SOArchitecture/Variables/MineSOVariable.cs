using UnityEngine;
using UnityEngine.Events;

namespace ScriptableObjectArchitecture
{
	[System.Serializable]
	public class MineSOEvent : UnityEvent<MineSO> { }

	[CreateAssetMenu(
	    fileName = "MineSOVariable.asset",
	    menuName = SOArchitecture_Utility.VARIABLE_SUBMENU + "Custom/MineSO",
	    order = 120)]
	public class MineSOVariable : BaseVariable<MineSO, MineSOEvent>
	{
	}
}