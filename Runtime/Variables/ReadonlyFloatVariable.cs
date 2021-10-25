using UnityEngine;

using Sirenix.OdinInspector;

namespace N8.Utils.SOA.Variables
{
	[CreateAssetMenu(fileName = "NewFloatVariable", menuName = "SOA/Variables/Float"), InlineEditor] //TODO: That won't work, it uses the same menuName as the regular float.
	public sealed class ReadonlyFloatVariable : ReadonlyVariable<float>
	{

	}
}
