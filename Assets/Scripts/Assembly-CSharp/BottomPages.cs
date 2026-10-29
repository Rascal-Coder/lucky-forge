using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BottomPages : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003CSmoothSizeChange_003Ed__17 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public RectTransform rectTransform;

		public Vector2 targetSize;

		public float duration;

		public byte saydamlik;

		public byte targetsaydamlik;

		public BottomPages _003C_003E4__this;

		public int kim;

		private Vector2 _003CinitialSize_003E5__2;

		private float _003CelapsedTime_003E5__3;

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
		public _003CSmoothSizeChange_003Ed__17(int _003C_003E1__state)
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

	public GameObject[] _pages;

	public RectTransform[] _bottombtnsrects;

	public Button[] _bottombtns;

	public Animator[] _bottomOnclickanims;

	public CanvasJobs _canvasJobs;

	public static int bottompageopennum;

	public Material _siyahBeyaz;

	public int sonacilan = -1;

	public TextMeshProUGUI[] _bottomTexts;

	public RectTransform bottomrect;

	public GameObject chilObj;

	public ReklamGosterge reklamgosterge;

	public void OpenPage(int kim)
	{
        // Native RVA 0x21cb168; only tutorial lock gates this method.
        if (GuideJustGear.LockGearClick) return;
        // Recovery guard: native assumes exactly five valid serialized slots.
        if (kim < 0 || kim >= 5 || _pages == null || kim >= _pages.Length) return;
        if (sonacilan != kim)
        {
            bottompageopennum = kim;
            for (int i = 0; i < 5; i++)
            {
                bool selected = i == kim;
                if (i < _pages.Length && _pages[i] != null) _pages[i].SetActive(selected);
                if (_bottombtns != null && i < _bottombtns.Length && _bottombtns[i] != null)
                {
                    Transform t = _bottombtns[i].transform;
                    if (t.childCount > 2) t.GetChild(2).localScale = Vector3.one * (selected ? 0.5f : 0.4f);
                    Image image = _bottombtns[i].GetComponent<Image>();
                    if (image != null) image.color = selected ? new Color(195f/255f,195f/255f,195f/255f,1) : new Color(113f/255f,113f/255f,113f/255f,1);
                }
                if (selected && _bottomOnclickanims != null && i < _bottomOnclickanims.Length && _bottomOnclickanims[i] != null)
                    _bottomOnclickanims[i].Play("Base Layer.bottomonclickanim", 0, 0);
                if (_bottomTexts != null && i < _bottomTexts.Length && _bottomTexts[i] != null) _bottomTexts[i].gameObject.SetActive(selected);
            }
            if (chilObj != null) chilObj.SetActive(kim != 2);
            GameManager.PageAcildi = GameManager.TamPageAcildi = GameManager.BottomPageOpened = kim != 2;
            sonacilan = kim;
            // Native calls getdata on entering slot 2; this retained local stub
            // must be reviewed separately before any advertising integration.
            if (kim == 2 && reklamgosterge != null) reklamgosterge.getdata();
            SmoothGecis(kim);
        }
        if (SoundManager.instance != null) SoundManager.instance.CashSound(SoundManager._click);
	}

	public void ArkaClose()
	{
        // RVA 0x21cb7d8: hides overlay but intentionally leaves page active state.
        if (chilObj != null) chilObj.SetActive(false);
        GameManager.PageAcildi = GameManager.TamPageAcildi = GameManager.BottomPageOpened = false;
        sonacilan = 2;
        if (SoundManager.instance != null) SoundManager.instance.CashSound(SoundManager._close);
	}

	public void ReturnToBattleTab()
	{
        // RVA 0x21cb8dc: bypasses the tutorial gate and does not play click audio.
        if (!isActiveAndEnabled || !gameObject.activeInHierarchy) return;
        bottompageopennum = 2;
        for (int i=0; i<5; i++)
        {
            bool selected = i == 2;
            if (_pages != null && i < _pages.Length && _pages[i] != null) _pages[i].SetActive(selected);
            if (_bottombtns != null && i < _bottombtns.Length && _bottombtns[i] != null)
            {
                Transform t = _bottombtns[i].transform;
                if (t.childCount > 2) t.GetChild(2).localScale = Vector3.one * (selected ? 0.5f : 0.4f);
                Image image = _bottombtns[i].GetComponent<Image>();
                if (image != null) image.color = selected ? (Color)new Color32(195,195,195,255) : (Color)new Color32(113,113,113,255);
            }
            if (_bottomTexts != null && i < _bottomTexts.Length && _bottomTexts[i] != null) _bottomTexts[i].gameObject.SetActive(selected);
        }
        sonacilan=2;
        if (chilObj != null) chilObj.SetActive(false);
        GameManager.PageAcildi = GameManager.TamPageAcildi = GameManager.BottomPageOpened = false;
        if (gameObject.activeInHierarchy) SmoothGecis(2);
        if (reklamgosterge != null) reklamgosterge.getdata();
	}

	private void Start()
	{
        // RVA 0x21cbcbc: actual Lang properties, no substituted labels.
        OpenPage(2);
        var language = Lang.Get;
        if (language != null)
        {
            if (_bottomTexts != null && _bottomTexts.Length > 0 && _bottomTexts[0] != null) _bottomTexts[0].text = language._bottomTexts1;
            if (_bottomTexts != null && _bottomTexts.Length > 1 && _bottomTexts[1] != null) _bottomTexts[1].text = language._bottomTexts2;
            if (_bottomTexts != null && _bottomTexts.Length > 2 && _bottomTexts[2] != null) _bottomTexts[2].text = language.battle;
            if (_bottomTexts != null && _bottomTexts.Length > 3 && _bottomTexts[3] != null) _bottomTexts[3].text = language._bottomTexts4;
            if (_bottomTexts != null && _bottomTexts.Length > 4 && _bottomTexts[4] != null) _bottomTexts[4].text = language._bottomTexts5;
        }
        if (chilObj != null) chilObj.SetActive(false);
	}

	private void SmoothGecis(int kim)
	{
        // RVA0x21cb63c; floats read from native rodata, selected290.5x196.
        if (!isActiveAndEnabled || !gameObject.activeInHierarchy || _bottombtnsrects == null) return;
        for (int i=0; i<_bottombtnsrects.Length; i++)
        {
            if (_bottombtnsrects[i] == null) continue;
            bool selected = i == kim;
            StartCoroutine(SmoothSizeChange(_bottombtnsrects[i], selected ? new Vector2(290.5f,196f) : new Vector2(200f,186f), 0.2f, (byte)(selected?0:255), (byte)(selected?255:0), i));
        }
	}
	private IEnumerator SmoothSizeChange(RectTransform rectTransform, Vector2 targetSize, float duration, byte saydamlik, byte targetsaydamlik, int kim)
	{
        // MoveNext RVA0x21cbfc4: scaled deltaTime, byte-truncated alpha.
        if (rectTransform == null) yield break;
        Vector2 initialSize=rectTransform.sizeDelta;
        float elapsedTime=0;
        while (elapsedTime < duration)
        {
            if (rectTransform == null) yield break;
            float t=elapsedTime/duration;
            rectTransform.sizeDelta=Vector2.Lerp(initialSize,targetSize,t);
            byte alpha=(byte)Mathf.Lerp(saydamlik,targetsaydamlik,t);
            if (_bottomTexts != null && kim>=0 && kim<_bottomTexts.Length && _bottomTexts[kim] != null) _bottomTexts[kim].color=new Color(1,1,1,alpha/255f);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        // Native sets white/opaque for both selected and unselected labels at end.
        if (_bottomTexts != null && kim>=0 && kim<_bottomTexts.Length && _bottomTexts[kim] != null) _bottomTexts[kim].color=Color.white;
        if (rectTransform != null) rectTransform.sizeDelta=targetSize;
	}
}
