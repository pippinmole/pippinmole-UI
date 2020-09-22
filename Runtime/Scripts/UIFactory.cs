using System;
using System.Collections;
using System.Collections.Generic;
using Decay.InputSystem;
using UnityEngine;

namespace pippinmole.UI {
    public static class UIFactory {
        public static void RegisterDropdown<T>(string name, GameObject prefab, Transform parent, Func<int> getSetting, Action<int> setSetting, T[] values) {
            var dropdown = RegisterUI<HorizontalDropdown>(prefab, parent);

            if (dropdown == null) return;

            var options = new List<string>();
            foreach (var val in values) {
                options.Add(val.ToString());
            }

            dropdown.SetHeaderText(name);
            dropdown.onValueChanged += (x) => setSetting(x);

            dropdown.ClearOptions();
            dropdown.AddOptions(options);
            dropdown.Value = getSetting();
            dropdown.RefreshShownValue();
        }
        public static void RegisterSlider(string name, GameObject prefab, Transform parent, float minValue, float maxValue, string suffix, Func<float> getSetting, Action<float> setSetting) {
            var slider = RegisterUI<BetterSlider>(prefab, parent);

            if (slider == null) return;

            slider.SetHeaderText(name);
            slider.SetSuffix(suffix);
            slider.minValue = minValue;
            slider.maxValue = maxValue;
            slider.onValueChanged.AddListener((x) => setSetting(x));
            slider.value = getSetting();
        }
        public static void RegisterSlider(string name, GameObject prefab, Transform parent, int minValue, int maxValue, string suffix, Func<int> getSetting, Action<int> setSetting) {
            var slider = RegisterUI<BetterSlider>(prefab, parent);

            if (slider == null) return;

            slider.SetHeaderText(name);
            slider.SetSuffix(suffix);
            slider.minValue = minValue;
            slider.maxValue = maxValue;
            slider.wholeNumbers = true;
            slider.onValueChanged.AddListener((x) => setSetting(Convert.ToInt32(x)));
            slider.value = getSetting();
        }
        public static void RegisterToggle(string name, GameObject prefab, Transform parent, Func<bool> getSetting, Action<bool> setSetting) {
            var toggle = RegisterUI<HorizontalDropdown>(prefab, parent);

            if (toggle == null) return;

            toggle.SetHeaderText(name);
            toggle.ClearOptions();
            toggle.AddOptions(new List<string>() {
                "Off",
                "On"
            });
			toggle.onValueChanged += (x) => setSetting(x == 1);
            toggle.Value = getSetting() ? 1 : 0;
        }

        public static void RegisterKeymap(GameObject prefab, Transform parent, Func<Keybind> getSetting, Action<KeyCode> setSetting) {
            var keymapper = RegisterUI<UIKeymapperController>(prefab, parent);

            if (keymapper == null) return;

            keymapper.Setup(getSetting());
        }

        private static T RegisterUI<T>(GameObject prefab, Transform parent) {
            if (prefab == null) {
                Debug.LogWarning("Prefab 'prefab' shouldn't be null!");
                return default;
            }
            var obj = GameObject.Instantiate(prefab, parent);
            return obj == null ? default : obj.GetComponentInChildren<T>();
        }
    }
}