using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class InventorySlot : MonoBehaviour
{
	public List<Commander> commanders = new List<Commander>();

	public Transform slotTransform;

	public CommanderSpawner commanderSpawner;

	public HeroController heroController;

	public WarController warController;

	public WeaponType type;

	public WeaponRarity rarity;

	public SpriteRenderer RarityColor;

	public Material whiteMat;

	public Material regularMat;

	public CraftAndSell craftAndSell;

	public Transform lightSlotParent;

	public ParticleSystem particleSell;

	public bool IsCompatible(Commander commander)
	{
		// Offline recovery candidate; native RVA 0x223bd94.
		return commander.Type == type && commander.Rarity == rarity && commanders.Count > 0;
	}

	public bool IsFull()
	{
		// Offline recovery candidate; native RVA 0x223be14.
		return commanders.Count > 2;
	}

	public void AddCommander(Commander commander)
	{
		// Offline recovery candidate; native RVA 0x223be64.
		commanders.Add(commander);
		commander.transform.SetParent(slotTransform);
		commander.invSlot = this;
		switch (commanders.Count)
		{
		 case 1:
		  type = commander.Type;
		  rarity = commander.Rarity;
		  commander.transform.localPosition = Vector3.zero;
		  slotTransform.localPosition = Vector3.zero;
		  break;
		 case 2:
		  commander.transform.localPosition = new Vector3(1f,0f,-1f);
		  slotTransform.localPosition = new Vector3(-0.5f,0f,0.5f);
		  break;
		 case 3:
		  commander.transform.localPosition = new Vector3(-1f,0f,1f);
		  slotTransform.localPosition = Vector3.zero;
		  break;
		}
		UpdateRarityVisual();
		SoundManager.instance.YerSesleri(new AudioClip[] {SoundManager._bell});
	}

	public void UpdateRarityVisual()
	{
		// Offline recovery candidate; native RVA 0x223c134.
		if (commanders.Count > 0)
		{
		 RarityColor.gameObject.SetActive(true);
		 RarityColor.color = heroController.rarityColors[(int)rarity];
		}
		else RarityColor.gameObject.SetActive(false);
		foreach (Commander commander in commanders)
		{
		 if (commander.icon == null) continue;
		 commander.icon.material = commanders.Count >= 3 && (int)commander.Rarity != 3 ? whiteMat : regularMat;
		}
		for (int i=0; i<lightSlotParent.childCount; i++) lightSlotParent.GetChild(i).gameObject.SetActive(i == (int)rarity);
		Reposition();
		CommanderMissionManager.UpdateData = true;
	}

	private void Reposition()
	{
		// Offline recovery candidate; native RVA 0x223c46c.
		switch (commanders.Count)
		{
		 case 1: commanders[0].transform.localPosition = Vector3.zero; break;
		 case 2:
		  commanders[0].transform.localPosition = new Vector3(-0.8500000238418579f,0f,0.6700000166893005f);
		  commanders[1].transform.localPosition = new Vector3(1.3700000047683716f,0f,-1.6399999856948853f);
		  break;
		 case 3:
		  commanders[0].transform.localPosition = new Vector3(-0.28999999165534973f,0f,2.109999895095825f);
		  commanders[1].transform.localPosition = new Vector3(1.6200000047683716f,0f,0.5199999809265137f);
		  commanders[2].transform.localPosition = new Vector3(-1.5499999523162842f,0f,-1.159999966621399f);
		  break;
		}
	}

	public void MergeCommanders()
	{
		// Offline recovery candidate; native RVA 0x223c650.
		if (commanders.Count < 3 || commanders[0].IsMystic || (int)commanders[0].Rarity == 3) return;
		foreach (Commander commander in commanders) commanderSpawner.ReturnCommanderToPool(commander);
		if ((int)commanders[0].Rarity == 0) Basarimlar.UpdateBasarimlarT(21,1);
		if ((int)commanders[0].Rarity == 1) Basarimlar.UpdateBasarimlarT(20,1);
		if ((int)commanders[0].Rarity == 2) Basarimlar.UpdateBasarimlarT(11,1);
		commanders.Clear();
		commanderSpawner.TryAddToInventory((int)type,unchecked((int)rarity+1),transform.position,-1);
		UpdateRarityVisual();
		warController.CharAnim.Play("Base Layer.CharMergeyapildi",0,0f);
		SoundManager.instance.YerSesleri(new AudioClip[] {SoundManager.obliriate});
		SoundManager.instance.Titret();
	}

	public void SellCommander(Sprite coin)
	{
		// Offline recovery candidate; native RVA 0x223ca50.
		if (commanders.Count == 0) return;
		var textureAnimation = particleSell.textureSheetAnimation;
		textureAnimation.SetSprite(0,coin);
		particleSell.Play();
		if (commanders[0].IsMystic) heroController.MainHeroSkillActivate(0,1);
		commanderSpawner.ReturnCommanderToPool(commanders[0]);
		commanders.Remove(commanders[0]);
		commanderSpawner.favorites.RefreshPanel();
		UpdateRarityVisual();
		SoundManager.instance.YerSesleri(new AudioClip[] {SoundManager._kirilma});
		SoundManager.instance.Titret();
	}

	public bool IsEmpty()
	{
		// Offline recovery candidate; native RVA 0x223cc54.
		return commanders.Count == 0;
	}

	private void OnMouseUp()
	{
		// Offline recovery candidate; native RVA 0x223cca4.
		if (!IsEmpty() && craftAndSell.readytoopen() && !warController.pageAcik) craftAndSell.OpenCraftSell(this);
		SoundManager.instance.YerSesleri(new AudioClip[] {SoundManager.egg});
	}

	public void ClearArea()
	{
		// Offline recovery candidate; native RVA 0x223cd94.
		foreach (Commander commander in commanders) commanderSpawner.ReturnCommanderToPool(commander);
		commanders.Clear();
		UpdateRarityVisual();
	}

	public bool CanAccept(Commander commander)
	{
		// Offline recovery candidate; native RVA 0x223cf10.
		if (commander.IsMystic) return IsEmpty();
		return IsCompatible(commander) && !IsFull();
	}
}
