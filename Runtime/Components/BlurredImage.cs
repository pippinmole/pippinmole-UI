using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace pippinmole.UI {
    [AddComponentMenu("UI/Blurred Image", 99)]
    public class BlurredImage : Image {
#if UNITY_EDITOR
    protected override void Reset() {
        base.Reset();

        this.color = Color.clear;
    }
#endif
    }
}