using System.Collections.Generic;
using TMPro;
using UnityEngine;
namespace LuckyForge.Offline.Editor {
public static class InfoPanelFixtureSupport {
 static readonly Dictionary<Transform,List<GameObject>> roots=new Dictionary<Transform,List<GameObject>>();
 static GameObject Child(Transform parent,string name){var g=new GameObject(name,typeof(RectTransform));g.transform.SetParent(parent,false);return g;}
 public static CurrencyCollectedUi CreateRewardPopup(Transform owner){
  // Separate active presentation root: gameplay fixture roots intentionally stay inactive.
  var g=new GameObject("isolated-real-reward-presentation",typeof(RectTransform));g.SetActive(false);
  var p=g.AddComponent<CurrencyCollectedUi>();p.enabled=true;
  p.obtained=Child(g.transform,"obtained").AddComponent<TextMeshProUGUI>();
  var texts=new TextMeshProUGUI[8];
  for(int i=0;i<8;i++){var row=Child(g.transform,"reward-row-"+i);row.AddComponent<Animator>().enabled=false;var a=Child(row.transform,"outer");var b=Child(a.transform,"inner");texts[i]=Child(b.transform,"amount").AddComponent<TextMeshProUGUI>();}
  p.coinT=texts[0];p.weaponT=texts[1];p.mistikT=texts[2];p.crystalT=texts[3];p.EnerjiT=texts[4];p.talentT=texts[5];p.passstarT=texts[6];p.zarT=texts[7];
  if(!roots.ContainsKey(owner))roots[owner]=new List<GameObject>();roots[owner].Add(g);
  EnsureSound(owner);g.SetActive(true);return p;
 }
 public static void EnsureSound(Transform owner){if(SoundManager.instance!=null)return;var g=Child(owner,"isolated-disabled-SoundManager");g.SetActive(false);var s=g.AddComponent<SoundManager>();s.enabled=false;SoundManager.instance=s;}
 public static void Dispose(Transform owner){List<GameObject> list;if(!roots.TryGetValue(owner,out list))return;foreach(var g in list)if(g!=null){var p=g.GetComponent<CurrencyCollectedUi>();p.StopAllCoroutines();Object.DestroyImmediate(g);}roots.Remove(owner);}
}
}
