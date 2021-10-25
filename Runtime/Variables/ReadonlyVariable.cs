using System;
using UnityEngine;

namespace N8.Utils.SOA.Variables
{
    public abstract class ReadonlyVariable<T> : ScriptableObject, ISerializationCallbackReceiver
    {
        public static implicit operator T(ReadonlyVariable<T> input) => input.Value;
        
        [SerializeField]
        private T _value;
        
        public T Value { get; private set; }

        public override string ToString() => Value.ToString();

        public void OnBeforeSerialize() => Value = _value;
        public void OnAfterDeserialize() { }
    }
}