using Sirenix.OdinInspector;
using UnityEngine;

namespace N8.Utils.SOA.Vars
{
	[CreateAssetMenu(fileName = "NewVector3Var", menuName = "N8Dev/SOA/Variables/Vector3"), InlineEditor]
	public sealed class Vector3Var : Var<Vector3>
	{
		#region "Structors"

		public new static Vector3Var New()
		{
			Vector3Var newVar = CreateInstance<Vector3Var>();

			return newVar;
		}
        
		public new static Vector3Var New(Vector3 val)
		{
			Vector3Var newVar = CreateInstance<Vector3Var>();

			newVar.Value = val;

			return newVar;
		}

		#endregion
	}
}