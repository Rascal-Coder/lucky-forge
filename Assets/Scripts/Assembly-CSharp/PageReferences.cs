using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PageReferences : MonoBehaviour
{
	public delegate void PageOrAreaEventHandler();

	[CompilerGenerated]
	private sealed class _003Cfalseit_003Ed__39 : IEnumerator<object>, IEnumerator, IDisposable
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
		public _003Cfalseit_003Ed__39(int _003C_003E1__state)
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
	private sealed class _003Cunchild_003Ed__28 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public PageReferences _003C_003E4__this;

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
		public _003Cunchild_003Ed__28(int _003C_003E1__state)
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

	public GameObject Menu;

	public GameObject Shop;

	public GameObject Karts;

	public GameObject EventsPage;

	public GameObject ChestArea;

	public GameObject KaynakYok;

	public GameObject Guncellemeinfo;

	private bool kaynakpage;

	public TextMeshProUGUI _kaynaksubtitle;

	public TextMeshProUGUI _kaynakbtnustu;

	public CanvasJobs _canvasjobs;

	public Text[] _guncellemelazimtext;

	public Canvas _genelcanvas;

	public Canvas _bottomcanvas;

	public Animator _bottomanim;

	public Animator _genelanim;

	private float timer;

	public Camera _MainCamera;

	public LayerMask _MainCulling;

	public LayerMask _TamSayfaCulling;

	public LayerMask _PerformansCulling;

	public ShopUi _shop;

	public GameObject _starterpackicon;

	public static bool tamsayfa;

	[CompilerGenerated]
	private static PageOrAreaEventHandler m_OnPageOpenedOrAreaClicked;

	public BottomPages _bottomPages;

	public static event PageOrAreaEventHandler OnPageOpenedOrAreaClicked
	{
		[CompilerGenerated]
		add
		{
			// Native event accessor uses Delegate.Combine with compare-exchange retry.
			PageOrAreaEventHandler previous,updated;
			do{
			    previous=m_OnPageOpenedOrAreaClicked;
			    updated=(PageOrAreaEventHandler)Delegate.Combine(previous,value);
			}while(!object.ReferenceEquals(System.Threading.Interlocked.CompareExchange(ref m_OnPageOpenedOrAreaClicked,updated,previous),previous));
		}
		[CompilerGenerated]
		remove
		{
			// Native event accessor uses Delegate.Remove with compare-exchange retry.
			PageOrAreaEventHandler previous,updated;
			do{
			    previous=m_OnPageOpenedOrAreaClicked;
			    updated=(PageOrAreaEventHandler)Delegate.Remove(previous,value);
			}while(!object.ReferenceEquals(System.Threading.Interlocked.CompareExchange(ref m_OnPageOpenedOrAreaClicked,updated,previous),previous));
		}
	}

	private IEnumerator unchild()
	{
		// Native original state machine MoveNext RVA0x201f86c: scaled2s then child2,1,0.
		yield return new WaitForSeconds(2f);
		transform.GetChild(2).transform.parent=null;
		transform.GetChild(1).transform.parent=null;
		transform.GetChild(0).transform.parent=null;
	}

	private void Start()
	{
		// Native RVA0x201eb2c. Original startup labels, Canvas detach coroutine and read-only saved offer display.
		tamsayfa=false;
		StartCoroutine(unchild());
		_kaynaksubtitle.text=Lang.Get.kaynakyoktitle;
		_kaynakbtnustu.text=Lang.Get.kaynakyokbtn;
		_guncellemelazimtext[0].text=Lang.Get.guncellemetitle;
		_guncellemelazimtext[1].text=Lang.Get.guncellemesubtitle;
		// This reads the existing entitlement getter only; no billing/store/network operation is added.
		if(ES3.KeyExists("StarterPack")||GooglePlayPassHandler.IsActive)_starterpackicon.SetActive(false);
	}

	private void Update()
	{
		// Native RVA0x201ed54. Event invokes each Update, including before either early-return guard.
		var handler=m_OnPageOpenedOrAreaClicked;
		if(handler!=null)handler();
		if(GameManager.PerformansMode||GecisControl.savastayim)return;
		_MainCamera.cullingMask=GameManager.PageAcildi&&GameManager.TamPageAcildi?_TamSayfaCulling:_MainCulling;
	}

	public void PageAc_ChestArea()
	{
	}

	public void PageAc_Menu()
	{
		// Native RVA0x201efb0. Existing page guard skips activation, but native still sets flag/plays click.
		if(!GameManager.PageAcildi)Menu.SetActive(true);
		GameManager.PageAcildi=true;
		SoundManager.instance.CashSound(SoundManager._click);
	}

	public void PageAc_Events()
	{
	}

	public void PageAc_Karts()
	{
	}

	public void PageAc_Purchase()
	{
	}

	public void GoMainCulling()
	{
		// Native RVA0x201f400.
		_MainCamera.cullingMask=_MainCulling;
	}

	public void A_PageKapat()
	{
		// Native RVA0x201dd30. Close exactly original local Menu/ChestArea/Karts and restore camera mask.
		SoundManager.instance.RandomizeSfx(SoundManager._close);
		GameManager.lokasyonClicked=0f;
		Menu.SetActive(false);
		ChestArea.SetActive(false);
		Karts.SetActive(false);
		_MainCamera.cullingMask=_MainCulling;
		GameManager.PageAcildi=false;
	}

	[IteratorStateMachine(typeof(_003Cfalseit_003Ed__39))]
	private IEnumerator falseit()
	{
		return null;
	}

	public void CullingMainle()
	{
		// Native RVA0x201f4b0.
		_MainCamera.cullingMask=_MainCulling;
	}

	public void KaynakAc()
	{
		// Native RVA0x201f4e0. Original resource-information overlay, no resource mutation.
		KaynakYok.SetActive(true);
		SoundManager.instance.CashSound(SoundManager._click);
	}

	public void KaynakKapat()
	{
		// Native RVA0x201f5a0.
		KaynakYok.SetActive(false);
		kaynakpage=false;
		SoundManager.instance.RandomizeSfx(SoundManager._close);
	}

	private void Pageacildi()
	{
	}
}
