using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;

namespace N8.Utils.SOA.Editor
{
    //[CustomPropertyDrawer(type: typeof(IRef), useForChildren: true)]
    public sealed class RefPropertyDrawer : PropertyDrawer
    {
        public override VisualElement CreatePropertyGUI(SerializedProperty property)
        {
            VisualElement container = new VisualElement();
            
            Debug.Log("Active");

            FloatField floatField = new FloatField(label: "Fancy Label");
            
            floatField.RegisterCallback<ChangeEvent<float>>(callback: evt =>
            {
                Debug.Log(evt.newValue);
            });
            
            //PropertyField useDefault   = new PropertyField(property.FindPropertyRelative(_USE_DEFAULT));
            //PropertyField defaultValue = new PropertyField(property.FindPropertyRelative(_DEFAULT_VALUE));
            //PropertyField variable     = new PropertyField(property.FindPropertyRelative(_VAR));

            //SerializedProperty useDefault   = property.FindPropertyRelative(_USE_DEFAULT);
            //SerializedProperty defaultValue = property.FindPropertyRelative(_DEFAULT_VALUE);
            //SerializedProperty variable     = property.FindPropertyRelative(_VAR);

            //var t = new PopupField<float>(label: "Test", choices: new List<Single> {1f, 2f, 3f}, defaultValue: 1f);
            //container.Add(t);

            //container.Add(useDefault);
            //container.Add(defaultValue);
            //container.Add(variable);

            return container;
        }
        
        /*
        private const String _USE_DEFAULT   = "useDefault";
        private const String _DEFAULT_VALUE = "defaultValue";
        private const String _VAR           = "Var"; 
         */
    }
}
