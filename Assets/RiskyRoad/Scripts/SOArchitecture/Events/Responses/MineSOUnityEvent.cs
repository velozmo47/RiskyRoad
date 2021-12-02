using UnityEngine;
using UnityEngine.Events;

namespace ScriptableObjectArchitecture
{
	[System.Serializable]
	public sealed class MineSOUnityEvent : UnityEvent<MineSO>
	{
	}
}