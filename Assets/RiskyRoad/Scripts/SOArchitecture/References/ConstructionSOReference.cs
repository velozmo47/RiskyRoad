using UnityEngine;

namespace ScriptableObjectArchitecture
{
	[System.Serializable]
	public sealed class ConstructionSOReference : BaseReference<ConstructionSO, ConstructionSOVariable>
	{
	    public ConstructionSOReference() : base() { }
	    public ConstructionSOReference(ConstructionSO value) : base(value) { }
	}
}