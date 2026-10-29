using TMPro;
using UnityEngine;

public class DropChanceKarts : MonoBehaviour
{
	public TextMeshProUGUI _level;

	public TextMeshProUGUI _dropchancestext;

	public TextMeshProUGUI[] _drops;

	public TextMeshProUGUI _bottomtext;

	public FindNewWeapons _mainFinder;

	public GameObject sagagit;

	public GameObject solagit;

	private int simulatelvl;

	private void Start()
	{
        // Original ARM64 0x21fd874.
        _dropchancestext.text=Lang.Get.dropchancesbyg;
        _bottomtext.text=Lang.Get.summoningincrease;
	}

	private void OnEnable()
	{
        // Original ARM64 0x21fd93c.
        ChangeLevel(FindNewWeapons.CurrentLevel);
        SoundManager.instance.RandomizeSfx(SoundManager._click);
	}

	private void ChangeLevel(int lvl)
	{
        // Original ARM64 0x21fda28.
        var distribution=_mainFinder.CalculateRarityDistribution(lvl);
        if((uint)lvl>25u)return;
        for(int i=0;i<5;i++)_drops[i].text=distribution[i].ToString("F2")+"%";
        simulatelvl=lvl;
        _level.text=Lang.Get.lv+lvl.ToString();
	}

	public void SagaSola(int nereye)
	{
        // Original ARM64 0x21fe1fc.
        ChangeLevel(unchecked(simulatelvl+nereye));
        SoundManager.instance.RandomizeSfx(SoundManager._click);
	}

	private void Update()
	{
        // Original ARM64 0x21fe2c4.
        sagagit.SetActive(simulatelvl!=25);
        solagit.SetActive(simulatelvl!=0);
	}

	public void closeit()
	{
        // Original ARM64 0x21fe348.
        gameObject.SetActive(false);
        SoundManager.instance.RandomizeSfx(SoundManager._click);
	}

	public void Openit()
	{
        // Original ARM64 0x21fe410.
        gameObject.SetActive(true);
        SoundManager.instance.RandomizeSfx(SoundManager._click);
	}
}
