using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

// Opt-in diagnostic render. The probe calls this only with an isolated verification profile.
// This is a render from the recovered runtime scene, not a native Game View screenshot.
public static class RuntimeRecoveryRender
{
    public static void Capture(string path)
    {
        var rt = new RenderTexture(540, 960, 24, RenderTextureFormat.ARGB32);
        var oldActive = RenderTexture.active;
        var overlayStates = new List<(Canvas canvas, RenderMode mode, Camera camera, float distance)>();
        var cameraStates = new List<(Camera camera, RenderTexture target, float aspect)>();
        GameObject overlayObject = null;
        Texture2D pixels = null;
        try
        {
            rt.Create();
            var cameras = new List<Camera>();
            foreach (Camera camera in Camera.allCameras)
                if (camera.isActiveAndEnabled && camera.targetTexture == null) cameras.Add(camera);
            cameras.Sort((a,b)=>a.depth.CompareTo(b.depth));
            foreach (Canvas canvas in UnityEngine.Object.FindObjectsByType<Canvas>(FindObjectsSortMode.None))
                if (canvas.isRootCanvas && canvas.renderMode == RenderMode.ScreenSpaceOverlay)
                {
                    if (overlayObject == null)
                    {
                        overlayObject = new GameObject("VerificationOverlayCamera");
                        var overlay = overlayObject.AddComponent<Camera>();
                        overlay.orthographic = true;
                        overlay.clearFlags = CameraClearFlags.Depth;
                        overlay.cullingMask = 1 << 5;
                        overlay.nearClipPlane = 0.1f;
                        overlay.farClipPlane = 100f;
                        overlay.depth = 1000;
                        cameras.Add(overlay);
                    }
                    overlayStates.Add((canvas,canvas.renderMode,canvas.worldCamera,canvas.planeDistance));
                    canvas.renderMode = RenderMode.ScreenSpaceCamera;
                    canvas.worldCamera = overlayObject.GetComponent<Camera>();
                    canvas.planeDistance = 10f;
                }
            foreach (Camera camera in cameras)
            {
                cameraStates.Add((camera,camera.targetTexture,camera.aspect));
                camera.targetTexture = rt;
                camera.aspect = 540f / 960f;
            }
            Canvas.ForceUpdateCanvases();
            foreach (Camera camera in cameras) camera.Render();
            RenderTexture.active = rt;
            pixels = new Texture2D(rt.width, rt.height, TextureFormat.RGBA32, false);
            pixels.ReadPixels(new Rect(0,0,rt.width,rt.height),0,0);
            pixels.Apply();
            File.WriteAllBytes(path,pixels.EncodeToPNG());
        }
        finally
        {
            foreach (var state in overlayStates)
            {
                state.canvas.renderMode = state.mode;
                state.canvas.worldCamera = state.camera;
                state.canvas.planeDistance = state.distance;
            }
            foreach (var state in cameraStates)
            {
                state.camera.targetTexture = state.target;
                state.camera.aspect = state.aspect;
            }
            RenderTexture.active = oldActive;
            rt.Release();
            UnityEngine.Object.Destroy(rt);
            if (pixels != null) UnityEngine.Object.Destroy(pixels);
            if (overlayObject != null) UnityEngine.Object.Destroy(overlayObject);
        }
    }
}
