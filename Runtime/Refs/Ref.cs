using System;
using System.Runtime.CompilerServices;
using static System.Runtime.CompilerServices.MethodImplOptions;

using UnityEngine;

namespace N8.Utils.SOA
{
    using Vars;
    
    [Serializable]
    public class Ref<T, TVar> : IRef where TVar : Var<T>
    {
        #region Fields & Properties
        
        [SerializeField] protected Boolean useDefault;
        [SerializeField] protected T defaultValue;
        
        [field: SerializeField] 
        protected TVar Var { get; private set; }

        private Boolean IsUsingDefault => (useDefault || (Var == null));
        
        public T Value
        {
            get => IsUsingDefault ? defaultValue : (T)Var;
            set
            {
                if (IsUsingDefault)
                {
                    defaultValue = value;
                }
                else
                {
                    Var.Value = value;
                }
            }
        }

        #endregion
        
        #region Structors

        public Ref() { }

        public Ref(T val)
        {
            this.Value = val;
        }
        
        public Ref(TVar var)
        {
            this.Var = var;
        }
        
        /*
        public Ref(T value, Boolean useDefault = true)
        {
            this.useDefault = useDefault;
            this.Value = value;
        }
        
        public Ref(TVar variable, Boolean useDefault = false)
        {
            this.useDefault = useDefault;
            this.variable = variable;
        }
        */

        #endregion

        #region Methods

        public override String ToString() => Value.ToString();

        #endregion

        #region Operators

        //TODO: Conversion Operators default check.
        
        [MethodImpl(AggressiveInlining)]
        public static implicit operator T    (Ref<T, TVar> input) => input.Value;
        [MethodImpl(AggressiveInlining)]
        public static implicit operator TVar (Ref<T, TVar> input) => input.Var;
        
        [MethodImpl(AggressiveInlining)]
        public static implicit operator Ref<T, TVar> (T val)    => new Ref<T, TVar>(val: val);
        [MethodImpl(AggressiveInlining)]
        public static implicit operator Ref<T, TVar> (TVar var) => new Ref<T, TVar>(var: var);

        #endregion
    }
}
