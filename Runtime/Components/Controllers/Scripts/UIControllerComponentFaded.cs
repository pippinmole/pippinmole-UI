using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace pippinmole.UI {
    [RequireComponent(typeof(CanvasGroup))]
    public class UIControllerComponentFaded : UIControllerComponent {

        [SerializeField] private CanvasGroup _canvasGroup;
        [SerializeField] private float _fadeTime = 0.7f;

        private void Start() {
            if (this._canvasGroup == null)
                this._canvasGroup = this.GetComponent<CanvasGroup>();
        }

        private void OnValidate() {
            if (this._canvasGroup == null)
                this._canvasGroup = this.GetComponent<CanvasGroup>();
        }

        protected override void SetMenuStateInternal(EState state) {
            if (this._canvasGroup == null) return;

            this._canvasGroup.DOFade(state == EState.Hidden ? 0f : 1f, this._fadeTime);
            this._canvasGroup.blocksRaycasts = state == EState.Hidden ? false : true;
        }
    }
}