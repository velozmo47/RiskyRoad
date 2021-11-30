using UnityEngine;

namespace ScriptableObjectArchitecture
{
	[AddComponentMenu(SOArchitecture_Utility.EVENT_LISTENER_SUBMENU + "ConstructionSO")]
	public sealed class ConstructionSOGameEventListener : BaseGameEventListener<ConstructionSO, ConstructionSOGameEvent, ConstructionSOUnityEvent>
	{
	}
}