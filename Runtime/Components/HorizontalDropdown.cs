using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HorizontalDropdown : MonoBehaviour {

    [SerializeField] private TMPro.TMP_Text headerText;

    [SerializeField] private TMPro.TMP_Text valueText;
    [SerializeField] private Button nextOptionButton;
    [SerializeField] private Button previousOptionButton;

    [SerializeField] private List<string> options = new List<string>();

    public event Action<int> onValueChanged;

    private int val;

    public int Value {
        get => this.val;
        set => this.val = Mathf.Clamp(value, 0, this.options.Count - 1);
    }

    private void Awake() {
        if ( this.nextOptionButton != null ) this.nextOptionButton.onClick.AddListener(this.NextOption);
        if ( this.previousOptionButton != null ) this.previousOptionButton.onClick.AddListener(this.PreviousOption);

        this.onValueChanged += (x) => this.RefreshShownValue();
    }

    private void OnEnable() {
        this.RefreshShownValue();
    }

    private void OnDestroy() {
        this.nextOptionButton.onClick = null;
        this.previousOptionButton.onClick = null;
    }

    public void SetHeaderText(string text) {
        if ( this.headerText != null )
            this.headerText.SetText(text);
    }

    public void NextOption() {
        this.Value = this.Value == this.options.Count - 1 ? 0 : this.Value + 1;

        if ( this.onValueChanged != null )
            this.onValueChanged.Invoke(this.Value);
    }

    public void PreviousOption() {
        this.Value = this.Value == 0 ? this.options.Count - 1 : this.Value - 1;
        
        if ( this.onValueChanged != null )
            this.onValueChanged.Invoke(this.Value);
    }

    public void ClearOptions() {
        this.options = new List<string>();
    }

    public void AddOptions(List<string> opt) {
        this.options = opt;
    }

    public void RefreshShownValue() {
		this.valueText.SetText(this.options.Count == 0 ? "" : this.options[this.Value]);
    }
}