using UnityEngine;
using UnityEngine.Events;

namespace ScriptableObjectArchitecture
{
	[System.Serializable]
	public class ConstructionSOEvent : UnityEvent<ConstructionSO> { }

	[CreateAssetMenu(
	    fileName = "ConstructionSOVariable.asset",
	    menuName = SOArchitecture_Utility.VARIABLE_SUBMENU + "Custom/ConstructionSO",
	    order = 120)]
	public class ConstructionSOVariable : BaseVariable<ConstructionSO, ConstructionSOEvent>
	{
	}
}