using TMPro;
using UnityEngine;

public class YeniButonAcildi : MonoBehaviour
{
	public TextMeshProUGUI _taskkaccompleted;

	public TextMeshProUGUI _bilgitext;

	public TextMeshProUGUI _taptopcontinue;

	public GameObject[] _icons;

	public static int[] bulundu = new int[30];

	private void Start()
	{
		// Native RVA0x2062d70.
		_taptopcontinue.text=Lang.Get.taptocontinue;
	}

	private void Update()
	{
	}

	public void Bulundu(int kim, int seviye, KartUi varsa = null)
	{
		// Native RVA0x2062e00. Existing scene locks use kim0 and return without opening a banner.
		if(kim==0||bulundu[kim]!=0)return;
		GameManager.bilgitimer=0f;
		_taskkaccompleted.text=Lang.Get.task+" "+seviye.ToString()+" "+Lang.Get.tamamlandi;
		gameObject.SetActive(true);
		bulundu[kim]=1;
		ES3.Save<int[]>("BilgiBulundu",bulundu);
		SoundManager.instance.RandomizeSfx(SoundManager._bass);
	}

	private void iconac(int kim)
	{
	}

	public void Closeit()
	{
		// Native RVA0x20631e8. Original external info-timer guard; no invented timer update.
		if(GameManager.bilgitimer>1f){gameObject.SetActive(false);GameManager.bilgitimer=0f;SoundManager.instance.RandomizeSfx(SoundManager._close);}
	}
}
