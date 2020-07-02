using System.Collections.Generic;
using System.Linq;
using NaughtyAttributes;
using UnityEngine;
using UnityEngine.UI;

namespace pippinmole.UI {
    public class MenuButtonList : MonoBehaviour {

        [System.Serializable]
        private class MenuButton {
            public Button Button;
            public UIControllerComponent Menu;
        }

        [Header("Prefabs")]
        [SerializeField] private GameObject _menuButtonPrefab;
        [SerializeField] private GameObject _menuPanelPrefab;

        [Header("Editor Variables")]
        [SerializeField] private RectTransform _buttonParent;
        [SerializeField] private RectTransform _menuParent;
        [SerializeField] private List<MenuButton> _menuButtons = new List<MenuButton>();

        private MenuButton _currentMenu;

        [Button("Add MenuButton")]
        void AddMenuButton() {
            var menuButton = new MenuButton {
                Button = Instantiate(this._menuButtonPrefab, this._buttonParent).GetComponent<Button>(),
                Menu = Instantiate(this._menuPanelPrefab, this._menuParent).GetComponent<UIControllerComponent>()
            };

            if (menuButton.Button == null) {
                Debug.LogError($"Fatal error adding MenuButton keypair: '_menuButtonPrefab' is required to have component fo type 'Button'!");
            }
            if (menuButton.Menu == null) {
                Debug.LogError($"Fatal error adding MenuButton keypair: '_menuPanelPrefab' is required to have component fo type 'UIControllerComponent'!");
            }

            this._menuButtons.Add(menuButton);
        }

        [Button("Remove MenuButton")]
        void RemoveMenuButton() {
            if (this._menuButtons.Count == 0) return;

            var menuButton = this._menuButtons.Last();

            if (menuButton.Button != null)
                GameObject.DestroyImmediate(menuButton.Button?.gameObject);

            if (menuButton.Menu != null)
                GameObject.DestroyImmediate(menuButton.Menu?.gameObject);

            this._menuButtons.Remove(menuButton);
        }

        private void Awake() {
            foreach (var menuButton in this._menuButtons) {
                menuButton.Button.onClick.AddListener(() => this.SetMenu(menuButton));
            }

            // Set the first one to default. TODO: Make this visible in the editor so you can change it, or disable the option entirely.
            if (this._menuButtons.Count > 0)
                this.SetMenu(this._menuButtons[0]);
        }

        private void SetMenu(MenuButton menu) {
            if (this._currentMenu != menu) {
                this._currentMenu?.Menu.SetMenuState(UIControllerComponent.EState.Hidden);
            }

            this._currentMenu = menu;
            this._currentMenu.Menu.SetMenuState(UIControllerComponent.EState.Visible);
        }
    }
}