using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HorizontalDropdown : TMPro.TMP_Dropdown {

    [SerializeField] private TMPro.TMP_Text _headerText;
    [SerializeField] private Button _nextOption;
    [SerializeField] private Button _previousOption;

    protected override void Awake() {
        base.Awake();

        this._nextOption?.onClick.AddListener(this.NextOption);
        this._previousOption?.onClick.AddListener(this.PreviousOption);
    }

    protected override void Start() {
        base.Start();
    }

#if UNITY_EDITOR
    protected override void OnValidate() {
        base.OnValidate();
    }
    protected override void Reset() {
        base.Reset();
    }
#endif

    protected override void OnDisable() {
        base.OnDisable();
    }
    protected override void OnDestroy() {
        base.OnDestroy();

        this._nextOption.onClick = null;
        this._previousOption.onClick = null;
    }

    public void SetHeaderText(string text) => this._headerText?.SetText(text);
    public void NextOption() {
        if (this.value == this.options.Count - 1) {
            this.value = 0;
        } else {
            this.value++;
        }
    }
    public void PreviousOption() {
        if (this.value == 0) {
            this.value = this.options.Count + 1;
        } else {
            this.value--;
        }
    }
}
