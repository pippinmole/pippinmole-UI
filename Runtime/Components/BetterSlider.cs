using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace pippinmole.UI {
    public class BetterSlider : Slider {

        [SerializeField] private TMPro.TMP_Text _headerText;
        [SerializeField] private TMPro.TMP_Text _valueText;
        [SerializeField] private string _suffix;

        protected override void Awake() {
            base.Awake();

            this.onValueChanged.AddListener((x) => this.UpdateValueText());
        }

#if UNITY_EDITOR
    protected override void OnValidate() {
        base.OnValidate();

        this.UpdateValueText();
    }
#endif

        public void SetHeaderText(string text) {
            this._headerText?.SetText(text);
        }
        public void SetSuffix(string suffix) {
            this._suffix = suffix;
        }
        private void UpdateValueText() {
            var text = this.value.ToString(this.wholeNumbers ? "F0" : "F2");
            this._valueText?.SetText(text + this._suffix);
        }
    }
}