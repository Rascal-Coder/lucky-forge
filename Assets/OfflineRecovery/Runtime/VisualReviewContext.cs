using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

// Explicit diagnostic environment only. Normal game launches never change roots.
public static class VisualReviewContext
{
    public static readonly List<string> errors=new List<string>();
    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    static void Initialize()
    {
        string root=Environment.GetEnvironmentVariable("LUCKYFORGE_VISUAL_REVIEW_ROOT");
        if(string.IsNullOrEmpty(root))return;
        errors.Clear();OfflineKeyStore.SetVerificationRoot(Path.Combine(root,"Profile"));
        Application.logMessageReceived+=(message,stack,type)=>{if(type==LogType.Error||type==LogType.Exception||type==LogType.Assert)errors.Add(message+"\n"+stack);};
    }
}
