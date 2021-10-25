using System;
using UnityEngine;

namespace ScriptableObjectArchitecture
{
    public abstract class ReadonlyVariable<T> : ScriptableObject, ISerializationCallbackReceiver
    {
        [SerializeField]
        private T _value;
        
        [field: NonSerialized]
        public T Value { get; private set; }

        public void OnBeforeSerialize() => Value = _value;
        public void OnAfterDeserialize() { }
    }
}