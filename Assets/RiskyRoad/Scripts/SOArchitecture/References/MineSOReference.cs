using UnityEngine;

namespace ScriptableObjectArchitecture
{
	[System.Serializable]
	public sealed class MineSOReference : BaseReference<MineSO, MineSOVariable>
	{
	    public MineSOReference() : base() { }
	    public MineSOReference(MineSO value) : base(value) { }
	}
}