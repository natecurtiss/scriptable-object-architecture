using System;
using UnityEngine;

namespace N8.Utils.SOA.Vars
{
    public abstract class Var<T> : ScriptableObject, ISerializationCallbackReceiver
    {
        [SerializeField]
        private T _value;
        
        [field: NonSerialized] //Shouldn't be serialized anyhow, even with Odin installed, right?
        public T Value { get; set; }

        public void OnBeforeSerialize() => Value = _value;
        public void OnAfterDeserialize() { }
        
        public static implicit operator T(Var<T> input) => input.Value;
        
        public override string ToString() => Value.ToString();
    }
}