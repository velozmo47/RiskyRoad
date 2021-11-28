using UnityEngine;
using UnityEngine.Events;

namespace ScriptableObjectArchitecture
{
	[System.Serializable]
	public class TemporalBaseSOEvent : UnityEvent<TemporalBaseSO> { }

	[CreateAssetMenu(
	    fileName = "TemporalBaseSOVariable.asset",
	    menuName = SOArchitecture_Utility.VARIABLE_SUBMENU + "Custom/TemporalBaseSO",
	    order = 120)]
	public class TemporalBaseSOVariable : BaseVariable<TemporalBaseSO, TemporalBaseSOEvent>
	{
	}
}