using System.Collections.Generic;
using Decay.InputSystem;
using UnityEngine;

namespace pippinmole.UI {
    public abstract class UIControllerComponent : MonoBehaviour, IInputBlocker {

        public static List<IInputBlocker> InputBlockers = new List<IInputBlocker>();

        public EState State { get; private set; }
        public enum EState {
            Hidden,
            Visible
        }

        public bool BlocksInput;
        public bool IsVisible => this.State == EState.Visible;
        public bool IsHidden => this.State == EState.Hidden;

        [SerializeField] protected EState DefaultState;

        protected virtual void Awake() {
            this.ResetVisibility();
        }

        public void ToggleVisibility() => this.SetMenuState(!this.IsVisible);
        public void ResetVisibility() => this.SetMenuState(this.DefaultState);

        /// <summary>
        /// Physically sets the state of the gameobject
        /// </summary>
        /// <param name="value"></param>
        public void SetMenuState(bool state) => this.SetMenuState(state ? EState.Visible : EState.Hidden);

        /// <summary>
        /// Physically sets the state of the gameobject
        /// </summary>
        /// <param name="value"></param>
        public void SetMenuState(EState state) {
            this.SetMenuStateInternal(state);

            this.State = state;
            this.OnSetMenuVisiblity(state);

            if (this.BlocksInput) {
                if (state == EState.Hidden) {
                    InputBlockers.Remove(this);
                } else {
                    InputBlockers.Add(this);
                }
            }
        }

        /// <summary>
        /// The core state transition method. Do not call this method.
        /// </summary>
        /// <param name="state"></param>
        protected virtual void SetMenuStateInternal(EState state) {
            this.gameObject.SetActive(state == EState.Visible);
        }

        protected abstract void OnSetMenuVisiblity(EState state);
    }
}