using UnityEngine;

namespace ScriptableObjectArchitecture
{
	[System.Serializable]
	public sealed class TemporalBaseSOReference : BaseReference<TemporalBaseSO, TemporalBaseSOVariable>
	{
	    public TemporalBaseSOReference() : base() { }
	    public TemporalBaseSOReference(TemporalBaseSO value) : base(value) { }
	}
}