using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TalentsUiManager : MonoBehaviour
{
	public TalentFinder talentFinder;

	public TalentManager talentManager;

	public Sprite[] talentIcons;

	public TalentTekliUi[] _talentUis;

	public string[] RarityColorCode;

	[Header("Sayfa")]
	public TextMeshProUGUI _sahipOlunanSayi;

	public TextMeshProUGUI _inventory;

	public Slider _talentChestSlider;

	public TextMeshProUGUI _talentChestLevelKacaKac;

	public TextMeshProUGUI[] summonx;

	public Button[] summonbtns;

	public TextMeshProUGUI[] summonprice;

	public TextMeshProUGUI lvl;

	public TextMeshProUGUI _alltalents;

	public RectTransform rect;

	[Header("OneCikan")]
	public GameObject _talentShowObj;

	public CanvasJobs canvasJobs;

	public TextMeshProUGUI _raritytext;

	public TextMeshProUGUI _name;

	public Image _icon;

	public Image _rarityBack;

	public TextMeshProUGUI _level;

	public Slider _slider;

	public TextMeshProUGUI _kacakac;

	public TextMeshProUGUI _talentEffect;

	public TextMeshProUGUI _talentSubtitle;

	public TextMeshProUGUI _simdikiveri;

	public TextMeshProUGUI _sonrakiveri;

	public TextMeshProUGUI _upgradetext;

	public Button _upgBtn;

	private Talent onecikan;

	public Animator _anim;

	public TextMeshProUGUI _upgradePrice;

	public GameObject arrowonecikan;

	public int[] FiyatSetter = new int[] { 1000, 15000, 30000, 80000, 120000, 170000, 300000, 400000, 500000, 600000, 700000, 800000, 900000, 1000000, 1000000, 1000000, 1000000, 1000000, 1000000, 1000000, 1000000, 1000000, 1000000, 1000000, 1000000, 1000000, 1000000, 1000000, 1000000, 1000000, 1000000 };

	[Header("SecimAlani")]
	public bool[] ChoosenlarAlinmis = new bool[10];

	public ChosenTalentUi[] choosenTalentUis;

	public double Fiyat()
	{
        // Original ARM64 recovery 0x204c790.
        return (double)unchecked(FiyatSetter[onecikan.Level]*((int)onecikan.Rarity+1));
	}

	public void LoadChoosenlar()
	{
        // Original ARM64 recovery 0x204bab4.
        if (ES3.KeyExists("choosentalentalinmisX")) ChoosenlarAlinmis = ES3.Load<bool[]>("choosentalentalinmisX");
        int slot = 0;
        for (int i = 0; i < TalentManager.Kullaniliyor.Length; i++)
            if (TalentManager.Kullaniliyor[i]) choosenTalentUis[slot++].choosenTalent = talentManager.TalentsList[i];
        KullaniliyorYazisiYaz();
	}

	public void KullaniliyorYazisiYaz()
	{
        // Original ARM64 recovery 0x204c7d8.
        for (int i=0; i<_talentUis.Length; i++)
            if (_talentUis[i] != null && _talentUis[i].kullaniliyor != null) _talentUis[i].kullaniliyor.SetActive(TalentManager.Kullaniliyor[i]);
	}

	public ChosenTalentUi GetAvaliableChoosen()
	{
        // Original ARM64 recovery 0x204c8f4.
        for (int i=0; i<choosenTalentUis.Length; i++)
            if ((choosenTalentUis[i].choosenTalent == null || choosenTalentUis[i].choosenTalent.Level == 0) && ChoosenlarAlinmis[i]) return choosenTalentUis[i];
        return null;
	}

	private void OnEnable()
	{
        // Original ARM64 recovery 0x204c980.
        if (rect != null) rect.anchoredPosition = new Vector2(rect.anchoredPosition.x, 0f); // Native analytics omitted in offline build.
	}

	private void Start()
	{
        // Original ARM64 recovery 0x204cacc.
        summonx[0].text = Lang.Get.summon + " x1"; summonx[1].text = Lang.Get.summon + " x10";
        summonprice[0].text = "<sprite=5>100"; summonprice[1].text = "<sprite=5>900";
        LoadData(); LoadTopTxt();
	}

	public void LoadTopTxt()
	{
        // Original ARM64 recovery 0x204cc90.
        int count=0; foreach(bool unlocked in ChoosenlarAlinmis) if(unlocked) count++;
        if (_sahipOlunanSayi != null) _sahipOlunanSayi.text = Lang.Get.activetalents + " " + count.ToString() + "/7";
	}

	public void LoadData()
	{
        // Original ARM64 recovery 0x2049de0.
        if (_inventory != null) _inventory.text = Lang.Get.inventory;
        int max = talentFinder.MaxExp();
        if (_talentChestSlider != null) { _talentChestSlider.maxValue=max; _talentChestSlider.value=System.Math.Min(TalentFinder.CurrentExp,max); }
        if (_talentChestLevelKacaKac != null) _talentChestLevelKacaKac.text = TalentFinder.CurrentExp < max ? TalentFinder.CurrentExp.ToString()+"/"+max.ToString() : "MAX";
        if (lvl != null) lvl.text = TalentFinder.CurrentLevel.ToString();
        TopluControl();
	}

	private void Update()
	{
        // Original ARM64 recovery 0x204cebc.
        if (_alltalents != null) _alltalents.text = Currencys.TalentScroll.ToString();
        if (summonbtns.Length > 0 && summonbtns[0] != null) summonbtns[0].interactable = Currencys.TalentScroll > 99;
        if (summonbtns.Length > 1 && summonbtns[1] != null) summonbtns[1].interactable = Currencys.TalentScroll > 899;
	}

	public void TopluControl()
	{
        // Original ARM64 recovery 0x204ce60.
        foreach (var item in _talentUis) if (item != null && item.talent != null) item.UpdateData();
	}

	public void UpgradeTalent()
	{
        // Original ARM64 recovery 0x204d29c.
        if(!onecikan.CheckforUpg() || Currencys.Coin<Fiyat())return;
        Currencys.SpendCoin(Fiyat(),"Meta","TalentUpgrade");
        if(_anim!=null)_anim.Play("Base Layer.talentshowanim",0,0f);
        talentManager.UpgradeTalent(onecikan.Num);
        if(_talentUis[onecikan.Num]!=null)_talentUis[onecikan.Num].UpdateData();
        ShowTalent(onecikan);
        GunlukGorevler.UpdateTaskProgressK(6,1);
	}

	public void ShowTalent(Talent talent)
	{
        // Original ARM64 recovery 0x204d498.
        onecikan=talent;
        string rarity;
        switch(talent.Rarity)
        {
            case RarityTalent.Rare: rarity=Lang.Get.kalite_rare; break;
            case RarityTalent.Epic: rarity=Lang.Get.kalite_epic; break;
            case RarityTalent.Legendary: rarity=Lang.Get.kalite_legendery; break;
            default: rarity=Lang.Get.kalite_common; break;
        }
        if(_upgradePrice!=null)_upgradePrice.text="<sprite=0>"+ShortScaleString.parseDouble(Fiyat(),1,1000000.0,false);
        if(_raritytext!=null)_raritytext.text="<color="+RarityColorCode[(int)talent.Rarity]+">"+rarity+"</color>";
        if(_name!=null)_name.text=Lang.GetTalentName(talent.Num);
        if(_icon!=null)_icon.sprite=talentIcons[talent.Num];
        if(_rarityBack!=null)_rarityBack.color=TalentManager.RarityColors[(int)talent.Rarity];
        if(_level!=null)_level.text=Lang.Get.lv+talent.Level.ToString();
        if(_slider!=null){_slider.maxValue=talent.MaxExp();_slider.value=talent.CurrentExp;}
        if(_kacakac!=null)_kacakac.text=talent.CurrentExp.ToString()+"/"+talent.MaxExp().ToString();
        if(_talentEffect!=null)_talentEffect.text=Lang.Get.lv+talent.Level.ToString()+"/"+talent.MaxLevel.ToString();
        if(_talentSubtitle!=null)_talentSubtitle.text=Lang.GetTalentSubtitle(talent.Num);
        float current=talent.BaseEffectValue+talent.EffectValue*(float)talent.Level;
        if(_simdikiveri!=null)_simdikiveri.text=sonunaEkle(current,talent.Num);
        if(_sonrakiveri!=null)_sonrakiveri.text=sonunaEkle(current+talent.EffectValue,talent.Num);
        if(_upgradetext!=null)_upgradetext.text=talent.Level==talent.MaxLevel ? "MAX" : Lang.Get.gelistir;
        if(_talentShowObj!=null)_talentShowObj.SetActive(true);
        bool ready=talent.CheckforUpg();
        if(arrowonecikan!=null)arrowonecikan.SetActive(ready);
        if(_upgBtn!=null)_upgBtn.interactable=ready && Currencys.Coin>=Fiyat();
	}

	private string sonunaEkle(float effectvalue, int talentNum)
	{
        // Original ARM64 recovery 0x204dc8c.
        if(talentNum==16)return effectvalue.ToString()+" "+Lang.Get.saniyeuzun;
        if(talentNum==15)return effectvalue.ToString()+Lang.Get.kisaltmasaniye;
        if(talentNum>=0 && talentNum<=18 && ((0x40322>>talentNum)&1)!=0)return "+"+effectvalue.ToString();
        if(talentNum>=0 && talentNum<=21 && ((0x3a3c5c>>talentNum)&1)!=0)return effectvalue.ToString()+"%";
        return "x"+effectvalue.ToString();
	}

	public void CloseShow()
	{
        // Original ARM64 recovery 0x204de44.
        if(_talentShowObj!=null)_talentShowObj.SetActive(false);
        if(SoundManager.instance!=null)SoundManager.instance.CashSound(SoundManager._close);
	}

	public void BuyTalent(bool x10)
	{
        // Original ARM64 recovery 0x204df04.
        if (x10)
        {
            if (Currencys.TalentScroll >= 900) { Currencys.SpendTalentScroll(900,"Meta","TalentGet_10x"); talentFinder.OpenMultiple(10); }
        }
        else if (Currencys.TalentScroll >= 100) { Currencys.SpendTalentScroll(100,"Meta","TalentGet_1x"); talentFinder.OpenMultiple(1); }
        if (SoundManager.instance != null) SoundManager.instance.CashSound(SoundManager.talent);
	}
}
