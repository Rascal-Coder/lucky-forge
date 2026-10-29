using TMPro;
using UnityEngine;

public class inventoryPage : MonoBehaviour
{
	public TextMeshProUGUI[] coins;

	public TextMeshProUGUI inventorytitle;

	private void OnEnable()
	{
		// Native RVA0x223a7cc.
		inventorytitle.text=Lang.Get.inventory;Guncel();
	}

	private void Update()
	{
	}

	private void Guncel()
	{
		// Native RVA0x223aa8c. Original 17-resource order, row visibility and formatting.
		coins[0].transform.parent.parent.gameObject.SetActive(Currencys.Crystal>0);
		coins[0].text=Currencys.Crystal.ToString();
		coins[1].transform.parent.parent.gameObject.SetActive(Currencys.Coin>0);
		coins[1].text=ShortScaleString.parseDouble(Currencys.Coin,1,1000000.0,false);
		coins[2].transform.parent.parent.gameObject.SetActive(Currencys.HeroStone>0);
		coins[2].text=Currencys.HeroStone.ToString();
		coins[3].transform.parent.parent.gameObject.SetActive(Currencys.TalentScroll>0);
		coins[3].text=Currencys.TalentScroll.ToString();
		coins[4].transform.parent.parent.gameObject.SetActive(Currencys.Dungeon_1_Key>0);
		coins[4].text=Currencys.Dungeon_1_Key.ToString();
		coins[5].transform.parent.parent.gameObject.SetActive(Currencys.Dungeon_2_Key>0);
		coins[5].text=Currencys.Dungeon_2_Key.ToString();
		coins[6].transform.parent.parent.gameObject.SetActive(Currencys.Dungeon_3_Key>0);
		coins[6].text=Currencys.Dungeon_3_Key.ToString();
		coins[7].transform.parent.parent.gameObject.SetActive(Currencys.MistikToken>0);
		coins[7].text=Currencys.MistikToken.ToString();
		coins[8].transform.parent.parent.gameObject.SetActive(Currencys.WeaponToken>0);
		coins[8].text=Currencys.WeaponToken.ToString();
		coins[9].transform.parent.parent.gameObject.SetActive(Currencys.GearScroll[0]>0);
		coins[9].text=Currencys.GearScroll[0].ToString();
		coins[10].transform.parent.parent.gameObject.SetActive(Currencys.GearScroll[1]>0);
		coins[10].text=Currencys.GearScroll[1].ToString();
		coins[11].transform.parent.parent.gameObject.SetActive(Currencys.GearScroll[2]>0);
		coins[11].text=Currencys.GearScroll[2].ToString();
		coins[12].transform.parent.parent.gameObject.SetActive(Currencys.GearScroll[3]>0);
		coins[12].text=Currencys.GearScroll[3].ToString();
		coins[13].transform.parent.parent.gameObject.SetActive(Currencys.GearScroll[5]>0);
		coins[13].text=Currencys.GearScroll[5].ToString();
		coins[14].transform.parent.parent.gameObject.SetActive(Currencys.GearScroll[4]>0);
		coins[14].text=Currencys.GearScroll[4].ToString();
		coins[15].transform.parent.parent.gameObject.SetActive(Currencys.PetFood>0);
		coins[15].text=Currencys.PetFood.ToString();
		coins[16].transform.parent.parent.gameObject.SetActive(Currencys.WallToken>0);
		coins[16].text=Currencys.WallToken.ToString();
		
	}

	public void OpenCloseInventory()
	{
		// Native RVA0x223bc70. No global page flag or invented currency mutation.
		if(GuideJustGear.LockGearClick)return;
		gameObject.SetActive(!gameObject.activeInHierarchy);
		SoundManager.instance.RandomizeSfx(SoundManager._click);
	}
}
