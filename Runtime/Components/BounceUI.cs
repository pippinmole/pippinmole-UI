using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.EventSystems;

namespace pippinmole.UI {
    public class BounceUI : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler, IPointerUpHandler {

        [SerializeField] private bool _clickBounce = false;

        [SerializeField] private Vector2 _normalScale = new Vector2(1f, 1f);
        [SerializeField] private Vector2 _hoveredScale = new Vector2(1.1f, 1.1f);
        [SerializeField] private float _scaleSpeed = 0.8f;

        public bool Interactable { get; set; } = true;

        private RectTransform _rectTransform;

        private void Awake() {
            this._rectTransform = this.GetComponent<RectTransform>();

            if (this._rectTransform == null) {
                Debug.LogError($"{this.gameObject} is required to have component of type 'RectTransform'!");
            }
        }

        void IPointerDownHandler.OnPointerDown(PointerEventData eventData) {
            if (!this.Interactable) return;

            this._rectTransform.DOScale(this._normalScale, this._scaleSpeed);
        }
        void IPointerUpHandler.OnPointerUp(PointerEventData eventData) {
            if (!this.Interactable) return;

            this._rectTransform.DOScale(this._hoveredScale, this._scaleSpeed);
        }

        void IPointerEnterHandler.OnPointerEnter(PointerEventData eventData) {
            if (!this.Interactable) return;

            this._rectTransform.DOScale(this._hoveredScale, this._scaleSpeed);
        }

        void IPointerExitHandler.OnPointerExit(PointerEventData eventData) {
            this._rectTransform.DOScale(this._normalScale, this._scaleSpeed);
        }
    }
}