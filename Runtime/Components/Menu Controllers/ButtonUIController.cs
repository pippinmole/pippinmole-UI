using UnityEngine;
using UnityEngine.UI;

namespace pippinmole.UI {
    [RequireComponent(typeof(Button))]
    public class ButtonUIController : MonoBehaviour {

        [System.Serializable]
        private enum ToggleType {
            EnableOnly,
            DisableOnly,
            Toggle
        }

        [SerializeField] private Button _button;
        [SerializeField] private UIControllerComponent _component;
        [SerializeField] private ToggleType _toggleType;

        private void Start() {
            if (this._button == null) {
                this._button = this.GetComponent<Button>();
            }

            switch (this._toggleType) {
                case ToggleType.EnableOnly:
                    this._button?.onClick.AddListener(() => this._component?.SetMenuState(true));
                    break;
                case ToggleType.DisableOnly:
                    this._button?.onClick.AddListener(() => this._component?.SetMenuState(false));
                    break;
                case ToggleType.Toggle:
                    this._button?.onClick.AddListener(() => this._component?.ToggleVisibility());
                    break;
            }
        }
    }
}