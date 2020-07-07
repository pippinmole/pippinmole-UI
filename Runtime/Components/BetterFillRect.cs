using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace pippinmole.UI {
    public class BetterFillRect : MonoBehaviour {

        public float LerpSpeed = 0.5f;
        public bool IsLerped = true;

        [SerializeField] private Image fill;

        private float targetFill = 1f;
        private float currentVelocity;

        private void Update() {
            if (this.IsLerped)
                this.fill.fillAmount = Mathf.SmoothDamp(this.fill.fillAmount, this.targetFill, ref currentVelocity, this.LerpSpeed);
            else
                this.fill.fillAmount = this.targetFill;
        }

        public void SetFill(float value) {
            if (this.fill == null) return;

            this.targetFill = Mathf.Clamp(value, 0f, 1f);
        }
    }
}