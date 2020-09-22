using UnityEditor;
using UnityEditor.UI;
using UnityEngine;

namespace pippinmole.UI.Editor {
    [CustomEditor(typeof(HorizontalDropdown))]
    public class HorizontalDropdownEditor : TMPro.EditorUtilities.DropdownEditor {
        public override void OnInspectorGUI() {
            base.OnInspectorGUI();

            //EditorGUI.BeginChangeCheck();
            //EditorGUILayout.PropertyField(this.serializedObject.FindProperty("_headerText"));
            //EditorGUILayout.PropertyField(this.serializedObject.FindProperty("_nextOption"));
            //EditorGUILayout.PropertyField(this.serializedObject.FindProperty("_previousOption"));

            //if (EditorGUI.EndChangeCheck()) {
            //    this.serializedObject.ApplyModifiedProperties();
            //}
        }
    }
}