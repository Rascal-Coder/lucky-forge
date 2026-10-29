using TMPro;
using UnityEngine;

public class infoCurrencyShow : MonoBehaviour
{
	public TextMeshProUGUI title;

	public TextMeshProUGUI owned;

	public TextMeshProUGUI subtitle;

	private Vector3 setpos;

	public RectTransform rect;

	public Transform page;

	public void Show(int kac, Vector3 pos)
	{
        // Original ARM64 0x22258ac.
        owned.text=Lang.Get.owned+": "+adet(kac);
        subtitle.text=Lang.GetInfoBilgi(kac);
        gameObject.SetActive(true);
        setpos=pos;
        transform.position=setpos;
        page.localPosition=Pozisyon();
	}

	private Vector3 Pozisyon()
	{
        // Original ARM64 0x2226270.
        float x=rect.anchoredPosition.x;
        float offset=x>285f?-90f:0f;
        if(x< -285f)offset=90f;
        return new Vector3(offset,73f,0f);
	}

	public void closeit()
	{
        // Original ARM64 0x22262cc.
        gameObject.SetActive(false);
	}

	private string adet(int Num)
	{
        // Original ARM64 0x2225a20.
        switch(Num)
        {
        case 0:case 11:return PlayerData.PlayerStats.HP().ToString();
        case 1:return ShortScaleString.parseDouble(Currencys.Coin,1,1000000.0,false).ToString();
        case 2:return Currencys.Crystal.ToString();
        case 3:return Currencys.Dungeon_1_Key.ToString();
        case 4:return Currencys.Dungeon_2_Key.ToString();
        case 5:return Currencys.Dungeon_3_Key.ToString();
        case 6:return "";
        case 7:return "%";
        case 8:return Currencys.HeroStone.ToString();
        case 9:return GameManager.WeeklyLeaderboardCoin.ToString();
        case 10:case 22:case 24:case 26:return "0";
        case 12:return Currencys.TalentScroll.ToString();
        case 13:return Currencys.MistikToken.ToString();
        case 14:return Currencys.WeaponToken.ToString();
        case 15:return Currencys.GearScroll[0].ToString();
        case 16:return Currencys.GearScroll[1].ToString();
        case 17:return Currencys.GearScroll[2].ToString();
        case 18:return Currencys.GearScroll[3].ToString();
        case 19:return Currencys.GearScroll[4].ToString();
        case 20:return Currencys.GearScroll[5].ToString();
        case 21:return Currencys.Energy.ToString();
        case 23:return Currencys.PetFood.ToString();
        case 25:return Currencys.WallToken.ToString();
        case 27:return Lang.Get.lv+PassGame.Level.ToString();
        case 28:return Currencys.EventDice.ToString();
        default:return "Unknown";
        }
	}
}
