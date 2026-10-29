using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MenuGeneralSettings : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003CCheckCloud_003Ed__65 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public MenuGeneralSettings _003C_003E4__this;

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
		public _003CCheckCloud_003Ed__65(int _003C_003E1__state)
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
	private sealed class _003CSyncFile_003Ed__86 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public MenuGeneralSettings _003C_003E4__this;

		private ES3Settings _003Csettings_003E5__2;

		private ES3Cloud _003Ccloud_003E5__3;

		private AsyncOperation _003Casync_003E5__4;

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
		public _003CSyncFile_003Ed__86(int _003C_003E1__state)
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
	private sealed class _003Codul5crystal_003Ed__79 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

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
		public _003Codul5crystal_003Ed__79(int _003C_003E1__state)
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

	public GameObject optimizationCheck;

	public TextMeshProUGUI _title;

	public Text _Ayarlartitle;

	public Text _Dillertitle;

	public Text _yardimtitle;

	public Text _cloudyukle;

	public Text _destek;

	public Text _privacy;

	public Text _rateus;

	public Text _fpskac;

	public GameObject _gdpr;

	public static bool CloseTextObjects;

	public static bool Optimization;

	public static bool TitresimOnOf;

	public static bool EfektOnOf;

	public static bool MuzikOnOf;

	public static bool BildirimOnOf;

	public static bool Cloudacilmistir;

	public Transform _titresimObj;

	public Transform _muzikObj;

	public Transform _seslerObj;

	public Transform _bildirimlerObj;

	public GameObject _veriKurtarmaPage;

	public GameObject _verilerYazilari;

	public GameObject _veriKurtarmaLoading;

	public GameObject _kurtarilacakVeriYok;

	public Text verititle;

	public Text verisubtitle;

	public Text verisubtitle2;

	public Text veriyiindir;

	public Text veriyiindirbtn;

	public Text verigunceltitle;

	public Text veriguncelsubtitle;

	public Text _medium;

	public Text _high;

	public Text _kalite;

	public GameObject _highobj;

	public GameObject _lowobj;

	public GameObject _dataloadingicon;

	public GameObject _dataoverridepage;

	public GameObject _cloudkapali;

	public GameObject _cloudacik;

	public RateEnabler _rateEnabler;

	public GameObject _credits;

	public GameManager _gm;

	public SkillMine _skillmine;

	public PerformanceMode _performansMode;

	public TextMeshProUGUI[] _joinandget;

	public GameObject instaodul;

	public GameObject discordodul;

	private int setclicked;

	public static int FPS;

	public GameObject _cloudremoveui;

	private void Start()
	{
		// Native RVA0x2008b90. Localized UI and saved local-flag display only; no network operation.
		_joinandget[0].text=Lang.Get.joinandget50;
		_joinandget[1].text=Lang.Get.joinandget50;
		_title.text=Lang.Get.Menutitle;
		_Ayarlartitle.text=Lang.Get.ayarlarbulut;
		_Dillertitle.text=Lang.Get.diller;
		_yardimtitle.text=Lang.Get.yardimiletisim;
		_cloudyukle.text=Lang.Get.bulutakaydet;
		_destek.text=Lang.Get.destek;
		_privacy.text=Lang.Get.privacy;
		_kalite.text=Lang.Get.quality;
		_medium.text=Lang.Get.low;
		_high.text=Lang.Get.high;
		_fpskac.text="FPS "+FPS.ToString();
		_rateus.text=Lang.Get.rateus;
		verititle.text=Lang.Get.verititle;
		verisubtitle.text=Lang.Get.verisubtitle;
		verisubtitle2.text=Lang.Get.verisubtitle2;
		veriyiindir.text=Lang.Get.veriyiindir;
		verigunceltitle.text=Lang.Get.verigunceltitle;
		veriguncelsubtitle.text=Lang.Get.veriguncelsubtitle;
		veriyiindirbtn.text=Lang.Get.veriyiindir;
		_seslerObj.GetChild(0).gameObject.SetActive(!EfektOnOf);
		_titresimObj.GetChild(0).gameObject.SetActive(!TitresimOnOf);
		_muzikObj.GetChild(0).gameObject.SetActive(!MuzikOnOf);
		_bildirimlerObj.GetChild(0).gameObject.SetActive(!BildirimOnOf);
		// Original read-only saved UI flags; cloud/account/permission actions remain outside this patch.
		bool cloud=ES3.KeyExists("Cloudacilmis")&&ES3.Load<bool>("Cloudacilmis");
		_cloudacik.SetActive(cloud);_cloudkapali.SetActive(!cloud);
		_highobj.SetActive(!Optimization);_lowobj.SetActive(Optimization);
		if(ES3.KeyExists("discordodul"))discordodul.gameObject.SetActive(false);
		if(ES3.KeyExists("instaodul"))instaodul.gameObject.SetActive(false);
		optimizationCheck.SetActive(CloseTextObjects);
	}

	private void OnEnable()
	{
		// Native RVA0x2009450, GameManager.saveit offset0xfc.
		_gm.saveit=31f;
	}

	public void OpenCloseTexts()
	{
		// Native RVA0x2009470.
		CloseTextObjects=!CloseTextObjects;
		optimizationCheck.SetActive(CloseTextObjects);
		ES3.Save<bool>("CloseTextObjects",CloseTextObjects);
	}

	public void OpenCloseCredits()
	{
	}

	public void Closepage()
	{
		// Native RVA0x2009578: clear global page flag, close this original object, original click.
		GameManager.PageAcildi=false;
		gameObject.SetActive(false);
		SoundManager.instance.RandomizeSfx(SoundManager._click);
	}

	public void OpenCloseDataOver()
	{
	}

	private void Update()
	{
	}

	public void setfps(int kac)
	{
		// Native RVA0x20096a8; original hidden threshold is eleven calls, and this does not persist FPS.
		setclicked=unchecked(setclicked+1);
		if(setclicked>=11)Application.targetFrameRate=kac;
	}

	public void fpsdegistir()
	{
		// Native RVA0x2009724: 60->120->30->60; any other value becomes60.
		FPS=FPS==60?120:FPS==120?30:60;
		_fpskac.text="FPS "+FPS.ToString();
		Application.targetFrameRate=FPS;
		ES3.Save<int>("FPS",FPS);
	}

	public void OpenRemoveCloudArea(bool nedir)
	{
	}

	public void RemoveMyCloud()
	{
	}

	public void Cloudacilsin()
	{
	}

	[IteratorStateMachine(typeof(_003CCheckCloud_003Ed__65))]
	private IEnumerator CheckCloud()
	{
		return null;
	}

	public void LowHighQuality()
	{
		// Native RVA0x2009b28; true Optimization is low quality0.
		Optimization=!Optimization;
		ES3.Save<bool>("Optimization",Optimization);
		_highobj.SetActive(!Optimization);_lowobj.SetActive(Optimization);
		SoundManager.instance.RandomizeSfx(SoundManager._click);
		QualitySettings.SetQualityLevel(Optimization?0:1);
	}

	public void TitresimAc()
	{
		// Native RVA0x2009ca8: true means vibration disabled.
		TitresimOnOf=!TitresimOnOf;
		ES3.Save<bool>("TitresimOnOf",TitresimOnOf);
		_titresimObj.GetChild(0).gameObject.SetActive(!TitresimOnOf);
		SoundManager.instance.RandomizeSfx(SoundManager._click);
	}

	public void EfektAc()
	{
		// Native RVA0x2009e20: stop/play precisely the original efx and cash sources.
		EfektOnOf=!EfektOnOf;
		ES3.Save<bool>("EfektOnOf",EfektOnOf);
		if(EfektOnOf){SoundManager.instance.efxSource.Stop();SoundManager.instance.CashSource.Stop();}
		else{SoundManager.instance.efxSource.Play();SoundManager.instance.CashSource.Play();}
		_seslerObj.GetChild(0).gameObject.SetActive(!EfektOnOf);
		SoundManager.instance.RandomizeSfx(SoundManager._click);
	}

	public void MuzikAc()
	{
		// Native RVA0x200a018: the original boolean is an OFF flag.
		MuzikOnOf=!MuzikOnOf;
		ES3.Save<bool>("MuzikOnOf",MuzikOnOf);
		if(MuzikOnOf)SoundManager.instance.musicSource.Stop();else SoundManager.instance.musicSource.Play();
		_muzikObj.GetChild(0).gameObject.SetActive(!MuzikOnOf);
		SoundManager.instance.RandomizeSfx(SoundManager._click);
	}

	public void BildirimAc()
	{
	}

	public void DilDegistir(int i)
	{
		// Native RVA0x200adac: original local File save and reload through Loading.
		var settings=new ES3Settings("medupac.es3",new Enum[]{ES3.Location.File});
		GameManager.Language=i;
		ES3.Save<int>("Language",i,settings);
		UnityEngine.SceneManagement.SceneManager.LoadSceneAsync("Loading");
	}

	public void OpenPrivacy()
	{
	}

	public void Rateus()
	{
	}

	public void SupportOpen()
	{
	}

	public void WebsiteOpen()
	{
	}

	public void instagramOpen()
	{
	}

	public void youtubeOpen()
	{
	}

	public void discordOpen()
	{
	}

	[IteratorStateMachine(typeof(_003Codul5crystal_003Ed__79))]
	private IEnumerator odul5crystal()
	{
		return null;
	}

	public void OpenGdpr()
	{
	}

	public void CloseGdpr()
	{
	}

	public void UploaddMyData()
	{
	}

	public void OpenCloudPage()
	{
	}

	public void CloseCloudPage()
	{
	}

	public void DownloadMyData()
	{
	}

	[IteratorStateMachine(typeof(_003CSyncFile_003Ed__86))]
	public IEnumerator SyncFile()
	{
		return null;
	}

	private bool RequestNotificationPermission()
	{
		return false;
	}
}
