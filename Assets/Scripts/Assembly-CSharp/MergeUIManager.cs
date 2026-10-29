using System.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MergeUIManager : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003CMoveToPosition_003Ed__65 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public MergeUIManager _003C_003E4__this;

		public Transform obj;

		public Vector3 start;

		public Transform target;

		private float _003Ct_003E5__2;

		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return null;
			}
		}

		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return null;
			}
		}

		[DebuggerHidden]
		public _003CMoveToPosition_003Ed__65(int _003C_003E1__state)
		{
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			return false;
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		[DebuggerHidden]
		void IEnumerator.Reset()
		{
		}
	}

	[CompilerGenerated]
	private sealed class _003CPlayMergeAnimation_003Ed__55 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public MergeUIManager _003C_003E4__this;

		public GearInstance previewgear;

		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return null;
			}
		}

		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return null;
			}
		}

		[DebuggerHidden]
		public _003CPlayMergeAnimation_003Ed__55(int _003C_003E1__state)
		{
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			return false;
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		[DebuggerHidden]
		void IEnumerator.Reset()
		{
		}
	}

	public GameObject mergePanel;

	public InventoryManager inventoryManager;

	public InventoryGearUI inventoryUI;

	public MergeSlotUI mainSlot;

	public MergeSlotUI requiredSlot1;

	public MergeSlotUI requiredSlot2;

	public MergeSlotUI previewSlot;

	private GearInstance previewItem;

	public VirtualScroll<GearInstance> gearScroll;

	public Transform inventoryItemParent;

	public GameObject gearButtonPrefab;

	private GearInstance selectedMain;

	public GearInstance mainItem;

	public GearInstance secondItem;

	public GearInstance thirdItem;

	private Vector3 secondItemPos;

	private Vector3 thirdItemPos;

	public Button mergebtn;

	public MergeInventoryTekliUI secondPreviewInfo;

	public MergeInventoryTekliUI thirdPreviewInfo;

	public TextMeshProUGUI bottomtext;

	public TextMeshProUGUI mygears;

	public TextMeshProUGUI automergetxt;

	public TextMeshProUGUI chooseaitem;

	public GameObject itembilgiarea;

	public TextMeshProUGUI mergeditemname;

	public TextMeshProUGUI mergedattack;

	public TextMeshProUGUI mergedattackkacartiyor;

	public TextMeshProUGUI mergedvarsararitybonus;

	public TextMeshProUGUI mergedraritymibonusmuartiyor;

	public TextMeshProUGUI materialrequired;

	public GameObject sagMerges;

	[Header("Merge Anim")]
	public TextMeshProUGUI mergesuccess;

	public GameObject mergeAnimPanel;

	public Image mergeAnimRarity;

	public Image mergeAnimIcon;

	public TextMeshProUGUI mergeAnimLevel;

	public TextMeshProUGUI mergeAnimScore;

	public TextMeshProUGUI mergeAnimGearName;

	public Image mergeAnimGearColor;

	public Image mergeAnimArkaIsik;

	public ParticleSystem mergeAnimBalon;

	public TextMeshProUGUI mergetaptocontunie;

	private bool closemergeanim;

	public float contentYsave;

	private bool useslotref;

	private float moveSpeed;

	private List<GearInstance> mergedItems;

	public Button autoMergeBtn;

	public GameObject mergeResultPopup;

	public Transform mergeResultContent;

	public TextMeshProUGUI automergesucces;

	public TextMeshProUGUI automergetapto;

	private void MergeinfoBilgi()
	{
	}

	private void Start()
	{
		if (requiredSlot1) secondItemPos = requiredSlot1.transform.position;
		if (requiredSlot2) thirdItemPos = requiredSlot2.transform.position;
		var lang = Lang.Get;
		if (chooseaitem) chooseaitem.text = lang.ChooseGearToMerge;
		if (mygears) mygears.text = lang.MyGears;
		if (automergetxt) automergetxt.text = lang.AutoMerge;
		if (mergesuccess) mergesuccess.text = lang.MergeSuccess;
		CheckAutoMergeAvailable();
	}

	public void OpenMerge()
	{
		contentYsave = 0f;
		if (mergePanel) mergePanel.SetActive(true);
		if (inventoryUI && inventoryUI.itemParent) inventoryUI.itemParent.gameObject.SetActive(false);
		ClearSlots();
		CheckAutoMergeAvailable();
	}

	public bool IsAnyMergeAvailable()
	{
		if(!inventoryManager||inventoryManager.inventory==null)return false;
		var all=new List<GearInstance>(inventoryManager.inventory);
		if(inventoryManager.equipped!=null)foreach(var gear in inventoryManager.equipped.Values)if(gear!=null)all.Add(gear);
		foreach(var main in all){
		 if(main==null||!main.template)continue;
		 int count=0;foreach(var other in inventoryManager.inventory)if(other!=main&&IsValidCandidate(main,other)&&++count>=2)return true;
		}
		return false;
	}

	public void CloseMergePanel()
	{
		if (mergePanel) mergePanel.SetActive(false);
		if (inventoryUI && inventoryUI.itemParent) inventoryUI.itemParent.gameObject.SetActive(true);
		if (inventoryUI) { inventoryUI.RefreshUI(); if(inventoryUI.mergearrow) inventoryUI.mergearrow.SetActive(IsAnyMergeAvailable()); }
	}

	public void SelectMainItem(GearInstance gear)
	{
		if(gear==null||!gear.template)return;
		mainItem=gear;secondItem=null;thirdItem=null;
		previewItem=CreatePreviewItem(mainItem);if(previewSlot)previewSlot.SetItem(previewItem);
		RefreshMergeSlotUI();RefreshInventoryList();
	}

	public void SelectCandidateItem(GearInstance gear)
	{
		if (gear == mainItem || gear == secondItem || gear == thirdItem || !IsValidCandidate(mainItem,gear)) return;
		if(secondItem == null) secondItem=gear;
		else if(thirdItem == null) thirdItem=gear;
		RefreshMergeSlotUI(); RefreshInventoryList();
	}

	private GearInstance CreatePreviewItem(GearInstance baseItem)
	{
		// Offline recovery; native RVA 0x200f978.
		if (baseItem == null) return null;
		var result = new GearInstance();
		result.template = baseItem.template;
		result.rarity = baseItem.rarity;
		result.level = baseItem.level;
		result.GearRarityBonus = baseItem.GearRarityBonus;
		if (((result.rarity == GearRarity.Epic || result.rarity == GearRarity.Legendary) && result.GearRarityBonus <= 1) || result.rarity == GearRarity.Mystic)
			result.GearRarityBonus++;
		else { result.rarity = (GearRarity)((int)result.rarity + 1); result.GearRarityBonus = 0; }
		result.GearMergeCount++;
		return result;
	}

	public bool IsValidCandidate(GearInstance main, GearInstance candidate)
	{
		// Native RVA0x200cb24. Equipped objects cannot be consumed as candidate materials.
		if (main == null || candidate == null || !main.template || !candidate.template) return false;
		if (inventoryManager && inventoryManager.equipped != null && inventoryManager.equipped.ContainsValue(candidate)) return false;
		if (main.rarity == GearRarity.Mystic) return candidate.rarity == GearRarity.Mystic && candidate.GetSlot() == main.GetSlot();
		if (main.rarity == GearRarity.Legendary && (uint)main.GearRarityBonus <= 1)
		    return candidate.rarity == GearRarity.Legendary && candidate.GearRarityBonus == main.GearRarityBonus && candidate.GetSlot() == main.GetSlot();
		if (main.rarity == GearRarity.Epic && (uint)main.GearRarityBonus <= 1)
		    return candidate.rarity == GearRarity.Epic && candidate.GearRarityBonus == 0 && candidate.GetSlot() == main.GetSlot();
		return main.template == candidate.template && main.rarity == candidate.rarity && main.GearRarityBonus == candidate.GearRarityBonus;
	}

	private void RefreshMergeSlotUI()
	{
		if(mainSlot) mainSlot.SetItem(mainItem);
		if(requiredSlot1) requiredSlot1.SetItem(secondItem);
		if(requiredSlot2) requiredSlot2.SetItem(thirdItem);
		if(mergebtn) mergebtn.interactable = mainItem != null && secondItem != null && thirdItem != null;
		if(bottomtext) bottomtext.text = mainItem != null && secondItem != null && thirdItem != null ? Lang.Get.ReadyToMerge : Lang.Get.ChooseGearToMerge;
	}

	public void Merge()
	{
		// Native manual merge always requires mainItem+secondItem+thirdItem, including advanced rarity paths.
		if(!inventoryManager||mainItem==null||!mainItem.template||secondItem==null||thirdItem==null)return;
		if(mainItem==secondItem||mainItem==thirdItem||secondItem==thirdItem)return;
		if(!IsValidCandidate(mainItem,secondItem)||!IsValidCandidate(mainItem,thirdItem))return;
		if(inventoryManager.inventory==null||!inventoryManager.inventory.Contains(secondItem)||!inventoryManager.inventory.Contains(thirdItem))return;
		bool wasEquipped=inventoryManager.equipped!=null&&inventoryManager.equipped.ContainsValue(mainItem);
		if(!wasEquipped&&!inventoryManager.inventory.Contains(mainItem))return;
		var result=CreatePreviewItem(mainItem);
		if(wasEquipped)inventoryManager.UnequipGear(mainItem.GetSlot());
		inventoryManager.inventory.Remove(mainItem);inventoryManager.inventory.Remove(secondItem);inventoryManager.inventory.Remove(thirdItem);
		inventoryManager.AddToInventory(result);if(wasEquipped)inventoryManager.EquipGear(result);
		inventoryManager.Save();
		if(Application.isPlaying&&isActiveAndEnabled)StartCoroutine(PlayMergeAnimation(result));
		ClearSlots();inventoryManager.UpdateEquippedUI();
		if(SoundManager.instance)SoundManager.instance.RandomizeSfx(SoundManager._clap);
	}

	[IteratorStateMachine(typeof(_003CPlayMergeAnimation_003Ed__55))]
	private IEnumerator PlayMergeAnimation(GearInstance previewgear)
	{
		// Presentation adapter: original item references, original result panel and native 0.5s close gate.
		closemergeanim=false;
		if(mergeAnimPanel) mergeAnimPanel.SetActive(true);
		if(mergeAnimIcon) mergeAnimIcon.sprite=previewgear.template.icon;
		if(mergeAnimLevel) mergeAnimLevel.text="Lv."+previewgear.level;
		if(mergeAnimGearName) mergeAnimGearName.text=Lang.ItemGearName(previewgear.template.gearName);
		if(mergeAnimRarity) mergeAnimRarity.color=OfflineMergeListAdapter.RarityColor(this,(int)previewgear.rarity);
		if(mergeAnimGearColor) mergeAnimGearColor.color=OfflineMergeListAdapter.RarityColor(this,(int)previewgear.rarity);
		if(mergeAnimBalon) mergeAnimBalon.Play();
		yield return new WaitForSeconds(0.5f);
		closemergeanim=true;
	}

	public void CloseMergeAnim()
	{
		if(closemergeanim && mergeAnimPanel) mergeAnimPanel.SetActive(false);
	}

	public void ClearSlotsbtn()
	{
		ClearSlots();
	}

	public void ClearSlots()
	{
		mainItem=null; secondItem=null; thirdItem=null; previewItem=null;
		if(previewSlot) previewSlot.SetItem(null);
		if(secondPreviewInfo) secondPreviewInfo.gameObject.SetActive(false);
		if(thirdPreviewInfo) thirdPreviewInfo.gameObject.SetActive(false);
		if(itembilgiarea) itembilgiarea.SetActive(false);
		RefreshMergeSlotUI(); RefreshInventoryList();
	}

	private void RefreshInventoryList()
	{
		if(!inventoryManager) return;
		var all = new List<GearInstance>();
		if(inventoryManager.inventory != null) all.AddRange(inventoryManager.inventory);
		if(inventoryManager.equipped != null) foreach(var gear in inventoryManager.equipped.Values) if(gear != null) all.Add(gear);
		all.Sort((x,y) => x == null ? 1 : y == null ? -1 : ((int)y.rarity).CompareTo((int)x.rarity));
		var adapter=GetComponent<OfflineMergeListAdapter>();
		if(!adapter) adapter=gameObject.AddComponent<OfflineMergeListAdapter>();
		adapter.Rebuild(this,all);
	}

	public void OnItemClick(GearInstance gear, Transform kim)
	{
		if(gear == null || gear == mainItem || gear == secondItem || gear == thirdItem) return;
		if(mainItem == null) SelectMainItem(gear);
		else SelectCandidateItem(gear);
	}

	public void GoPos(Transform obj, Vector3 startPos, Transform targetPos)
	{
	}

	[IteratorStateMachine(typeof(_003CMoveToPosition_003Ed__65))]
	private IEnumerator MoveToPosition(Transform obj, Vector3 start, Transform target)
	{
		return null;
	}

	public void AutoMerge()
	{
		// Shared native merge loop; presentation uses the original result panel and slots.
		mergedItems=AutoMergeCore(20);ClearSlots();
		if(inventoryManager)inventoryManager.UpdateEquippedUI();
		RefreshInventoryList();if(inventoryUI)inventoryUI.RefreshUI();
		if(mergedItems.Count>0){ShowMergeResultPopup(mergedItems);CheckAutoMergeAvailable();}
		if(SoundManager.instance)SoundManager.instance.RandomizeSfx(SoundManager._click);
	}

	public List<GearInstance> AutoMergeCore(int maxMerge = 20)
	{
		// RVA0x2010d20. Six original selector lambdas and generic descending/ascending sort flags verified.
		var output=new List<GearInstance>();
		if(!inventoryManager||inventoryManager.inventory==null)return output;
		var work=new List<GearInstance>(inventoryManager.inventory);
		for(int merged=0;merged<maxMerge;merged++){
		 var eligible=work.Where(g=>g!=null&&(int)g.rarity<=2&&g.GearRarityBonus==0).OrderByDescending(g=>g.rarity).ThenBy(g=>g.template.slot).ToList();
		 GearInstance main=null,first=null,second=null;
		 for(int i=0;i<eligible.Count&&second==null;i++){
		  if(eligible[i].rarity==GearRarity.Epic)continue;
		  first=null;second=null;
		  for(int j=0;j<eligible.Count;j++){
		   if(i==j||!IsValidCandidate(eligible[i],eligible[j]))continue;
		   if(first==null)first=eligible[j];else {second=eligible[j];break;}
		  }
		  if(second!=null)main=eligible[i];
		 }
		 if(main==null||first==null||second==null)break;
		 inventoryManager.inventory.Remove(main);inventoryManager.inventory.Remove(first);inventoryManager.inventory.Remove(second);
		 var result=CreatePreviewItem(main);output.Add(result);inventoryManager.AddToInventory(result);
		 work.Remove(main);work.Remove(first);work.Remove(second);work.Add(result);
		}
		ClanTaskLocal.ClanTaskPointEkle(6,output.Count);inventoryManager.Save();return output;
	}

	public void ShowMergeResultPopup(List<GearInstance> items)
	{
		// RVA0x2010ae0: reuse existing children, original rarity background + first-child template icon.
		if(!mergeResultContent)return;
		for(int i=0;i<mergeResultContent.childCount;i++)mergeResultContent.GetChild(i).gameObject.SetActive(false);
		for(int i=0;i<Mathf.Min(items.Count,mergeResultContent.childCount);i++){
		 var gear=items[i];if(gear==null||!gear.template)continue;
		 var row=mergeResultContent.GetChild(i);row.gameObject.SetActive(true);
		 var background=row.GetComponent<Image>();if(background)background.color=OfflineEquipmentViews.ColorFor(inventoryManager,(int)gear.rarity);
		 if(row.childCount>0){var icon=row.GetChild(0).GetComponent<Image>();if(icon)icon.sprite=gear.template.icon;}
		}
		if(mergeResultPopup)mergeResultPopup.SetActive(true);
	}

	public void CloseAutoMerge()
	{
		if(mergeResultPopup)mergeResultPopup.SetActive(false);
	}

	private void CheckAutoMergeAvailable()
	{
		if(!autoMergeBtn)return;
		bool available=false;
		if(inventoryManager&&inventoryManager.inventory!=null){
		 var eligible=inventoryManager.inventory.Where(g=>g!=null&&(int)g.rarity<=2&&g.GearRarityBonus==0).OrderByDescending(g=>g.rarity).ThenBy(g=>g.template.slot).ToList();
		 for(int i=0;i<eligible.Count&&!available;i++){
		  if(eligible[i].rarity==GearRarity.Epic)continue;
		  int count=0;for(int j=0;j<eligible.Count;j++)if(i!=j&&IsValidCandidate(eligible[i],eligible[j])&&++count>=2){available=true;break;}
		 }
		}
		autoMergeBtn.interactable=available;
	}
}
