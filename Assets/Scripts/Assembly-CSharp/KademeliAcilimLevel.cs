using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KademeliAcilimLevel : MonoBehaviour
{
	[Serializable]
	public class ButtonLevelPairer
	{
		public GameObject obje;

		public int requiredLevel;

		public bool butonlu;

		public Button varsaBtn;

		public GameObject lockvarsa;

		public GameObject infovarsa;

		public CanvasGroup canvasgroupvarsa;

		public bool starterpack;

		public bool daily7event;
	}

	public List<ButtonLevelPairer> buttonsWithLevels=new List<ButtonLevelPairer>();

	private void Start()
	{
		// Recovered from original ARM64 0x223d794.
		CheckButtonUnlocks();
	}

	public void OnPlayerLevelUp()
	{
		// Recovered from original ARM64 0x223ddd4.
		CheckButtonUnlocks();
	}

	private void CheckButtonUnlocks()
	{
		// Recovered from original ARM64 0x223d798.
		if(!GameManager.NewUserTapNation){enabled=false;return;}
		foreach(var pair in buttonsWithLevels) {
		 bool gpp=(bool)typeof(GooglePlayPassHandler).GetField("isActive",System.Reflection.BindingFlags.Static|System.Reflection.BindingFlags.NonPublic).GetValue(null);
		 if(gpp && pair.obje && pair.obje.name=="incomepack")pair.obje.SetActive(false);
		 if(GameManager.Level<pair.requiredLevel) {
		  if(pair.butonlu) {
		   if(pair.varsaBtn) pair.varsaBtn.interactable=false;
		   if(pair.lockvarsa) pair.lockvarsa.SetActive(true);
		   if(pair.infovarsa) pair.infovarsa.SetActive(false);
		   if(pair.canvasgroupvarsa) pair.canvasgroupvarsa.alpha=0.699999988079071f;
		  } else if(pair.obje) pair.obje.SetActive(false);
		  continue;
		 }
		 if(pair.butonlu) {
		  if(pair.varsaBtn) pair.varsaBtn.interactable=true;
		  if(pair.lockvarsa) pair.lockvarsa.SetActive(false);
		  if(pair.infovarsa) pair.infovarsa.SetActive(true);
		  if(pair.canvasgroupvarsa) pair.canvasgroupvarsa.alpha=1f;
		  continue;
		 }
		 if(pair.starterpack || pair.daily7event) {
		  if(!gpp && !ES3.KeyExists("StarterPack") && pair.starterpack) { if(pair.obje)pair.obje.SetActive(true); }
		  else if(gpp && pair.starterpack) { if(pair.obje)pair.obje.SetActive(false); }
		  if(!ES3.KeyExists("GunlukHediye7Event") && pair.daily7event) { if(pair.obje)pair.obje.SetActive(true); }
		 } else {
		  if(pair.obje)pair.obje.SetActive(!(gpp && GppIapUi.IsHomeIapObject(pair.obje)));
		 }
		}
	}
}
