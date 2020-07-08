using System.Collections;
using System.Collections.Generic;
using Decay.Utilities;
using UnityEngine;
using UnityEngine.Rendering;

[ExecuteAlways]
public class BillboardWorldSpaceUI : MonoBehaviour {
    private void OnEnable() {
        //Camera.onPreRender += this.PreRender;
        RenderPipelineManager.beginCameraRendering += this.PreRender;
    }

    private void OnDisable() {
        //Camera.onPreRender -= this.PreRender;
        RenderPipelineManager.beginCameraRendering -= this.PreRender;
    }

    private void PreRender(ScriptableRenderContext ctx, Camera cam) {
        this.transform.forward = cam.transform.forward;
    }
}