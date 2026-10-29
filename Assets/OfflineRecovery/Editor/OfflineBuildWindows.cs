using System;
using System.IO;
using UnityEditor;
using UnityEditor.Build;
using UnityEditor.Build.Reporting;
using UnityEngine;

namespace LuckyForge.Offline.Editor
{
    public static class OfflineBuildWindows
    {
        [Serializable] public sealed class Report
        {
            public string result;
            public string generatedUtc;
            public string path;
            public string unityVersion;
            public int errors;
            public int warnings;
            public long bytes;
            public string state = "Development recovery build; remaining gameplay methods are still being restored.";
        }
        public static void RunBatch()
        {
            string root=Directory.GetParent(Application.dataPath).FullName;
            string folder=Path.Combine(root,"Builds","Windows");
            Directory.CreateDirectory(folder);
            PlayerSettings.SetScriptingBackend(NamedBuildTarget.Standalone,ScriptingImplementation.Mono2x);
            PlayerSettings.SetManagedStrippingLevel(NamedBuildTarget.Standalone,ManagedStrippingLevel.Disabled);
            PlayerSettings.defaultScreenWidth=540;
            PlayerSettings.defaultScreenHeight=960;
            PlayerSettings.fullScreenMode=FullScreenMode.Windowed;
            PlayerSettings.runInBackground=true;
            PlayerSettings.companyName="LuckyForgeOfflineRecovery";
            PlayerSettings.productName="LuckyForge Offline Recovery";
            var report=BuildPipeline.BuildPlayer(new BuildPlayerOptions {
                scenes=new[]{"Assets/Scenes/Loading.unity","Assets/Scenes/Sahne.unity"},
                locationPathName=Path.Combine(folder,"LuckyForge-Offline.exe"),
                target=BuildTarget.StandaloneWindows64,
                options=BuildOptions.Development
            });
            var s=report.summary;
            var data=new Report {generatedUtc=DateTime.UtcNow.ToString("o"),result=s.result.ToString(),path=s.outputPath,unityVersion=Application.unityVersion,errors=(int)s.totalErrors,warnings=(int)s.totalWarnings,bytes=(long)s.totalSize};
            Directory.CreateDirectory(Path.Combine(root,"Verification"));
            File.WriteAllText(Path.Combine(root,"Verification","windows-build.json"),JsonUtility.ToJson(data,true));
            EditorApplication.Exit(s.result==BuildResult.Succeeded?0:1);
        }
    }
}
