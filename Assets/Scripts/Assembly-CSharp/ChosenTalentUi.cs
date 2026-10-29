using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ChosenTalentUi : MonoBehaviour
{
	public Talent choosenTalent;

	public Image icon;

	public GameObject lockedicon;

	public GameObject openedicon;

	public TextMeshProUGUI fiyat;

	public int kristalfiyat;

	public TalentsUiManager talentsUiManager;

	public int mynum;

	public ChosenTalentUi bendensonraki;

	public GameObject plusicon;

	public Image rarityback;

	private void Start()
	{
        // Original ARM64 recovery 0x21d1dc8.
        if (mynum == 0 && !talentsUiManager.ChoosenlarAlinmis[0])
        {
            talentsUiManager.ChoosenlarAlinmis[0]=true;
            ES3.Save<bool[]>("choosentalentalinmisX",talentsUiManager.ChoosenlarAlinmis);
            if (icon != null) icon.gameObject.SetActive(false);
        }
        bool unlocked=talentsUiManager.ChoosenlarAlinmis[mynum];
        if (lockedicon != null) lockedicon.SetActive(!unlocked); if (openedicon != null) openedicon.SetActive(unlocked);
        if (fiyat != null) fiyat.text="<sprite=1>"+kristalfiyat.ToString();
        if (choosenTalent != null && choosenTalent.Level >= 1)
        {
            if(icon != null) {icon.sprite=talentsUiManager.talentIcons[choosenTalent.Num];icon.gameObject.SetActive(true);}
            if(rarityback != null) rarityback.color=talentsUiManager.talentManager.rarityColorspublic[(int)choosenTalent.Rarity];
            if(plusicon != null) plusicon.SetActive(false);
        }
        else
        {
            if(icon != null) icon.gameObject.SetActive(false);if(plusicon != null) plusicon.SetActive(true);
            if(rarityback != null) rarityback.color=new Color(.5f,.5f,.5f,1f);
        }
	}

	public void OnClickedthis()
	{
        // Original ARM64 recovery 0x21d20b4.
        if(talentsUiManager.ChoosenlarAlinmis[mynum])
        {
            if(choosenTalent==null)return;
            TalentManager.Kullaniliyor[choosenTalent.Num]=false;
            talentsUiManager.talentManager.ClearTalent(choosenTalent.TargetStat);
            // Original online analytics omitted.
            choosenTalent=null;
            if(icon!=null)icon.gameObject.SetActive(false);
            ES3.Save<bool[]>("KullanilanTalentlar",TalentManager.Kullaniliyor);
            talentsUiManager.KullaniliyorYazisiYaz();
            talentsUiManager.talentManager.ApplyTalents();
            if(rarityback!=null)rarityback.color=new Color(.5f,.5f,.5f,1f);
        }
        else
        {
            if(Currencys.Crystal<kristalfiyat)
            {
                if(talentsUiManager.canvasJobs!=null)talentsUiManager.canvasJobs.OpenGoldYok(4);
                return;
            }
            Currencys.SpendCrystal(kristalfiyat,"Meta","TalentsNewSlot_"+mynum.ToString());
            talentsUiManager.ChoosenlarAlinmis[mynum]=true;
            ES3.Save<bool[]>("choosentalentalinmisX",talentsUiManager.ChoosenlarAlinmis);
            if(lockedicon!=null)lockedicon.SetActive(false);
            if(openedicon!=null)openedicon.SetActive(true);
            if(icon!=null)icon.gameObject.SetActive(false);
            BendenSonrakiniAc();talentsUiManager.LoadTopTxt();
        }
        if(plusicon!=null)plusicon.SetActive(true);
	}

	private void OnEnable()
	{
        // Original ARM64 recovery 0x21d2664.
        BendenSonrakiniAc();
	}

	public void BendenSonrakiniAc()
	{
        // Original ARM64 recovery 0x21d2588.
        if (bendensonraki != null) bendensonraki.gameObject.SetActive(talentsUiManager.ChoosenlarAlinmis[mynum]);
	}

	public void Secildi(Talent kim)
	{
        // Original ARM64 recovery 0x21d2668.
        TalentManager.Kullaniliyor[kim.Num] = true; choosenTalent=kim;
        if(icon != null) {icon.gameObject.SetActive(true);icon.sprite=talentsUiManager.talentIcons[kim.Num];}
        if(rarityback != null) rarityback.color=talentsUiManager.talentManager.rarityColorspublic[(int)kim.Rarity];
        ES3.Save<bool[]>("KullanilanTalentlar",TalentManager.Kullaniliyor);
        if(plusicon != null) plusicon.SetActive(!TalentManager.Kullaniliyor[kim.Num]);
        talentsUiManager.talentManager.ApplyTalents();
        // Original online analytics deliberately omitted.
	}

	private void Update()
	{
	}
}
