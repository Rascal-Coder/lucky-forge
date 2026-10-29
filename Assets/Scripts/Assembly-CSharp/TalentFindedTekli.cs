using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TalentFindedTekli : MonoBehaviour
{
	public Image _icon;

	public TextMeshProUGUI _title;

	public Image _karttiercolor;

	public Transform types;

	public Transform raritys;

	public Animator _anim;

	public Sprite talenticon;

	private void Start()
	{
	}

	private void Update()
	{
	}

	public void bilgiGir(Sprite icon, int rarity, string name, bool talentrefund = false)
	{
        // Original ARM64 recovery 0x20480a0.
        if(_title!=null)_title.text=talentrefund ? "100 "+Lang.Get.talentscroll : name;
        gameObject.SetActive(true);
        if(_icon!=null)_icon.sprite=talentrefund ? talenticon : icon;
        if(_karttiercolor!=null)_karttiercolor.color=TalentManager.RarityColors[talentrefund ? 0 : rarity];
        if(raritys!=null)for(int i=0;i<4 && i<raritys.childCount;i++)raritys.GetChild(i).gameObject.SetActive(i==(talentrefund?0:rarity));
	}
}
