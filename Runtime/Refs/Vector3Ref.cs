using System;
using System.Runtime.CompilerServices;
using static System.Runtime.CompilerServices.MethodImplOptions;

using UnityEngine;

namespace N8.Utils.SOA.Refs
{
	using Vars;
	
	[Serializable]
	public sealed class Vector3Ref : Ref<Vector3, Vector3Var>
	{
		public Vector3Ref() : base() { }
		public Vector3Ref(Vector3 val) : base(val: val) { }
		public Vector3Ref(Vector3Var var) : base(var: var) { }
		//public Vector3Ref(Vector3 value, Boolean useDefault = true) : base(value: value, useDefault: useDefault) { }
		//public Vector3Ref(Vector3Var variable, Boolean useDefault = false) : base(variable: variable, useDefault: useDefault) { }

		[MethodImpl(AggressiveInlining)]
		public static implicit operator Vector3    (Vector3Ref input) => input.Value;
		[MethodImpl(AggressiveInlining)]
		public static implicit operator Vector3Var (Vector3Ref input) => input.Var;
        
		[MethodImpl(AggressiveInlining)]
		public static implicit operator Vector3Ref (Vector3 val)    => new Vector3Ref(val: val);
		[MethodImpl(AggressiveInlining)]
		public static implicit operator Vector3Ref (Vector3Var var) => new Vector3Ref(var: var);
	}
}