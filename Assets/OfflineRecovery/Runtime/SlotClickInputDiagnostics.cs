using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.EventSystems;

// Diagnostic-only observer. It never installs listeners or invokes a game action in Update.
public sealed class SlotClickInputDiagnostics : MonoBehaviour
{
    [Serializable] public sealed class Entry
    {
        public int eventId, persistentCount;
        public string eventName;
        public List<string> listeners = new List<string>();
    }
    [Serializable] public sealed class Sample
    {
        public string reason, utc, scene, eventSystem, activeModule, selectedObject, target, error;
        public string fullscreenMode;public bool fullscreen,eventFocused;public float dpi;
        public int frame, screenWidth, screenHeight;
        public float realTime, silver;
        public bool focused, mouseDown, mouseUp, mouseHeld, buttonActive, buttonEnabled, interactable, triggerEnabled, spinning;
        public Vector3 mousePosition;
        public Rect buttonScreenRect;
        public int spinCount, commanderCount;
        public List<string> raycasts = new List<string>(), centerRaycasts = new List<string>();
        public List<Entry> triggerEntries = new List<Entry>();
    }
    [Serializable] public sealed class Report
    {
        public string mode = "read-only-input-observer";
        public List<Sample> samples = new List<Sample>();
    }
    [Serializable] public sealed class ActionReport
    {
        public string mode = "explicit-synthetic-event-test-not-physical-input";
        public bool handlerExecuted;
        public string error;
        public Sample before, after;
    }
    public string outputPath;
    readonly Report report = new Report();
    float nextSample;
    bool lastFocus;

    public static SlotClickInputDiagnostics Install(string path)
    {
        var go = new GameObject("OfflineRecovery_InputObserver");
        DontDestroyOnLoad(go);
        var observer = go.AddComponent<SlotClickInputDiagnostics>();
        observer.outputPath = path;
        observer.lastFocus = Application.isFocused;
        observer.Record("installed");
        observer.nextSample = Time.realtimeSinceStartup + 5f;
        return observer;
    }

    void Update()
    {
        bool edge = false;
        try { edge = Input.GetMouseButtonDown(0) || Input.GetMouseButtonUp(0); } catch { }
        bool focusChanged = lastFocus != Application.isFocused;
        if (edge || focusChanged || Time.realtimeSinceStartup >= nextSample)
        {
            Record(edge ? "mouse-edge" : focusChanged ? "focus-change" : "periodic-5s");
            nextSample = Time.realtimeSinceStartup + 5f;
            lastFocus = Application.isFocused;
        }
    }

    void OnApplicationQuit() { Record("application-quit"); }

    void Record(string reason)
    {
        try
        {
            report.samples.Add(Capture(reason));
            if (String.IsNullOrEmpty(outputPath)) return;
            var directory = Path.GetDirectoryName(outputPath);
            if (!String.IsNullOrEmpty(directory)) Directory.CreateDirectory(directory);
            File.WriteAllText(outputPath, JsonUtility.ToJson(report, true));
        }
        catch (Exception e) { Debug.LogWarning("Input diagnostic write: " + e.Message); }
    }

    static string Hierarchy(GameObject go)
    {
        if (!go) return "<null>";
        string path = go.name;
        for (var p = go.transform.parent; p; p = p.parent) path = p.name + "/" + path;
        return go.scene.name + ":/" + path;
    }
    static SlotMachineUI FindUi()
    {
        SlotMachineUI fallback = null;
        foreach (var ui in Resources.FindObjectsOfTypeAll<SlotMachineUI>())
        {
            if (!ui || !ui.gameObject.scene.IsValid()) continue;
            if (ui.isActiveAndEnabled) return ui;
            fallback = ui;
        }
        return fallback;
    }
    static void Raycast(EventSystem es, Vector2 screenPoint, List<string> result)
    {
        if (!es) return;
        var hits = new List<RaycastResult>();
        es.RaycastAll(new PointerEventData(es) { position = screenPoint, button = PointerEventData.InputButton.Left }, hits);
        for (int i = 0; i < Math.Min(5, hits.Count); i++)
        {
            var hit = hits[i];
            result.Add(Hierarchy(hit.gameObject) + "; module=" + (hit.module ? hit.module.GetType().FullName : "null")
                + "; depth=" + hit.depth + "; sorting=" + hit.sortingLayer + "/" + hit.sortingOrder + "; distance=" + hit.distance);
        }
    }

