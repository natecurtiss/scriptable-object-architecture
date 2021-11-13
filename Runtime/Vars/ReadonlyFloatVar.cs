using Sirenix.OdinInspector;
using UnityEngine;

namespace N8.Utils.SOA.Vars
{
	[CreateAssetMenu(fileName = "NewFloatVariable", menuName = "N8Dev/SOA/Variables/Float"), InlineEditor] //TODO: That won't work, it uses the same menuName as the regular float.
	public sealed class ReadonlyFloatVar : ReadonlyVar<float>
	{

	}
}
