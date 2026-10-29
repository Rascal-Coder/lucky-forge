using UnityEngine;
using UnityEngine.UI;

public class LockedforTask : MonoBehaviour
{
	public int LockedKac;

	public int VarsaKim;

	public CanvasJobs _canvasJobs;

	public Button _kimiLockluyor;

	public GameObject _varsaExtraObjesiAcilsin;

	public YeniButonAcildi _yeniAcildi;

	public KartUi _kartLockuysa;

	public Image varsaimgkapat;

	public bool yenisistem;

	private void OnEnable()
	{
		// Native RVA0x2007868. Original lifecycle first disables associated controls, then checks the lock.
		if(_kimiLockluyor!=null)_kimiLockluyor.interactable=false;
		if(_varsaExtraObjesiAcilsin!=null)_varsaExtraObjesiAcilsin.gameObject.SetActive(false);
		OpenLock();
	}

	public void OpenLock()
	{
		// Native RVA0x2007934. The -1 belongs here, not in KademeliAcilimLevel.
		if(GameManager.Level>=unchecked(LockedKac-1)||(yenisistem&&!GameManager.NewUserTapNation)){
		    gameObject.SetActive(false);
		    if(varsaimgkapat!=null)varsaimgkapat.enabled=true;
		    if(_kimiLockluyor!=null)_kimiLockluyor.interactable=true;
		    if(_varsaExtraObjesiAcilsin!=null)_varsaExtraObjesiAcilsin.gameObject.SetActive(true);
		    _yeniAcildi.Bulundu(VarsaKim,unchecked(LockedKac+1),_kartLockuysa);
		}else if(varsaimgkapat!=null)varsaimgkapat.enabled=false;
	}

	public void Clicked()
	{
		// Native RVA0x2007b20, original strict > guard and displayed LockedKac value.
		if(GameManager.Level>LockedKac)return;
		_canvasJobs.OpenKacLvlLazim(LockedKac,false);
		SoundManager.instance.RandomizeSfx(SoundManager._splash);
	}
}
