using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

public class GecisControl : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003CDailyWarsGitSiegeLate_003Ed__33 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public GecisControl _003C_003E4__this;

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
		public _003CDailyWarsGitSiegeLate_003Ed__33(int _003C_003E1__state)
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
	private sealed class _003CDungeonGitSiegeLate_003Ed__31 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public GecisControl _003C_003E4__this;

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
		public _003CDungeonGitSiegeLate_003Ed__31(int _003C_003E1__state)
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
	private sealed class _003CGuildRaidGitSiegeLate_003Ed__35 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public GecisControl _003C_003E4__this;

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
		public _003CGuildRaidGitSiegeLate_003Ed__35(int _003C_003E1__state)
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
	private sealed class _003CSavasaBittiSiegeLate_003Ed__29 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public GecisControl _003C_003E4__this;

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
		public _003CSavasaBittiSiegeLate_003Ed__29(int _003C_003E1__state)
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
	private sealed class _003CSavasaGitSiegeLate_003Ed__27 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public GecisControl _003C_003E4__this;

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
		public _003CSavasaGitSiegeLate_003Ed__27(int _003C_003E1__state)
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

	public GameObject[] GenelCanvases;

	public GameObject SiegeBattleArea;

	public WarController warController;

	public CanvasJobs canvasJobs;

	public GameObject gecisanim;

	public DungeonUi dungeonUi;

	public bool gecisyapiliyor;

	public GameObject castleinbattle;

	public KademeliAcilim kademeliAcilim;

	public KademeliAcilimLevel kademeliAciliLevel;

	public GameObject castleArea;

	public Transform MapParent;

	public GameObject eliteObjects;

	public EnergyRightsCanvas enerji;

	public GameManager gameManager;

	public static bool savastayim;

	public AnaSayfaEnemyAyarlaryici anaSayfaEnemy;

	public GameObject eliteChestRewards;

	public GameObject standardChestRewards;

	public CameraHandler cameraHandler;

	public MistikPacksController mistikPacksController;

	private void Start()
	{
		// Recovered from original ARM64 0x2214234.
		MapParent.gameObject.SetActive(false); MapDuzenle();
	}

	public void MapDuzenle()
	{
		// Recovered from original ARM64 0x221426c.
		int level=GameManager.EliteON?GameManager.EliteLevel:GameManager.Level;
		eliteObjects.SetActive(GameManager.EliteON);
		int index=level%MapParent.childCount;
		for(int i=0;i<MapParent.childCount;i++) MapParent.GetChild(i).gameObject.SetActive(i==index);
	}

	public void EliteSwap()
	{
	}

	private void Update()
	{
	}

	private void GenelCanvasIsle(bool durum)
	{
		// Recovered from original ARM64 0x22144fc.
		foreach(GameObject canvas in GenelCanvases) canvas.SetActive(durum);
	}

	public void SavasaGitSiege()
	{
		// Recovered from original ARM64 0x221456c.
		int cost=GameManager.EliteON?7:5;
		if(Currencys.Energy<cost) {
		 if(SoundManager.instance!=null) SoundManager.instance.CashSound(SoundManager._close);
		 enerji.OpenClose(); return;
		}
		if(gecisyapiliyor) return;
		Currencys.SpendEnergy(cost,"Meta","BattleStarted"); gecisanim.SetActive(true);
		if(SoundManager.instance!=null) SoundManager.instance.CashSound(SoundManager.door);
		StartCoroutine(SavasaGitSiegeLate());
	}

	public IEnumerator SavasaGitSiegeLate()
	{
		// Recovered from original ARM64 0x2215ad0.
		gecisyapiliyor=true;
		if(GameManager.GuideDone && SoundManager.instance!=null) SoundManager.instance.stopBackgroundMusic();
		mistikPacksController.Girildi();
		yield return new WaitForSeconds(1f);
		warController.WarTimerSecond=0f; MapParent.gameObject.SetActive(true); cameraHandler.GameIn();
		savastayim=true; SiegeBattleArea.SetActive(true); castleArea.gameObject.SetActive(false); GenelCanvasIsle(false);
		warController.YeniBolumBaslat(GameManager.EliteON?GameManager.EliteLevel:GameManager.Level);
		gecisyapiliyor=false; castleinbattle.SetActive(true);
		if(SoundManager.instance!=null) SoundManager.instance.CashSound(SoundManager.warhorn);
	}

	public void SavasaBittiSiege()
	{
        // Offline recovery from native 0x2214858. Missing-reference guards are intentional.
        if(gecisyapiliyor)return;
        if(gecisanim!=null)gecisanim.SetActive(true);
        if(SoundManager.instance!=null)SoundManager.instance.CashSound(SoundManager.door);
        StartCoroutine(SavasaBittiSiegeLate());
	}
	private IEnumerator SavasaBittiSiegeLate()
	{
        // Offline recovery from native 0x22156e4. Missing-reference guards are intentional.
        gecisyapiliyor=true;
        if(gameManager!=null && gameManager.saveit>27f)gameManager.saveit=27f;
        if(SoundManager.instance!=null)SoundManager.instance.stopBackgroundMusic();
        yield return new WaitForSeconds(1f);
        if(MapParent!=null)MapParent.gameObject.SetActive(false);
        Basarimlar.SaveBasarimlar();
        if(mistikPacksController!=null)mistikPacksController.MistikKontrolYap();
        savastayim=false;
        if(SoundManager.instance!=null)SoundManager.instance.BackgroundMusic(SoundManager._lobby);
        if(gameManager!=null)gameManager.timekazanchesapla=28f;
        if(castleArea!=null)castleArea.SetActive(true);
        if(kademeliAcilim!=null)kademeliAcilim.OnPlayerLevelUp();
        if(kademeliAciliLevel!=null)kademeliAciliLevel.OnPlayerLevelUp();
        if(warController!=null)warController.savastayim=false;
        if(SiegeBattleArea!=null)SiegeBattleArea.SetActive(false);
        GenelCanvasIsle(true);
        if(canvasJobs!=null)canvasJobs.UpdateStageInfos();
        if(warController!=null)
        {
         if(warController.BolumSavasAlaniParent!=null)warController.BolumSavasAlaniParent.SetActive(false);
         if(warController.DungeonSavasAlaniParent!=null)warController.DungeonSavasAlaniParent.SetActive(false);
         if(warController.DailyWarSavasAlaniParent!=null)warController.DailyWarSavasAlaniParent.SetActive(false);
         if(warController.GuildRaidSavasAlaniParent!=null)warController.GuildRaidSavasAlaniParent.SetActive(false);
        }
        if(cameraHandler!=null && cameraHandler.camera!=null){cameraHandler.camera.orthographic=true;cameraHandler.camera.orthographicSize=71.2f;}
        Time.timeScale=1f;
        gecisyapiliyor=false;
        infoIcons.saatlikOdulCheck=true;
        MapDuzenle();
        if(WarController.Dungeondayim && dungeonUi!=null)dungeonUi.DungeonTamamlandi();
	}

	public void DungeonGit()
	{
		// Offline recovery candidate; native RVA 0x22149e4.
		if(gecisyapiliyor)return;
		gecisanim.SetActive(true);
		SoundManager.instance.CashSound(SoundManager.door);
		StartCoroutine(DungeonGitSiegeLate());
	}

	private IEnumerator DungeonGitSiegeLate()
	{
		// Offline recovery candidate; native RVA 0x2214adc / MoveNext 0x2215164.
		gecisyapiliyor=true;
		SoundManager.instance.stopBackgroundMusic();
		yield return new WaitForSeconds(1f);
		cameraHandler.GameIn();
		savastayim=true;
		SoundManager.instance.CashSound(SoundManager.warhorn);
		SiegeBattleArea.SetActive(true);
		GenelCanvasIsle(false);
		castleArea.gameObject.SetActive(false);
		warController.BolumSavasAlaniParent.SetActive(false);
		warController.DungeonSavasAlaniParent.SetActive(true);
		warController.DailyWarSavasAlaniParent.SetActive(false);
		warController.GuildRaidSavasAlaniParent.SetActive(false);
		warController.GoDungeon();
		castleinbattle.SetActive(true);
		gecisyapiliyor=false;
	}

	public void DailyWarsGit()
	{
	}

	[IteratorStateMachine(typeof(_003CDailyWarsGitSiegeLate_003Ed__33))]
	private IEnumerator DailyWarsGitSiegeLate()
	{
		return null;
	}

	public void GuildRaidGit()
	{
	}

	[IteratorStateMachine(typeof(_003CGuildRaidGitSiegeLate_003Ed__35))]
	private IEnumerator GuildRaidGitSiegeLate()
	{
		return null;
	}
}
