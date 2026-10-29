using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MysticFavorites : MonoBehaviour
{
	[Header("Ba\ufffdlant\ufffdlar")]
	public HeroController heroController;

	public CommanderSpawner spawner;

	public WarController warController;

	[Header("UI")]
	public Transform contentParent;

	[Header("Rarity A\ufffd\ufffdrl\ufffdklar\ufffd")]
	public Dictionary<WeaponRarity, float> rarityToCommonValue;

	private List<Button> buttons;

	public Animator MistikYapildiAnim;

	public Image MistikYapildiIcon;

	public TextMeshProUGUI mistikyapildi1txt;

	public TextMeshProUGUI mistikyapildi2txt;

	public AudioSource winyaysound;

	public GameObject infoMystics;

	private List<Commander> active => null;

	public void MistikEffectVer(Commander kim)
	{
		// Offline recovery candidate; native RVA 0x20186b8.
		MistikYapildiIcon.sprite = kim.icon.sprite;
		MistikYapildiAnim.gameObject.SetActive(true);
		MistikYapildiAnim.Play("Base Layer.newMysticAnim", 0, 0f);
		mistikyapildi1txt.text = Lang.Get.boostTitle1;
		mistikyapildi2txt.text = kim.HeroName + " " + Lang.Get.isafantastic;
		winyaysound.Play();
		SoundManager.TitretGuclu();
	}

	private void Awake()
	{
	}

	private void OnEnable()
	{
	}

	public void RefreshPanel()
	{
	}

	private List<Commander> GetMatchingCommanders(Commander mystic, out int yuzde)
	{
		yuzde = default;
		return null;
	}

	private void InstantCraft(Commander mystic, List<Commander> used)
	{
	}
}
