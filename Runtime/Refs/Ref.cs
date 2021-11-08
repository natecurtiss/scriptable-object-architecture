using System;
using System.Runtime.CompilerServices;
using static System.Runtime.CompilerServices.MethodImplOptions;

using UnityEngine;

namespace N8.Utils.SOA
{
    using Vars;
    
    [Serializable]
    public class Ref<T, TVar> where TVar : Var<T>
    {
        #region Fields & Properties
        
        [SerializeField] private T defaultValue;
        [SerializeField] private TVar variable;
        [SerializeField] private Boolean useDefault;

        public T Value
        {
            get => (variable == null || useDefault) ? defaultValue : variable;
            set
            {
                if (useDefault)
                {
                    defaultValue = value;
                }
                else
                {
                    variable.Value = value;
                }
            }
        }

        #endregion
        
        #region Structors

        public Ref() { }
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

        #endregion

        #region Operators

        [MethodImpl(AggressiveInlining)]
        public static implicit operator T(Ref<T, TVar> input) => input.Value;

        #endregion
    }
}
