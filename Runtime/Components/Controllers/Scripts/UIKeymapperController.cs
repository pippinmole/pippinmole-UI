using System;
using System.Collections;
using System.Collections.Generic;
using Decay.InputSystem;
using Decay.Utilities;
using UnityEngine;
using UnityEngine.UI;

namespace pippinmole.UI {
    public class UIKeymapperController : MonoBehaviour {

        private static UIKeymapperController CurrentMapper;

        [Header("Components")]
        [SerializeField] private Button _startKeybindChangeButton;
        [SerializeField] private TMPro.TMP_Text _keybindTitleText;
        [SerializeField] private TMPro.TMP_Text _keybindButtonText;

        private Keybind keybind;

        public void Setup(Keybind bind) {
            this.keybind = bind;

            this.RefreshUIText();

            this._startKeybindChangeButton.onClick.AddListener(() => {
                if (CurrentMapper != null)
                    CurrentMapper.Cancel();

                CurrentMapper = this;

                this._keybindButtonText.SetText("[Unassigned]");
            });

            this.keybind.OnKeyChanged += this.RefreshUIText;
        }

        public void Cancel() {
            this.RefreshUIText();
            CurrentMapper = null;
        }

        private void OnDestroy() {
            if (this.keybind != null)
                this.keybind.OnKeyChanged -= this.RefreshUIText;
        }

        private void RefreshUIText() {
            this._keybindTitleText.SetText(StringFormat.SplitCamelCase(this.keybind.Name));
            this._keybindButtonText.SetText(StringFormat.SplitCamelCase(this.keybind.Key.ToString()));
        }

        private void OnGUI() {
            if (CurrentMapper != this) return;

            var keyEvent = Event.current;

            if (keyEvent.isKey && !keyEvent.isMouse) {
                var key = keyEvent.keyCode;

                this.keybind.Set(key);
                this.Cancel();
            }
        }
    }
}