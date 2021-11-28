using UnityEngine;

namespace ScriptableObjectArchitecture
{
	[AddComponentMenu(SOArchitecture_Utility.EVENT_LISTENER_SUBMENU + "TemporalBaseSO")]
	public sealed class TemporalBaseSOGameEventListener : BaseGameEventListener<TemporalBaseSO, TemporalBaseSOGameEvent, TemporalBaseSOUnityEvent>
	{
	}
}