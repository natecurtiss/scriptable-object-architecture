using System;
using UnityEngine;

namespace N8.Utils.SOA.Variables
{
    public abstract class Variable<T> : ScriptableObject, ISerializationCallbackReceiver
    {
        public static implicit operator T(Variable<T> input) => input.Value;

        [SerializeField]
        private T _value;
        
        public T Value { get; set; }

        public override string ToString() => Value.ToString();

        public void OnBeforeSerialize() => Value = _value;
        public void OnAfterDeserialize() { }        
    }
}