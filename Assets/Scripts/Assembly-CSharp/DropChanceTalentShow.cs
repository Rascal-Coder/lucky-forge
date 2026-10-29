using TMPro;
using UnityEngine;

public class DropChanceTalentShow : MonoBehaviour
{
	public TextMeshProUGUI _level;

	public TextMeshProUGUI _dropchancestext;

	public TextMeshProUGUI[] _raritys;

	public TextMeshProUGUI[] _drops;

	public TextMeshProUGUI _bottomtext;

	public TalentFinder _talenfinder;

	public GameObject sagagit;

	public GameObject solagit;

	private int simulatelvl;

	private void Start()
	{
        // Original ARM64 0x21fe4e0.
        _dropchancestext.text=Lang.Get.dropchancesbyg;
        _bottomtext.text=Lang.Get.summoningincrease;
        _raritys[0].text=Lang.Get.kalite_common;
        _raritys[1].text=Lang.Get.kalite_rare;
        _raritys[2].text=Lang.Get.kalite_epic;
        _raritys[3].text=Lang.Get.kalite_legendery;
	}

	private void OnEnable()
	{
        // Original ARM64 0x21fe6e8.
        ChangeLevel(TalentFinder.CurrentLevel);
        SoundManager.instance.RandomizeSfx(SoundManager._click);
	}

	private void ChangeLevel(int lvl)
	{
        // Original ARM64 0x21fe7d4.
        var distribution=_talenfinder.CalculateRarityDistribution(lvl);
        if((uint)lvl>25u)return;
        for(int i=0;i<4;i++)_drops[i].text=distribution[i].ToString("F2")+"%";
        simulatelvl=lvl;
        _level.text=Lang.Get.lv+lvl.ToString();
	}

	public void SagaSola(int nereye)
	{
        // Original ARM64 0x21fea9c.
        ChangeLevel(unchecked(simulatelvl+nereye));
        SoundManager.instance.RandomizeSfx(SoundManager._click);
	}

	private void Update()
	{
        // Original ARM64 0x21feb64.
        sagagit.SetActive(simulatelvl!=25);
        solagit.SetActive(simulatelvl!=0);
	}

	public void Close()
	{
        // Original ARM64 0x21febe8.
        closeit();
	}

	public void closeit()
	{
        // Original ARM64 0x21febec.
        gameObject.SetActive(false);
        SoundManager.instance.RandomizeSfx(SoundManager._close);
	}

	public void Openit()
	{
        // Original ARM64 0x21fecb4.
        gameObject.SetActive(true);
        SoundManager.instance.RandomizeSfx(SoundManager._click);
	}
}
