using System;
using UnityEngine;

namespace N8.Utils.SOA.Variables
{
    public abstract class Variable<T> : ScriptableObject, ISerializationCallbackReceiver
    {
        [SerializeField]
        private T _value;
        
        [field: NonSerialized]
        public T Value { get; set; }

        public void OnBeforeSerialize() => Value = _value;
        public void OnAfterDeserialize() { }
    }
}