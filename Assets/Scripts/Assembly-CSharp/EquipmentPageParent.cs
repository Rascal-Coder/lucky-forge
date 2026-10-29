using TMPro;
using UnityEngine;

public class EquipmentPageParent : MonoBehaviour
{
	public GameObject[] insidePages;

	public GameObject[] bottomBtns;

	public TextMeshProUGUI heroes;

	public TextMeshProUGUI wall;

	public TextMeshProUGUI pet;

	public Transform bottombtnlight;

	private void Start()
	{
		// Native RVA0x22071d8.
		heroes.text=Lang.Get.Heroes;wall.text=Lang.Get.Walls_new;pet.text=Lang.Get.pets;
	}

	private void Update()
	{
	}

	public void OpenInsidePage(int who)
	{
		// Native RVA0x22072e0. Preserve original gear tutorial lock and world-position highlight.
		if(GuideJustGear.LockGearClick)return;
		for(int i=0;i<insidePages.Length;i++){
		    if(i==who){insidePages[who].SetActive(true);bottombtnlight.position=bottomBtns[who].transform.position;}
		    else insidePages[i].SetActive(false);
		}
		gameObject.SetActive(true);
	}

	public void Close()
	{
		// Native RVA0x2207428.
		gameObject.SetActive(false);
	}
}
