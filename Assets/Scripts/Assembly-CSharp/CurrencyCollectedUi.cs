using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;

public class CurrencyCollectedUi : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003CEnableAnimatorsWithDelay_003Ed__14 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public bool[] enables;

		public Animator[] animators;

		public float delay;

		private int _003Ci_003E5__2;

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
		public _003CEnableAnimatorsWithDelay_003Ed__14(int _003C_003E1__state)
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

	public TextMeshProUGUI obtained;

	public TextMeshProUGUI coinT;

	public TextMeshProUGUI weaponT;

	public TextMeshProUGUI mistikT;

	public TextMeshProUGUI crystalT;

	public TextMeshProUGUI EnerjiT;

	public TextMeshProUGUI talentT;

	public TextMeshProUGUI passstarT;

	public TextMeshProUGUI zarT;

	private float timer;

	private void Start()
	{
	}

	private void OnEnable()
	{
        // Original ARM64 0x21eb384.
        timer=0f;
	}

	private void Update()
	{
        // Original ARM64 0x21eb38c.
        timer=(float)(timer+Time.deltaTime);
	}

	public void GiveRewardUI(double coin, int weapon, int mistik, int crystal, int enerji, int talent, int passstar, int zar, bool gecisodulu = false)
	{
        // Original ARM64 0x21eb3b8.
        obtained.text=gecisodulu?string.Concat(Lang.Get.lv,GameManager.Level.ToString()," ",Lang.Get.Rewards,"!"):Lang.Get.obtained;
        TextMeshProUGUI[] texts={coinT,weaponT,mistikT,crystalT,EnerjiT,talentT,passstarT,zarT};
        bool[] enables={coin>0.0,weapon>0,mistik>0,crystal>0,enerji>0,talent>0,passstar>0,zar>0};
        for(int i=0;i<8;i++)texts[i].transform.parent.parent.parent.gameObject.SetActive(enables[i]);
        if(coin>0.0)coinT.text=ShortScaleString.parseDouble(coin,1,1000000.0,false).ToString();
        if(weapon>=1)weaponT.text=weapon.ToString();
        if(mistik>=1)mistikT.text=mistik.ToString();
        if(crystal>=1)crystalT.text=crystal.ToString();
        if(enerji>=1)EnerjiT.text=enerji.ToString();
        if(talent>=1){talentT.text=talent.ToString();talentT.text=talent.ToString();}
        if(passstar>=1)passstarT.text=passstar.ToString();
        if(zar>=1)zarT.text=zar.ToString();
        Animator[] animators=new Animator[8];
        for(int i=0;i<8;i++)animators[i]=texts[i].transform.parent.parent.parent.GetComponent<Animator>();
        for(int i=0;i<animators.Length;i++)animators[i].enabled=false;
        gameObject.SetActive(true);
        StartCoroutine(EnableAnimatorsWithDelay(animators,enables,0.3f));
        SoundManager.instance.CashSound(SoundManager._collecting);
	}
	private IEnumerator EnableAnimatorsWithDelay(Animator[] animators, bool[] enables, float delay)
	{
        // Original ARM64 0x21ec0e8.
        for(int i=0;i<animators.Length;i++)
        {
            if(!enables[i])continue;
            animators[i].enabled=true;
            yield return new WaitForSeconds(delay);
        }
	}

	public void CloseRewardUi()
	{
        // Original ARM64 0x21ec1a8.
        if(timer<0.2f)return;
        gameObject.SetActive(false);
        TextMeshProUGUI[] texts={coinT,weaponT,mistikT,crystalT,EnerjiT,talentT,passstarT,zarT};
        for(int i=0;i<8;i++)texts[i].transform.parent.parent.parent.GetComponent<Animator>().enabled=false;
        SoundManager.instance.RandomizeSfx(SoundManager._collecting);
	}
}
