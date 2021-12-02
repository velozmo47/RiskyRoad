using UnityEngine;

namespace ScriptableObjectArchitecture
{
	[AddComponentMenu(SOArchitecture_Utility.EVENT_LISTENER_SUBMENU + "MineSO")]
	public sealed class MineSOGameEventListener : BaseGameEventListener<MineSO, MineSOGameEvent, MineSOUnityEvent>
	{
	}
}