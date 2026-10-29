using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public static class RuntimeMaterialSnapshot
{
    [Serializable] public sealed class Entry { public string path;public string component;public string material;public string shader;public string texture;public string[] keywords;public bool supported;public string sprite;public Color color;public Vector4 screenRect; }
    [Serializable] public sealed class Report { public List<Entry> entries=new List<Entry>(); }
    static string PathOf(Transform t) { string path=t.name;while(t.parent!=null){t=t.parent;path=t.name+"/"+path;}return path; }
    static Entry Describe(Component c,Material m,Texture texture)
    {
        return new Entry {path=PathOf(c.transform),component=c.GetType().Name,material=m==null?"null":m.name,shader=m==null||m.shader==null?"null":m.shader.name,texture=texture==null?"null":texture.name,keywords=m==null?Array.Empty<string>():m.shaderKeywords,supported=m!=null && m.shader!=null && m.shader.isSupported};
    }
    public static void Write(string path)
    {
        var r=new Report();
        foreach(var renderer in UnityEngine.Object.FindObjectsByType<Renderer>(FindObjectsSortMode.None))
            if(renderer.enabled)foreach(var material in renderer.sharedMaterials)r.entries.Add(Describe(renderer,material,material==null?null:material.HasProperty("_MainTex")?material.GetTexture("_MainTex"):material.HasProperty("_BaseMap")?material.GetTexture("_BaseMap"):null));
        foreach(var graphic in UnityEngine.Object.FindObjectsByType<Graphic>(FindObjectsSortMode.None))
            if(graphic.enabled)
            {
                var entry=Describe(graphic,graphic.material,graphic.mainTexture);entry.color=graphic.color;
                if(graphic is Image image)entry.sprite=(image.overrideSprite??image.sprite)==null?"null":(image.overrideSprite??image.sprite).name;
                var corners=new Vector3[4];graphic.rectTransform.GetWorldCorners(corners);
                Camera camera=graphic.canvas==null||graphic.canvas.renderMode==RenderMode.ScreenSpaceOverlay?null:graphic.canvas.worldCamera;
                Vector2 min=RectTransformUtility.WorldToScreenPoint(camera,corners[0]);Vector2 max=min;
                foreach(var corner in corners){var p=RectTransformUtility.WorldToScreenPoint(camera,corner);min=Vector2.Min(min,p);max=Vector2.Max(max,p);}
                entry.screenRect=new Vector4(min.x,min.y,max.x,max.y);r.entries.Add(entry);
            }
        File.WriteAllText(path,JsonUtility.ToJson(r,true));
    }
}
