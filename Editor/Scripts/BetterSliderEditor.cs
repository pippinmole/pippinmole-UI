﻿using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.UI;
using UnityEngine;
using UnityEngine.UI;

namespace pippinmole.UI.Editor {
    [CustomEditor(typeof(BetterSlider))]
    public class BetterSliderEditor : SliderEditor {

        public override void OnInspectorGUI() {
            base.OnInspectorGUI();

            EditorGUI.BeginChangeCheck();
            EditorGUILayout.PropertyField(this.serializedObject.FindProperty("_headerText"));
            EditorGUILayout.PropertyField(this.serializedObject.FindProperty("_valueText"));
            EditorGUILayout.PropertyField(this.serializedObject.FindProperty("_suffix"));

            if (EditorGUI.EndChangeCheck()) {
                this.serializedObject.ApplyModifiedProperties();
            }
        }
    }
}