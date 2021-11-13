using System;
using UnityEngine;

namespace N8.Utils.SOA.Vars
{
    public abstract class Var<T> : ScriptableObject, ISerializationCallbackReceiver
    {
        #region Fields & Properties

        [SerializeField]
        private T _value;
        
        public T Value { get; set; }

        #endregion

        /*
        //TODO: Figure these out.
        #region "Structors"

        public static Var<T> New()
        {
            Var<T> newVar = CreateInstance<Var<T>>();

            return newVar;
        }
        
        public static Var<T> New(T val)
        {
            Var<T> newVar = CreateInstance<Var<T>>();

            newVar.Value = val;

            return newVar;
        }
        
        #endregion
        */
        
        #region Methods

        public void OnBeforeSerialize() => Value = _value;
        public void OnAfterDeserialize() { }
        
        
        public override String ToString() => Value.ToString();

        #endregion

        #region Operators
        
        //Can't work in reverse because ScriptableObjects can't be created via constructor.
        public static implicit operator T(Var<T> input) => input.Value;

        #endregion
    }
}