using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HeroUpgradeSkinTek : MonoBehaviour
{
	public TextMeshProUGUI heroname;

	public TextMeshProUGUI herolevel;

	public TextMeshProUGUI adetkac;

	public Commander commander;

	public HeroUpgradeUI heroUpgradeUI;

	public Image rarityImage;

	public Image icon;

	public GameObject locked;

	public GameObject upginfo;

	public Slider adetslider;

	public GameObject mistik;

	public GameObject favorited;

	public TextMeshProUGUI notowned;

	public Transform rarityColorBacks;

	private void Start()
	{
		// Offline recovery candidate; native RVA 0x2220c70.
		rarityColorBacks.GetChild((int)commander.Rarity).gameObject.SetActive(true);
	}

	private void OnEnable()
	{
		// Offline recovery candidate; native RVA 0x2220cb4.
		notowned.text = GameManager.Level > 2 && commander.CrystalPrice != 0 ? "<sprite=1>" + commander.CrystalPrice.ToString() : Lang.Get.notowned;
	}

	private void Update()
	{
		// Offline recovery candidate; native RVA 0x2220dd0.
		// Original single RET.
	}

	public void UpdateData()
	{
		// Offline recovery candidate; native RVA 0x2220dd4.
		heroname.text = commander.HeroName;
		herolevel.text = Lang.Get.lv + commander.Level.ToString();
		favorited.SetActive(commander.MyFavorite);
		if (commander.Level >= 1) { locked.SetActive(false); mistik.SetActive((int)commander.Rarity == 4); }
		else locked.SetActive(true);
		int mysticRequirement = 0;
		if (commander.IsMystic) {
		    mysticRequirement = heroUpgradeUI.heroController.MistikRequirement[commander.Level];
		    adetkac.text = "<sprite=12>" + Currencys.MistikToken.ToString() + "/" + mysticRequirement.ToString();
		    adetslider.maxValue = heroUpgradeUI.heroController.MistikRequirement[commander.Level];
		    adetslider.value = Currencys.MistikToken;
		} else {
		    adetkac.text = commander.LevelExp.ToString() + "/" + commander.LevelExpMax().ToString();
		    adetslider.maxValue = commander.LevelExpMax();
		    adetslider.value = commander.LevelExp;
		}
		bool ready;
		if (commander.IsMystic) ready = commander.Level < commander.MaxLevel && mysticRequirement <= Currencys.MistikToken;
		else ready = commander.Level < commander.MaxLevel && commander.LevelExp >= commander.LevelExpMax();
		upginfo.SetActive(ready && commander.Level != 0);
	}

	public void OpenIt()
	{
		// Offline recovery candidate; native RVA 0x22212d0.
		heroUpgradeUI.acilantransformsbling = transform.GetSiblingIndex();
		heroUpgradeUI._skinTekUI = this;
		heroUpgradeUI.OneCikanCommander = commander;
		heroUpgradeUI.DataUpdateOneCikan();
		heroUpgradeUI.gameObject.SetActive(true);
		SoundManager.instance.RandomizeSfx(new[] { SoundManager._click });
	}
}
