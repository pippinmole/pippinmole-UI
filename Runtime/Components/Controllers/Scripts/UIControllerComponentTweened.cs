using DG.Tweening;
using UnityEngine;

namespace pippinmole.UI {
    public class UIControllerComponentTweened : UIControllerComponent {

        [SerializeField] protected Vector3 VisiblePosition = new Vector3(0f, 0f, 0f);
        [SerializeField] protected Vector3 HiddenPosition = new Vector3(1920f, 0f, 0f);
        [SerializeField] protected float PositionDuration = 0.45f;

        protected override void Awake() {
            base.Awake();
        }

        protected override void SetMenuStateInternal(EState state) {
            this.transform.DOLocalMove(state == EState.Visible ? this.VisiblePosition : this.HiddenPosition, this.PositionDuration);
        }
    }
}