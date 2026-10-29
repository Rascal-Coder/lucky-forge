using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TalentTekliUi : MonoBehaviour
{
	public TextMeshProUGUI _talentName;

	public TextMeshProUGUI _talentLevel;

	public TextMeshProUGUI _talentExp;

	public Slider _talentSlider;

	public Image _rarityColor;

	public Image _talentIcon;

	public GameObject _talentUpgArrow;

	public GameObject _locked;

	public GameObject _show;

	public Talent talent;

	public int talentNum;

	public TalentsUiManager talentsUiManager;

	public bool readyforupg;

	public GameObject kullaniliyor;

	private void Start()
	{
        // Original ARM64 recovery 0x204e250.
        if (_talentName != null) _talentName.text = Lang.GetTalentName(talentNum);
        if (_talentIcon != null) _talentIcon.sprite = talentsUiManager.talentIcons[talentNum];
        if (_rarityColor != null) _rarityColor.color = TalentManager.RarityColors[(int)talent.Rarity];
        UpdateData();
	}

	private void Update()
	{
	}

	public void UpdateData()
	{
        // Original ARM64 recovery 0x204d058.
        if (talent.Level == 0) { if (_locked != null) _locked.SetActive(true); if (_show != null) _show.SetActive(false); return; }
        if (_locked != null) _locked.SetActive(false); if (_show != null) _show.SetActive(true);
        if (_talentLevel != null) _talentLevel.text = Lang.Get.lv + talent.Level.ToString();
        if (_talentExp != null) _talentExp.text = talent.CurrentExp.ToString()+"/"+talent.MaxExp().ToString();
        if (_talentSlider != null) { _talentSlider.maxValue=talent.MaxExp(); _talentSlider.value=talent.CurrentExp; }
        readyforupg = talent.CurrentExp >= talent.MaxExp() && talent.Level != talent.MaxLevel;
        if (_talentUpgArrow != null) _talentUpgArrow.SetActive(readyforupg);
	}

	public void OneCikar()
	{
        // Original ARM64 recovery 0x204e3c0.
        if (talent.Level >= 1)
        {
            if (talentsUiManager.GetAvaliableChoosen() != null && !TalentManager.Kullaniliyor[talentNum])
            { talentsUiManager.GetAvaliableChoosen().Secildi(talent); talentsUiManager.KullaniliyorYazisiYaz(); }
            else talentsUiManager.ShowTalent(talent);
        }
        if (SoundManager.instance != null) SoundManager.instance.CashSound(SoundManager._click);
	}

	public void openit()
	{
        // Original ARM64 recovery 0x204e558.
        if(talent.Level<1)return;
        talentsUiManager.ShowTalent(talent);
        if(SoundManager.instance!=null)SoundManager.instance.CashSound(SoundManager._click);
	}
}
