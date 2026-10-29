using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

// Opt-in test driver only. Uses the original handlers after checking the actual
// visible hit target; never adds listeners, activates a page, or alters resources.
public static class OriginalUiTestClick
{
    public static GameObject Resolve(string path)
    {
        var found=GameObject.Find(path);
        if(found)return found;
        // Original PageReferences.unchild detaches three Canvas roots after2s.
        var segments=path.Split('/');
        for(int i=1;i<segments.Length;i++)
            if(segments[i].EndsWith("Canvas")){found=GameObject.Find(string.Join("/",segments,i,segments.Length-i));if(found)return found;}
        return null;
    }
    public static bool Try(GameObject go,out string blocked)
    {
        blocked="";
        if(!go || !go.activeInHierarchy){blocked="inactive or missing control";return false;}
        var button=go.GetComponent<Button>();
        if(button && (!button.enabled || !button.IsInteractable())){blocked="button disabled: "+go.name;return false;}
        var es=EventSystem.current;
        var rect=go.transform as RectTransform;
        if(!es || !rect){blocked="missing EventSystem/RectTransform: "+go.name;return false;}
        var canvas=go.GetComponentInParent<Canvas>();
        Camera camera=canvas && canvas.renderMode!=RenderMode.ScreenSpaceOverlay?canvas.worldCamera:null;
        var center=RectTransformUtility.WorldToScreenPoint(camera,rect.TransformPoint(rect.rect.center));
        var data=new PointerEventData(es){position=center,button=PointerEventData.InputButton.Left,eligibleForClick=true,pointerPress=go,rawPointerPress=go};
        var hits=new List<RaycastResult>();es.RaycastAll(data,hits);
        var receiver=hits.Count==0?null:ExecuteEvents.GetEventHandler<IPointerClickHandler>(hits[0].gameObject);
        if(receiver!=go){blocked="hit "+(hits.Count==0?"none":hits[0].gameObject.name)+" instead of "+go.name;return false;}
        ExecuteEvents.Execute(go,data,ExecuteEvents.pointerDownHandler);
        ExecuteEvents.Execute(go,data,ExecuteEvents.pointerUpHandler);
        ExecuteEvents.Execute(go,data,ExecuteEvents.pointerClickHandler);
        return true;
    }
}
