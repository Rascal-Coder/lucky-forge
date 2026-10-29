using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GuideManagerRPG : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003CAgizAnimasyonu_003Ed__47 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public GuideManagerRPG _003C_003E4__this;

		private bool _003Cacik_003E5__2;

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
		public _003CAgizAnimasyonu_003Ed__47(int _003C_003E1__state)
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
	private sealed class _003CDealay1_003Ed__51 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public float time;

		public GuideManagerRPG _003C_003E4__this;

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
		public _003CDealay1_003Ed__51(int _003C_003E1__state)
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
	private sealed class _003CStartLate_003Ed__44 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public GuideManagerRPG _003C_003E4__this;

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
		public _003CStartLate_003Ed__44(int _003C_003E1__state)
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
	private sealed class _003CTypeYazi_003Ed__46 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public GuideManagerRPG _003C_003E4__this;

		public string yazi;

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
		public _003CTypeYazi_003Ed__46(int _003C_003E1__state)
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

	public BottomPages bottomPages;

	public GecisControl geciskontrol;

	public WarController warController;

	public GameObject yaziEkrani;

	public TextMeshProUGUI yazisi;

	public int GuideNum;

	public GameObject welcomeobj;

	public GameObject arrowTalentUse;

	public GameObject arrowMerkezBtn;

	public GameObject arrowBlacksmithBtn;

	public GameObject arrowMistikCommander;

	public GameObject arrowMistikGelistir;

	public GameObject arrowMistikCikisYap;

	public GameObject arrowTalent;

	public GameObject arrowSummonTalent;

	public GameObject arrowFavoriEkle;

	public GameObject arrowCommonSword;

	public GameObject arrowSummonForge;

	public GameObject arrowSpend50x;

	public GameObject arrowCloseForge;

	public GameObject forgePage;

	public Commander commonArrow;

	public GameObject arrowBattle;

	public ScrollRect weaponscrollview;

	public GameObject starterpackbtn;

	public Button[] bottombtns;

	public GameObject CommanderOneCikanPage;

	public GameObject closebtnOneCikanPage;

	public Commander MistikCom;

	public Commander hediyeCom;

	public GameObject enemyshowarea;

	public static bool guidedevamediyor;

	private double coin;

	private float delayclick;

	public GameObject agiz;

	[SerializeField]
	private float yazmaHizi=0.025f;

	private Coroutine yazCoroutine;

	private Coroutine agizCoroutine;

	public KarakterlerGenelUI karakterlerGenelUI;

	public TextMeshProUGUI perfect;

	public TextMeshProUGUI newmistik;

	public GameObject newmistikobj;

	public NotifyCanceler notifyCanceler;

	private bool[] bugfixes=new bool[5];

	private void Start()
	{
		// Recovered from original ARM64 0x221a88c.
		if(GameManager.GuideDone) { gameObject.SetActive(false); return; }
		if(GameManager.Level>=4) { GameManager.GuideDone=true; ES3.Save<bool>("GuideDone",true); gameObject.SetActive(false); return; }
		GuideNum=0; StartCoroutine(StartLate());
	}

	private IEnumerator StartLate()
	{
		// Recovered from original ARM64 0x221c3e0.
		enemyshowarea.SetActive(false); welcomeobj.SetActive(true); Currencys.EnergyFitle(70);
		perfect.text=Lang.Get.super+"!"; newmistik.text=Lang.Get.newmistik;
		yield return new WaitForSeconds(1f);
		StartCoroutine(geciskontrol.SavasaGitSiegeLate());
	}

	public void yaziver(string yazi)
	{
        // Recovered from original ARM64 0x221aa54.
        if (SoundManager.instance != null) SoundManager.instance.AmbienceSfx(SoundManager.necroattack2);
        if (yaziEkrani != null) yaziEkrani.SetActive(true);
        if (yazCoroutine != null) StopCoroutine(yazCoroutine);
        if (agizCoroutine != null) StopCoroutine(agizCoroutine);
        yazCoroutine = StartCoroutine(TypeYazi(yazi));
	}
	private IEnumerator TypeYazi(string yazi)
	{
        // Recovered from original ARM64 0x221c610.
        yazisi.text = "";
        agizCoroutine = StartCoroutine(AgizAnimasyonu());
        int i = 0;
        while (i < yazi.Length)
        {
            if (yazi[i] == '<')
            {
                int end = yazi.IndexOf('>', i);
                if (end != -1)
                {
                    yazisi.text += yazi.Substring(i, end + 1 - i);
                    i = end + 1;
                    continue;
                }
            }
            yazisi.text += yazi[i].ToString();
            i++;
            yield return new WaitForSecondsRealtime(yazmaHizi);
        }
        if (agizCoroutine != null) StopCoroutine(agizCoroutine);
        if (agiz != null) agiz.SetActive(false);
	}
	private IEnumerator AgizAnimasyonu()
	{
        // Recovered from original ARM64 0x221c104.
        bool acik = false;
        while (true)
        {
            acik = !acik;
            if (agiz != null) agiz.SetActive(acik);
            yield return new WaitForSecondsRealtime(UnityEngine.Random.Range(0.05f, 0.25f));
        }
	}

	public void yazikapandi()
	{
        // Recovered from original ARM64 0x221acb8.
        if (delayclick <= 0.5f) return;
        if (yaziEkrani != null) yaziEkrani.SetActive(false);
        delayclick = 0f;
        switch (GuideNum)
        {
            case 0: GuideNum = 1; break;
            case 1: GuideNum = 2; break;
            case 16: GuideNum = 17; break;
            case 18:
                GameManager.GuideDone = true;
                ES3.Save<bool>("GuideDone", true);
                // Offline project deliberately omits native notification scheduling.
                gameObject.SetActive(false);
                break;
            case 200: GuideNum = 8; break;
            case 551: GuideNum = 688; break;
            case 688: GuideNum = 689; break;
            case 555: GuideNum = 556; break;
        }
        if (SoundManager.instance != null) SoundManager.instance.RandomizeSfx(SoundManager._close);
	}

	private void Update()
	{
        // Recovered from original ARM64 0x221aebc.
        // Sequential ifs preserve same-frame state transitions in the native method.
        void Active(GameObject obj, bool value) { if (obj != null) obj.SetActive(value); }
        void Button(int index, bool value) { if (bottombtns != null && index < bottombtns.Length && bottombtns[index] != null) bottombtns[index].interactable = value; }
        delayclick += Time.deltaTime;
        if (warController == null || warController.savastayim) return;
        if (WarController.lastcollectedcoin > 0.0 && GameManager.Level == 1)
        {
            if (GuideNum == 0 && !bugfixes[1])
            {
                Active(enemyshowarea, true);
                yaziver(Lang.Get.guide1);
                Active(starterpackbtn, false);
                Button(0, false); Button(1, false); Button(2, false);
                Button(3, true); Button(4, false); Button(5, false);
                GameManager.GuideDone = true;
                Currencys.EnergyFitle(70);
                ES3.Save<bool>("GuideDone", true);
                guidedevamediyor = true;
                bugfixes[1] = true;
                if (!ES3.KeyExists("guiderewardcoin2"))
                {
                    Currencys.AddCoin(1000.0, "Meta", "GuideReward");
                    ES3.Save<int>("guiderewardcoin2", 1);
                }
            }
            if (GuideNum == 1 && !bugfixes[0])
            {
                yaziver(Lang.Get.PreciousIron_new);
                Active(arrowBlacksmithBtn, true);
                bugfixes[0] = true;
            }
            if (GuideNum == 2)
            {
                if (BottomPages.bottompageopennum == 3) { Active(arrowBlacksmithBtn, false); GuideNum = 552; }
                else Active(arrowBlacksmithBtn, true);
            }
            if (GuideNum == 552)
            {
                if (forgePage.activeInHierarchy)
                {
                    weaponscrollview.vertical = false;
                    Active(arrowSummonForge, false); Active(closebtnOneCikanPage, false);
                    GuideNum = 553;
                }
                else Active(arrowSummonForge, true);
            }
            if (GuideNum == 553)
            {
                if (Currencys.WeaponToken > 49) Active(arrowSpend50x, true);
                else { Active(arrowSpend50x, false); GuideNum = 554; }
            }
            if (GuideNum == 554)
            {
                if (forgePage.activeInHierarchy) Active(arrowCloseForge, true);
                else { Active(arrowCloseForge, false); GuideNum = 555; }
            }
            if (GuideNum == 555)
            {
                if (CommanderOneCikanPage.activeInHierarchy && !bugfixes[2])
                {
                    Active(arrowCommonSword, false);
                    yaziver(Lang.Get.WeveCraftedEnoughCommonSwords_new);
                    bugfixes[2] = true;
                }
                else Active(arrowCommonSword, true);
            }
            if (GuideNum == 556)
            {
                if (commonArrow.Level >= 2)
                {
                    Active(arrowCommonSword, false); Active(closebtnOneCikanPage, true);
                    Active(arrowMistikGelistir, false); weaponscrollview.vertical = true;
                    GuideNum = 557;
                }
                else Active(arrowMistikGelistir, true);
            }
            if (GuideNum == 557)
            {
                if (CommanderOneCikanPage.activeInHierarchy) Active(arrowMistikCikisYap, true);
                else
                {
                    weaponscrollview.vertical = true; Active(arrowMistikCikisYap, false);
                    Button(2, true); Button(5, true); GuideNum = 558;
                }
            }
            if (GuideNum == 558)
            {
                if (BottomPages.bottompageopennum == 2) { Active(arrowMerkezBtn, false); GuideNum = 559; }
                else { Button(5, true); Button(2, true); Active(arrowMerkezBtn, true); }
            }
            if (GuideNum == 559) { GuideNum = 7; Active(arrowBattle, true); }
        }
        if (GameManager.Level == 2)
        {
            if (GuideNum == 7)
            {
                Active(arrowBattle, false); yaziver(Lang.Get.guide4); Active(arrowMerkezBtn, false);
                Button(1, true); GuideNum = 200; guidedevamediyor = false;
            }
            if (GuideNum == 8)
            {
                if (BottomPages.bottompageopennum == 1)
                {
                    Active(arrowTalent, false); GuideNum = 10; guidedevamediyor = false;
                }
                else Active(arrowTalent, true);
            }
            if (GuideNum == 10)
            {
                if (Currencys.TalentScroll > 99) Active(arrowSummonTalent, true);
                else { Active(arrowSummonTalent, false); GuideNum = 550; }
            }
            if (GuideNum == 550)
            {
                if (TalentManager.Kullaniliyor[2])
                {
                    Active(arrowTalentUse, false); yaziver(Lang.Get.guide5);
                    Active(arrowBattle, true); Button(0, true); GuideNum = 551;
                }
                else Active(arrowTalentUse, true);
            }
        }
        if (GameManager.Level == 3)
        {
            if (GuideNum == 688 && !bugfixes[3])
            {
                Active(arrowBattle, false);
                if (!ES3.KeyExists("guiderewardcoin"))
                {
                    Currencys.MistikTokenFitle(10);
                    Currencys.AddCoin(12500.0, "Meta", "GuideReward");
                    ES3.Save<int>("guiderewardcoin", 1);
                }
                yaziver(Lang.Get.MysticalWeaponsAreMorePowerful_new);
                Active(arrowBlacksmithBtn, true); bugfixes[3] = true;
            }
            if (GuideNum == 689)
            {
                Active(arrowBattle, false);
                if (BottomPages.bottompageopennum == 3)
                {
                    karakterlerGenelUI.ForceSortingGuide2(); Active(arrowBlacksmithBtn, false);
                    GuideNum = 3; weaponscrollview.vertical = false;
                }
                else Active(arrowBlacksmithBtn, true);
            }
            if (GuideNum == 3)
            {
                if (CommanderOneCikanPage.activeInHierarchy)
                {
                    Active(arrowMistikCommander, false); Active(closebtnOneCikanPage, false);
                    Active(arrowMistikGelistir, true); GuideNum = 4;
                }
                else Active(arrowMistikCommander, true);
            }
            if (GuideNum == 4)
            {
                if (MistikCom.Level != 2) return;
                weaponscrollview.vertical = true; Active(arrowMistikGelistir, false);
                Active(arrowFavoriEkle, true); GuideNum = 852;
            }
            if (GuideNum == 852)
            {
                if (!MistikCom.MyFavorite) return;
                yaziver(Lang.Get.guide3); Active(arrowMistikGelistir, false);
                Active(arrowMistikCikisYap, true); Active(arrowFavoriEkle, false);
                Active(closebtnOneCikanPage, true); GuideNum = 5;
            }
            if (GuideNum == 5)
            {
                if (CommanderOneCikanPage.activeInHierarchy) Active(arrowMerkezBtn, true);
                else { Active(yaziEkrani, false); Active(arrowMistikCikisYap, false); GuideNum = 15; }
            }
            if (GuideNum == 15)
            {
                if (BottomPages.bottompageopennum != 2) return;
                Active(arrowMerkezBtn, false); Active(arrowBattle, false);
                yaziver(Lang.Get.mysticBladeOffer); hediyeCom.MistikLevelUp();
                StartCoroutine(Dealay1(1.1f)); GuideNum = 16;
            }
            if (GuideNum == 17 && BottomPages.bottompageopennum == 2)
            {
                yaziver(Lang.Get.guide6); GameManager.GuideDone = true;
                ES3.Save<bool>("GuideDone", true); GuideNum = 18;
            }
        }
	}
	private IEnumerator Dealay1(float time)
	{
        // Recovered from original ARM64 0x221c244.
        yield return new WaitForSeconds(time);
        if (newmistikobj != null) newmistikobj.SetActive(true);
        if (SoundManager.instance != null) SoundManager.instance.AmbienceSfx(SoundManager.earthquake);
	}
}
