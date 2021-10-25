using UnityEngine;

using Sirenix.OdinInspector;

namespace N8.Utils.SOA.Variables
{
	[CreateAssetMenu(fileName = "NewFloatVariable", menuName = "SOA/Variables/Float"), InlineEditor]
	public sealed class FloatVariable : Variable<float>
	{

	}
}