    public static Sample Capture(string reason, SlotMachineUI ui = null)
    {
        var s = new Sample { reason = reason, utc = DateTime.UtcNow.ToString("O"), frame = Time.frameCount,
            realTime = Time.realtimeSinceStartup, focused = Application.isFocused,
            screenWidth = Screen.width, screenHeight = Screen.height, fullscreen=Screen.fullScreen,fullscreenMode=Screen.fullScreenMode.ToString(),dpi=Screen.dpi,
            scene = UnityEngine.SceneManagement.SceneManager.GetActiveScene().name };
        try { s.mousePosition = Input.mousePosition; s.mouseDown = Input.GetMouseButtonDown(0); s.mouseUp = Input.GetMouseButtonUp(0); s.mouseHeld = Input.GetMouseButton(0); }
        catch (Exception e) { s.error = "Input: " + e.Message; }
        var es = EventSystem.current;s.eventFocused=es && es.isFocused;
        s.eventSystem = es ? Hierarchy(es.gameObject) + "; enabled=" + es.enabled : "<null>";
        s.activeModule = es && es.currentInputModule ? es.currentInputModule.GetType().FullName + "; active=" + es.currentInputModule.isActiveAndEnabled : "<null>";
        s.selectedObject = es ? Hierarchy(es.currentSelectedGameObject) : "<null>";
        Raycast(es, new Vector2(s.mousePosition.x, s.mousePosition.y), s.raycasts);
        if (!ui) ui = FindUi();
        if (!ui || !ui.btn) { s.target = "<SlotMachineUI/btn not present>"; return s; }
        s.target = Hierarchy(ui.btn.gameObject);
        s.buttonActive = ui.btn.gameObject.activeInHierarchy;
        s.buttonEnabled = ui.btn.enabled;
        s.interactable = ui.btn.IsInteractable();
        s.silver = ui.warController ? ui.warController.Silver : -1;
        s.spinCount = ui.slotMachine ? ui.slotMachine.SpinAdet : -1;
        s.spinning = ui.slotMachine && ui.slotMachine.spining;
        s.commanderCount = ui.commanderSpawner ? ui.commanderSpawner.currentCommanderCount : -1;
        var rect = ui.btn.transform as RectTransform;
        var canvas = ui.btn.GetComponentInParent<Canvas>();
        var camera = canvas && canvas.renderMode != RenderMode.ScreenSpaceOverlay ? canvas.worldCamera : null;
        if (rect)
        {
            var corners = new Vector3[4]; rect.GetWorldCorners(corners);
            var lo = RectTransformUtility.WorldToScreenPoint(camera, corners[0]);
            var hi = RectTransformUtility.WorldToScreenPoint(camera, corners[2]);
            s.buttonScreenRect = Rect.MinMaxRect(Mathf.Min(lo.x, hi.x), Mathf.Min(lo.y, hi.y), Mathf.Max(lo.x, hi.x), Mathf.Max(lo.y, hi.y));
            Raycast(es, s.buttonScreenRect.center, s.centerRaycasts);
        }
        var trigger = ui.btn.GetComponent<EventTrigger>();
        s.triggerEnabled = trigger && trigger.isActiveAndEnabled;
        if (trigger)
        {
            foreach (var entry in trigger.triggers)
            {
                var e = new Entry { eventId = (int)entry.eventID, eventName = entry.eventID.ToString(), persistentCount = entry.callback == null ? 0 : entry.callback.GetPersistentEventCount() };
                for (int i = 0; i < e.persistentCount; i++)
                {
                    var target = entry.callback.GetPersistentTarget(i);
                    var component = target as Component;
                    e.listeners.Add((target ? target.GetType().FullName : "<null>") + "; object=" + (component ? Hierarchy(component.gameObject) : target ? target.name : "null")
                        + "; method=" + entry.callback.GetPersistentMethodName(i) + "; state=" + entry.callback.GetPersistentListenerState(i));
                }
                s.triggerEntries.Add(e);
            }
        }
        return s;
    }

    // Only call explicitly in a separate actions fixture/profile. Never used by Install/Update/Capture.
    public static ActionReport ExecuteSerializedClick(SlotMachineUI ui, string actionReportPath = null)
    {
        var r = new ActionReport { before = Capture("before-explicit-synthetic-click", ui) };
        try
        {
            if (!ui || !ui.btn || !EventSystem.current) throw new InvalidOperationException("Real scene SlotMachineUI/button/EventSystem required.");
            var p = new PointerEventData(EventSystem.current) { position = r.before.buttonScreenRect.center, button = PointerEventData.InputButton.Left, clickCount = 1, eligibleForClick = true };
            r.handlerExecuted = ExecuteEvents.Execute(ui.btn.gameObject, p, ExecuteEvents.pointerClickHandler);
        }
        catch (Exception e) { r.error = e.ToString(); }
        r.after = Capture("after-explicit-synthetic-click", ui);
        if (!String.IsNullOrEmpty(actionReportPath))
        {
            var folder = Path.GetDirectoryName(actionReportPath);
            if (!String.IsNullOrEmpty(folder)) Directory.CreateDirectory(folder);
            File.WriteAllText(actionReportPath, JsonUtility.ToJson(r, true));
        }
        return r;
    }
}
