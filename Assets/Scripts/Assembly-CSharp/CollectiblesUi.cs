using TMPro;
using UnityEngine;

public class CollectiblesUi : MonoBehaviour
{
	public TextMeshProUGUI title;

	public CollectiblesManager collectiblesManager;

	public Transform content;

	private void OnEnable()
	{
		// Native RVA0x1f58a64 tailcalls original display refresh.
		Ayarla();
	}

	private void Start()
	{
		// Native RVA0x1f58d28.
		title.text=Lang.Get.Collections_new;
	}

	private void Update()
	{
	}

	private void Ayarla()
	{
		// Native RVA0x1f58a68. Only display existing collected rows; no grants or bonus calculation.
		for(int i=0;i<collectiblesManager.allCollectibles.Count;i++){
		    if(!collectiblesManager.allCollectibles[i].Collected)continue;
		    content.GetChild(i).GetChild(0).GetChild(0).GetComponent<UnityEngine.UI.Image>().sprite=collectiblesManager.collectiblesicons[i];
		    content.GetChild(i).GetChild(1).GetComponent<TMPro.TextMeshProUGUI>().text=collectiblesManager.Names(i);
		    content.GetChild(i).GetChild(2).GetComponent<TMPro.TextMeshProUGUI>().text=collectiblesManager.Ozellik(collectiblesManager.allCollectibles[i].StatName)+" "+collectiblesManager.allCollectibles[i].Value.ToString()+"%";
		    content.GetChild(i).gameObject.SetActive(true);
		}
	}

	public void OpenClose()
	{
		// Native RVA0x1f58db8. Original close sound is used in both directions.
		if(GuideJustGear.LockGearClick)return;
		SoundManager.instance.RandomizeSfx(SoundManager._close);
		gameObject.SetActive(!gameObject.activeInHierarchy);
	}
}
