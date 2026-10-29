using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SlotMachineUI : MonoBehaviour
{
	public SlotUI[] slotUIs;

	public SlotMachine slotMachine;

	public WarController warController;

	public CommanderSpawner commanderSpawner;

	public TextMeshProUGUI spintxt;

	public TextMeshProUGUI spinningtxt;

	public TextMeshProUGUI spinfiyat;

	public Button btn;

	public AudioSource spinsound;

	public void Spin()
	{
		// Native RVA0x20447d8. Resource/slot guards are evaluated before charge.
		if(!slotMachine||!warController||!commanderSpawner||slotMachine.spining) return;
		if(warController.Silver<slotMachine.SpinFiyat()) { warController.InfoVer("<sprite=\"MeduSprite\" index=7> "+Lang.Get.spintokenyok);return; }
		if(commanderSpawner.IsFull()) { warController.InfoVer("<sprite=\"MeduSprite3\" index=0>"+commanderSpawner.currentCommanderCount+"/"+commanderSpawner.maxCommanderCount+" "+Lang.Get.limit);return; }
		if(spinsound) spinsound.Play();
		var result=slotMachine.RollSlots();if(result==null) return;
		warController.SpendSilver(slotMachine.SpinFiyat());
		int match=0;foreach(var pair in result.typeCounts) if(pair.Value>2) {match=pair.Value;break;}
		if(slotUIs!=null) for(int i=0;i<System.Math.Min(slotUIs.Length,result.slots.Length);i++) if(slotUIs[i]) slotUIs[i].SetSlot(result.slots[i],match,result.winningTypes.Contains(result.slots[i]));
		if(warController.CharAnim) warController.CharAnim.Play("Base Layer.Char_slotdondu",0,0f);
		slotMachine.SpinAdet++;
		if(spinfiyat) spinfiyat.text="<sprite=\"MeduSprite\" index=7>"+slotMachine.SpinFiyat();
		Basarimlar.UpdateBasarimlarT(0,1);
	}

	private void OnEnable()
	{
		if(spinfiyat&&slotMachine) spinfiyat.text="<sprite=\"MeduSprite\" index=7>"+slotMachine.SpinFiyat();
	}

	private void Start()
	{
	}

	public void Titret()
	{
	}

	private void Update()
	{
		if(!warController||!slotMachine) return;
		bool afford=warController.Silver>=slotMachine.SpinFiyat();
		if(btn) btn.interactable=afford&&!slotMachine.spining;
	}
}
