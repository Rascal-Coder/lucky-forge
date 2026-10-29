using System;using System.Collections.Generic;using System.Globalization;using System.IO;using System.Linq;using System.Security.Cryptography;using System.Text.RegularExpressions;using UnityEditor;using UnityEngine;
namespace LuckyForge.Offline.Editor {
public static class OriginalSpriteGeometryVerification {
 [Serializable] public class RectValue{public float x,y,width,height;}
 [Serializable] public class Expected{public string asset,guid,name,sourceFile,renderKey,sourceGroup,metaSha256;public long localFileID,sourcePathID,renderValue;public RectValue rect;public Vector2 pivot,offset,textureRectOffset;public Vector4 border;public float ppu;public int textureWidth,textureHeight,originalVertexCount,originalIndexBytes;}
 [Serializable] public class ExpectedRoot{public string mode;public List<Expected> sprites;}
 [Serializable] public class GeometryObservation{public string asset,sourceGroup;public int originalVertices,loadedVertices,originalIndexBytes,loadedIndices;}
 [Serializable] public class Result{public bool passed;public int checks,spriteCount,loadedSprites,containmentExceptionSprites;public string testRoot,expectedData;public List<string> failures=new List<string>();public List<string> failedSprites=new List<string>();public List<GeometryObservation> geometryCountDifferences=new List<GeometryObservation>();public string note="Actual Editor loads all1693 source-exact Sprite assets. Verifies source identity/GUID/localfileID, original rect/pivot/border/offset/textureRectOffset, PPU, texture dimensions and finite geometry. Full-rectangle containment is diagnostic only; original values are never clamped. Empty geometry is allowed when source buffers were empty. Does not assert raster/physical-input correctness.";}
 static bool Near(float a,float b)=>Math.Abs(a-b)<=Math.Max(.0002f,Math.Abs(b)*.000002f);
 static bool Near(Vector2 a,Vector2 b)=>Near(a.x,b.x)&&Near(a.y,b.y);
 static bool Near(Vector4 a,Vector4 b)=>Near(a.x,b.x)&&Near(a.y,b.y)&&Near(a.z,b.z)&&Near(a.w,b.w);
 static bool Finite(float x)=>!float.IsNaN(x)&&!float.IsInfinity(x);
 static string Hash(string p){using(var h=SHA256.Create())return BitConverter.ToString(h.ComputeHash(File.ReadAllBytes(p))).Replace("-","").ToLowerInvariant();}
 static void Check(Result r,Expected e,bool ok,string label){r.checks++;if(ok)return;r.failures.Add(e.asset+" ["+e.sourceFile+":"+e.sourcePathID+";"+e.sourceGroup+"] "+label);if(!r.failedSprites.Contains(e.asset))r.failedSprites.Add(e.asset);}
 static Vector2 ReadOffset(string yaml){var m=Regex.Match(yaml,@"(?m)^  m_Offset: \{x: ([^,]+), y: ([^}]+)\}");if(!m.Success)return new Vector2(float.NaN,float.NaN);return new Vector2(float.Parse(m.Groups[1].Value,CultureInfo.InvariantCulture),float.Parse(m.Groups[2].Value,CultureInfo.InvariantCulture));}
 public static Result RunChecks(){return RunChecks(null,null);}
 public static Result RunChecks(string expectedPath,string suppliedRoot){
  var r=new Result{testRoot=Path.GetFullPath(suppliedRoot??Path.Combine(Path.GetTempPath(),"LuckyForgeOriginalSpriteChecks",Guid.NewGuid().ToString("N"))),expectedData=Path.GetFullPath(expectedPath??Path.Combine(Application.dataPath,"OfflineRecovery","Editor","original-sprite-expected.json"))};Directory.CreateDirectory(r.testRoot);
  if(EditorApplication.isPlayingOrWillChangePlaymode){r.failures.Add("Requires non-playing Editor asset validation");return r;}
  try{
   var expected=JsonUtility.FromJson<ExpectedRoot>(File.ReadAllText(r.expectedData));if(expected.mode!="original-exact"||expected.sprites==null||expected.sprites.Count!=1693)throw new InvalidDataException("Expected all1693 exact source identities");r.spriteCount=expected.sprites.Count;
   foreach(var e in expected.sprites){
    if(e.sourceGroup=="original-exact-containment-exception")r.containmentExceptionSprites++;
    try{
     var sprite=AssetDatabase.LoadAssetAtPath<Sprite>(e.asset);Check(r,e,sprite!=null,"actual Sprite asset load");if(sprite==null)continue;r.loadedSprites++;
     string guid;long fileID;bool got=AssetDatabase.TryGetGUIDAndLocalFileIdentifier(sprite,out guid,out fileID);string file=Path.GetFullPath(Path.Combine(Directory.GetParent(Application.dataPath).FullName,e.asset));string yaml=File.ReadAllText(file);
     var key=Regex.Match(yaml,@"(?m)^  m_RenderDataKey:\r?\n    ([0-9a-f]+): (-?\d+)");
     Check(r,e,got&&guid==e.guid&&fileID==e.localFileID&&sprite.name==e.name&&key.Success&&key.Groups[1].Value==e.renderKey&&long.Parse(key.Groups[2].Value,CultureInfo.InvariantCulture)==e.renderValue,"preserved original RenderDataKey, asset GUID/localFileID and exported source name");
     var rect=sprite.rect;Vector2 expectedPivot=new Vector2((float)(e.pivot.x*e.rect.width),(float)(e.pivot.y*e.rect.height));
     Check(r,e,Near(rect.x,e.rect.x)&&Near(rect.y,e.rect.y)&&Near(rect.width,e.rect.width)&&Near(rect.height,e.rect.height)&&Near(sprite.pivot,expectedPivot),"actual loaded original full rect/pivot");
     Check(r,e,Near(sprite.border,e.border)&&Near(ReadOffset(yaml),e.offset),"actual original border and serialized original offset");
     Check(r,e,Near(sprite.textureRectOffset,e.textureRectOffset),"actual loaded original textureRectOffset, including original non-contained values");
     Check(r,e,sprite.texture!=null&&sprite.texture.width==e.textureWidth&&sprite.texture.height==e.textureHeight&&Near(sprite.pixelsPerUnit,e.ppu),"original PPU and real texture/dimensions remain valid");
     var vertices=sprite.vertices;var uv=sprite.uv;var triangles=sprite.triangles;bool finite=vertices!=null&&uv!=null&&triangles!=null&&vertices.All(v=>Finite(v.x)&&Finite(v.y))&&uv.All(v=>Finite(v.x)&&Finite(v.y))&&triangles.All(i=>i<vertices.Length);bool sourcePresence=e.originalVertexCount==0||vertices.Length>0;
     Check(r,e,finite&&sourcePresence,"finite/index-valid loaded geometry; no invented non-empty requirement for empty source buffers");
     if(vertices.Length!=e.originalVertexCount||triangles.Length*2!=e.originalIndexBytes)r.geometryCountDifferences.Add(new GeometryObservation{asset=e.asset,sourceGroup=e.sourceGroup,originalVertices=e.originalVertexCount,loadedVertices=vertices.Length,originalIndexBytes=e.originalIndexBytes,loadedIndices=triangles.Length});
     Check(r,e,Hash(file+".meta")==e.metaSha256,"original metadata bytes unchanged");
    }catch(Exception ex){Check(r,e,false,"asset validation exception: "+ex);}
   }
  }catch(Exception ex){r.failures.Add(ex.ToString());}
  r.passed=r.failures.Count==0;File.WriteAllText(Path.Combine(r.testRoot,"original-sprite-results.json"),JsonUtility.ToJson(r,true));Debug.Log("OriginalSpriteGeometryVerification sprites="+r.loadedSprites+" checks="+r.checks+" passed="+r.passed+" root="+r.testRoot);return r;
 }
 public static void RunBatch(){var r=RunChecks();EditorApplication.Exit(r.passed?0:1);}
}
}
