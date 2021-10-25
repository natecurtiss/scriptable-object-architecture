using UnityEngine;
using Sirenix.OdinInspector;

namespace ScriptableObjectArchitecture
{
	[CreateAssetMenu(fileName = "NewFloatVariable", menuName = "SOA/Variables/Float"), InlineEditor]
	public sealed class ReadonlyFloatVariable : ReadonlyVariable<float>
	{

	}
}
