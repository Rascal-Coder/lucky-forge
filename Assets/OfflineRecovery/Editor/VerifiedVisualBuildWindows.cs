using System.IO;
using UnityEditor;
using UnityEngine;
namespace LuckyForge.Offline.Editor
{
 public static class VerifiedVisualBuildWindows
 {
  public static void RunBatch()
  {
   var result=OriginalSpriteGeometryVerification.RunChecks();
   Directory.CreateDirectory("Verification");
   File.WriteAllText("Verification/original-sprite-geometry.json",JsonUtility.ToJson(result,true));
   if(!result.passed){Debug.LogError("Original sprite geometry verification failed");EditorApplication.Exit(1);return;}
   OfflineBuildWindows.RunBatch();
  }
 }
}
