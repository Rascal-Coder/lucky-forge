using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FindedWeaponTekliUi : MonoBehaviour
{
	public Image _icon;

	public TextMeshProUGUI _title;

	public Transform raritys;

	public HeroController heroController;

	public Animator animinside;

	public TextMeshProUGUI adet;

	private void Start()
	{
	}

	private void Update()
	{
	}

	public void bilgiGir(Sprite icon, int rarity, string name, bool talentrefund = false, string animstring = "skillacildi", int adetn = 1)
	{
		// Offline recovery candidate; native RVA 0x22092f8.
		if (talentrefund)
		{
		 _title.text = "Payback";
		 gameObject.SetActive(true);
		 _icon.sprite = icon;
		 for (int i=0; i<5; i++) raritys.GetChild(i).gameObject.SetActive(i == 2);
		}
		else
		{
		 _title.text = name;
		 gameObject.SetActive(true);
		 _icon.sprite = icon;
		 adet.text = "x"+adetn.ToString();
		 for (int i=0; i<5; i++) raritys.GetChild(i).gameObject.SetActive(i == rarity);
		}
		animinside.Play("Base Layer."+animstring,0,0f);
	}
}
