using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class BolumOdulleri : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003CSmoothMoveCamera_003Ed__24 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public BolumOdulleri _003C_003E4__this;

		public float targetZ;

		private Vector3 _003CstartPos_003E5__2;

		private Vector3 _003CendPos_003E5__3;

		private float _003Ct_003E5__4;

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
		public _003CSmoothMoveCamera_003Ed__24(int _003C_003E1__state)
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

	public List<List<WaveRewardGroup>> manualLevelRewards = new List<List<WaveRewardGroup>>();

	public string es3KeyPrefix = "WaveOdulS_";

	public string es3BolumKey = "BolumOdulResetS";

	public CurrencyCollectedUi collectedUi;

	public int bestSurvive;

	public List<GameObject> waveRewardBoxes = new List<GameObject>();

	public Transform cameraTransform;

	public float minZ = -219.8000030517578f;

	private float maxZ = 161.1999969482422f;

	public float moveDuration = 0.5f;

	public CameraHandler cameraHandler;

	public Transform Bolumler;

	public Transform[] YerlesecekYerler;

	public Transform character;

	public Image[] characterSet;

	public HeroController heroController;

	public Transform portal;

	public CanvasJobs canvasJobs;

	public GameObject[] activeBolumler = new GameObject[3];

	private int[] activeBolumIndices = new int[] { -1, -1, -1 };

	public bool levelalindi;

	private bool started;

	private float oldpozcamera;

	private float timercamera;

	public int currentLevel => GameManager.Level; // Original 0x21b2c5c

	public void MoveCameraToWave(int wave)
	{
        // Original ARM64 recovery 0x21b2cb4.
        cameraHandler.targetZ=(float)((float)((float)wave*7.3f)+minZ);UpdateBolumPositions();
	}

	public void UpdateCharacterPosition()
	{
        // Original ARM64 recovery 0x21b3174.
        if(character==null)return;
        float wave=(float)bestSurvive;float z;
        if(bestSurvive<=5)z=(float)((float)(wave*6.6f)-23f);
        else{
         float factor=bestSurvive<=10?5f:bestSurvive<=15?5.73f:bestSurvive<=20?6.3f:
          bestSurvive<=25?6.6f:bestSurvive<=30?6.77f:bestSurvive<=35?6.89f:bestSurvive<=40?6.99f:
          bestSurvive<=45?7.08f:bestSurvive<=50?7.14f:bestSurvive<=55?7.21f:bestSurvive<=60?7.25f:
          bestSurvive<=65?7.27f:bestSurvive<=70?7.3f:bestSurvive<=75?7.33f:bestSurvive<=80?7.35f:7.399f;
         z=(float)(wave*factor);
        }
        Vector3 p=character.localPosition;p.z=z;character.localPosition=p;
	}

	[IteratorStateMachine(typeof(_003CSmoothMoveCamera_003Ed__24))]
	private IEnumerator SmoothMoveCamera(float targetZ)
	{
		return null;
	}

	private void OnEnable()
	{
        // Original ARM64 recovery 0x21b3430.
        portal.gameObject.SetActive(GameManager.Level>4);oldpozcamera=100000f;
        if(!started)return;
        if(levelalindi){
         bestSurvive=100;cameraHandler.SetTargetZDirect((float)(minZ+20f));MoveCameraToWave(0);
         EskiBolumOdulleri(100);ResetWaveRewards();
         bestSurvive=GameManager.BestSurvive;BolumuYerlestir();UpdateCharacterPosition();
         UpdateMaxZForCurrentLevel();UpdateWaveRewardUI();levelalindi=false;
        }else{
         bestSurvive=GameManager.BestSurvive;UpdateWaveRewardUI();
         // The source scans backwards constructing unused key strings here; no reads or writes.
         cameraHandler.SetTargetZDirect((float)((float)(minZ+(float)((float)bestSurvive*7.3f))-50f));
         MoveCameraToWave(bestSurvive);UpdateCharacterPosition();UpdateMaxZForCurrentLevel();UpdateBolumPositions();
        }
	}

	public void UpdateWaveRewardUI()
	{
        // Original ARM64 recovery 0x21b3748.
        var groups=GetWaveRewardGroupsForCurrentLevel(GameManager.Level);
        for(int i=0;i<waveRewardBoxes.Count;i++){
         var box=waveRewardBoxes[i];
         if(i>=groups.Count){box.SetActive(false);continue;}
         box.SetActive(true);var group=groups[i];var holder=box.transform.GetChild(0);
         var title=holder.GetComponentInChildren<TMPro.TextMeshProUGUI>();
         if(title!=null)title.text=string.Format("{0}",group.wave);
         var panel=box.transform.GetChild(1).gameObject;
         var button=holder.GetComponent<UnityEngine.UI.Button>();
         bool claimed=ES3.KeyExists(es3KeyPrefix+GameManager.Level+"_"+group.wave);
         panel.SetActive(!claimed);button.interactable=!claimed;
         bool reached=group.wave<=bestSurvive;
         if(holder.childCount>=3)holder.GetChild(2).gameObject.SetActive(reached);
         if(holder.childCount>=5)holder.GetChild(4).gameObject.SetActive(reached);
         panel.transform.GetChild(1).gameObject.SetActive(!reached||claimed);
         if(claimed)continue;
         var list=panel.transform.GetChild(0).GetChild(0);
         foreach(Transform item in list){
          item.GetChild(0).GetChild(0).gameObject.SetActive(reached);
          string name=item.name.ToLower();
          var reward=group.rewards.Find(r=>r.rewardType.ToLower()==name);
          item.gameObject.SetActive(reward!=null);
          if(reward==null)continue;
          var text=item.GetComponentInChildren<TMPro.TextMeshProUGUI>();
          if(text==null)continue;
          if(name=="coin"){
           int raw=unchecked((unchecked(reward.amount*GameManager.Level)+reward.amount)*150);
           text.text=ShortScaleString.parseDouble((double)(float)((float)raw*0.6f),1,1000000d,false).ToString();
          }else text.text=reward.amount.ToString();
         }
        }
	}

	public void UpdateMaxZForCurrentLevel()
	{
        // Original ARM64 recovery 0x21b40e4.
        var groups=GetWaveRewardGroupsForCurrentLevel(GameManager.Level);if(groups.Count==0)return;
        float wave=(float)groups[groups.Count-1].wave;
        cameraHandler.maxZ=(float)((float)(wave*6.88f)-194.3f);
        Vector3 p=portal.position;p.z=(float)((float)(wave*7.38f)+75f);portal.position=p;
	}

	public void CharChanged()
	{
		// Offline recovery candidate; native RVA 0x21b4c94.
		int chosen = ES3.Load<int>("MainHeroNum", 0);
		MainHero hero = heroController.mainHeroes[chosen];
		characterSet[0].sprite = hero.iconSet[0];
		characterSet[1].sprite = hero.iconSet[1];
		characterSet[2].sprite = hero.iconSet[2];
		characterSet[3].sprite = hero.iconSet[3];
		characterSet[4].sprite = hero.iconSet[4];
		characterSet[5].sprite = hero.iconSet[5];
		characterSet[6].sprite = hero.iconSet[2];
		characterSet[7].sprite = hero.iconSet[3];
		characterSet[8].sprite = hero.iconSet[4];
		characterSet[9].sprite = hero.iconSet[5];
	}

	public void BolumuYerlestir()
	{
		// Offline recovery candidate; native RVA 0x21b4920.
		GameObject template = Bolumler.GetChild(GameManager.Level % Bolumler.childCount).gameObject;
		for (int i = 0; i < 3; ++i)
		{
		 if (activeBolumler[i] != null) UnityEngine.Object.Destroy(activeBolumler[i]);
		 activeBolumler[i] = UnityEngine.Object.Instantiate(template, YerlesecekYerler[i]);
		 activeBolumler[i].transform.localPosition = Vector3.zero;
		 activeBolumler[i].transform.localRotation = Quaternion.identity;
		 activeBolumler[i].transform.localScale = Vector3.one;
		 activeBolumler[i].SetActive(true);
		 activeBolumIndices[i] = i;
		}
		UpdateBolumPositions();
	}

	private void UpdateBolumPositions()
	{
		// Offline desktop convergence adapter; original single-step RVA 0x21b2ce4 is preserved in UpdateBolumPositionsOnce.
		// Offline desktop adaptation: settle the original single-step recycler after large camera jumps.
		// Keep native constants, ordered branches, existing objects and camera range unchanged.
		while (true)
		{
		 GameObject first = activeBolumler[0], middle = activeBolumler[1], last = activeBolumler[2];
		 Vector3 firstPosition = first.transform.position, middlePosition = middle.transform.position, lastPosition = last.transform.position;
		 bool firstActive = first.activeSelf, middleActive = middle.activeSelf, lastActive = last.activeSelf;
		 UpdateBolumPositionsOnce();
		 if (object.ReferenceEquals(first,activeBolumler[0]) && object.ReferenceEquals(middle,activeBolumler[1]) && object.ReferenceEquals(last,activeBolumler[2])
		     && firstPosition.Equals(activeBolumler[0].transform.position) && middlePosition.Equals(activeBolumler[1].transform.position) && lastPosition.Equals(activeBolumler[2].transform.position)
		     && firstActive == activeBolumler[0].activeSelf && middleActive == activeBolumler[1].activeSelf && lastActive == activeBolumler[2].activeSelf) return;
		}
	}

	private GameObject GetFarthestBolum(bool forward)
	{
		// Offline recovery candidate; native RVA 0x21b4f7c.
		GameObject result = activeBolumler[0];
		foreach (GameObject item in activeBolumler)
		{
		 if (forward ? item.transform.position.z > result.transform.position.z : item.transform.position.z < result.transform.position.z) result = item;
		}
		return result;
	}

	private void Start()
	{
        // Original ARM64 recovery 0x21b508c.
        bestSurvive=GameManager.BestSurvive;
        if(manualLevelRewards==null||manualLevelRewards.Count==0){
         InitManualLevelRewards();UpdateWaveRewardUI();BolumuYerlestir();UpdateCharacterPosition();
         CharChanged();MoveCameraToWave(bestSurvive);UpdateMaxZForCurrentLevel();
        }
        started=true;
	}

	private void InitManualLevelRewards()
	{
        // Original ARM64 recovery 0x21b514c.
        manualLevelRewards=new List<List<WaveRewardGroup>>{
        new List<WaveRewardGroup>{
        new WaveRewardGroup{wave=5,rewards=new List<WaveReward>{new WaveReward{rewardType="coin",amount=2}}},
        new WaveRewardGroup{wave=10,rewards=new List<WaveReward>{new WaveReward{rewardType="coin",amount=5}}},
        },
        new List<WaveRewardGroup>{
        new WaveRewardGroup{wave=5,rewards=new List<WaveReward>{new WaveReward{rewardType="coin",amount=1}}},
        new WaveRewardGroup{wave=10,rewards=new List<WaveReward>{new WaveReward{rewardType="coin",amount=1}}},
        new WaveRewardGroup{wave=15,rewards=new List<WaveReward>{new WaveReward{rewardType="coin",amount=2}}},
        new WaveRewardGroup{wave=20,rewards=new List<WaveReward>{new WaveReward{rewardType="coin",amount=2},new WaveReward{rewardType="talent",amount=100}}},
        },
        new List<WaveRewardGroup>{
        new WaveRewardGroup{wave=5,rewards=new List<WaveReward>{new WaveReward{rewardType="coin",amount=1}}},
        new WaveRewardGroup{wave=10,rewards=new List<WaveReward>{new WaveReward{rewardType="crystal",amount=50}}},
        new WaveRewardGroup{wave=15,rewards=new List<WaveReward>{new WaveReward{rewardType="talent",amount=50}}},
        new WaveRewardGroup{wave=20,rewards=new List<WaveReward>{new WaveReward{rewardType="coin",amount=3},new WaveReward{rewardType="weapon",amount=100}}},
        },
        new List<WaveRewardGroup>{
        new WaveRewardGroup{wave=5,rewards=new List<WaveReward>{new WaveReward{rewardType="coin",amount=1}}},
        new WaveRewardGroup{wave=10,rewards=new List<WaveReward>{new WaveReward{rewardType="crystal",amount=50}}},
        new WaveRewardGroup{wave=15,rewards=new List<WaveReward>{new WaveReward{rewardType="talent",amount=50}}},
        new WaveRewardGroup{wave=20,rewards=new List<WaveReward>{new WaveReward{rewardType="weapon",amount=50}}},
        new WaveRewardGroup{wave=25,rewards=new List<WaveReward>{new WaveReward{rewardType="talent",amount=50}}},
        new WaveRewardGroup{wave=30,rewards=new List<WaveReward>{new WaveReward{rewardType="coin",amount=3},new WaveReward{rewardType="weapon",amount=100}}},
        },
        new List<WaveRewardGroup>{
        new WaveRewardGroup{wave=5,rewards=new List<WaveReward>{new WaveReward{rewardType="coin",amount=1}}},
        new WaveRewardGroup{wave=10,rewards=new List<WaveReward>{new WaveReward{rewardType="coin",amount=2}}},
        new WaveRewardGroup{wave=15,rewards=new List<WaveReward>{new WaveReward{rewardType="mistik",amount=5}}},
        new WaveRewardGroup{wave=20,rewards=new List<WaveReward>{new WaveReward{rewardType="weapon",amount=50}}},
        new WaveRewardGroup{wave=25,rewards=new List<WaveReward>{new WaveReward{rewardType="crystal",amount=100}}},
        new WaveRewardGroup{wave=30,rewards=new List<WaveReward>{new WaveReward{rewardType="weapon",amount=50}}},
        new WaveRewardGroup{wave=35,rewards=new List<WaveReward>{new WaveReward{rewardType="talent",amount=50}}},
        new WaveRewardGroup{wave=40,rewards=new List<WaveReward>{new WaveReward{rewardType="talent",amount=100},new WaveReward{rewardType="weapon",amount=100}}},
        },
        new List<WaveRewardGroup>{
        new WaveRewardGroup{wave=5,rewards=new List<WaveReward>{new WaveReward{rewardType="weapon",amount=50}}},
        new WaveRewardGroup{wave=10,rewards=new List<WaveReward>{new WaveReward{rewardType="coin",amount=2}}},
        new WaveRewardGroup{wave=15,rewards=new List<WaveReward>{new WaveReward{rewardType="crystal",amount=50}}},
        new WaveRewardGroup{wave=20,rewards=new List<WaveReward>{new WaveReward{rewardType="crystal",amount=50}}},
        new WaveRewardGroup{wave=25,rewards=new List<WaveReward>{new WaveReward{rewardType="crystal",amount=100}}},
        new WaveRewardGroup{wave=30,rewards=new List<WaveReward>{new WaveReward{rewardType="coin",amount=2}}},
        new WaveRewardGroup{wave=35,rewards=new List<WaveReward>{new WaveReward{rewardType="talent",amount=50}}},
        new WaveRewardGroup{wave=40,rewards=new List<WaveReward>{new WaveReward{rewardType="coin",amount=5},new WaveReward{rewardType="crystal",amount=750}}},
        },
        new List<WaveRewardGroup>{
        new WaveRewardGroup{wave=5,rewards=new List<WaveReward>{new WaveReward{rewardType="weapon",amount=50}}},
        new WaveRewardGroup{wave=10,rewards=new List<WaveReward>{new WaveReward{rewardType="talent",amount=50}}},
        new WaveRewardGroup{wave=15,rewards=new List<WaveReward>{new WaveReward{rewardType="crystal",amount=50}}},
        new WaveRewardGroup{wave=20,rewards=new List<WaveReward>{new WaveReward{rewardType="mistik",amount=5}}},
        new WaveRewardGroup{wave=25,rewards=new List<WaveReward>{new WaveReward{rewardType="coin",amount=2}}},
        new WaveRewardGroup{wave=30,rewards=new List<WaveReward>{new WaveReward{rewardType="coin",amount=2}}},
        new WaveRewardGroup{wave=35,rewards=new List<WaveReward>{new WaveReward{rewardType="talent",amount=50}}},
        new WaveRewardGroup{wave=40,rewards=new List<WaveReward>{new WaveReward{rewardType="coin",amount=2}}},
        new WaveRewardGroup{wave=45,rewards=new List<WaveReward>{new WaveReward{rewardType="weapon",amount=50}}},
        new WaveRewardGroup{wave=50,rewards=new List<WaveReward>{new WaveReward{rewardType="weapon",amount=100},new WaveReward{rewardType="crystal",amount=300}}},
        },
        new List<WaveRewardGroup>{
        new WaveRewardGroup{wave=5,rewards=new List<WaveReward>{new WaveReward{rewardType="mistik",amount=5}}},
        new WaveRewardGroup{wave=10,rewards=new List<WaveReward>{new WaveReward{rewardType="mistik",amount=5}}},
        new WaveRewardGroup{wave=15,rewards=new List<WaveReward>{new WaveReward{rewardType="crystal",amount=50}}},
        new WaveRewardGroup{wave=20,rewards=new List<WaveReward>{new WaveReward{rewardType="crystal",amount=50}}},
        new WaveRewardGroup{wave=25,rewards=new List<WaveReward>{new WaveReward{rewardType="coin",amount=2}}},
        new WaveRewardGroup{wave=30,rewards=new List<WaveReward>{new WaveReward{rewardType="coin",amount=2}}},
        new WaveRewardGroup{wave=35,rewards=new List<WaveReward>{new WaveReward{rewardType="talent",amount=50}}},
        new WaveRewardGroup{wave=40,rewards=new List<WaveReward>{new WaveReward{rewardType="talent",amount=50}}},
        new WaveRewardGroup{wave=45,rewards=new List<WaveReward>{new WaveReward{rewardType="weapon",amount=50}}},
        new WaveRewardGroup{wave=50,rewards=new List<WaveReward>{new WaveReward{rewardType="coin",amount=5},new WaveReward{rewardType="crystal",amount=200}}},
        },
        new List<WaveRewardGroup>{
        new WaveRewardGroup{wave=5,rewards=new List<WaveReward>{new WaveReward{rewardType="coin",amount=2}}},
        new WaveRewardGroup{wave=10,rewards=new List<WaveReward>{new WaveReward{rewardType="coin",amount=3}}},
        new WaveRewardGroup{wave=15,rewards=new List<WaveReward>{new WaveReward{rewardType="enerji",amount=5}}},
        new WaveRewardGroup{wave=20,rewards=new List<WaveReward>{new WaveReward{rewardType="crystal",amount=400}}},
        new WaveRewardGroup{wave=25,rewards=new List<WaveReward>{new WaveReward{rewardType="coin",amount=4}}},
        new WaveRewardGroup{wave=30,rewards=new List<WaveReward>{new WaveReward{rewardType="coin",amount=5}}},
        new WaveRewardGroup{wave=35,rewards=new List<WaveReward>{new WaveReward{rewardType="mistik",amount=5}}},
        new WaveRewardGroup{wave=40,rewards=new List<WaveReward>{new WaveReward{rewardType="mistik",amount=5}}},
        new WaveRewardGroup{wave=45,rewards=new List<WaveReward>{new WaveReward{rewardType="crystal",amount=200}}},
        new WaveRewardGroup{wave=50,rewards=new List<WaveReward>{new WaveReward{rewardType="weapon",amount=100}}},
        new WaveRewardGroup{wave=55,rewards=new List<WaveReward>{new WaveReward{rewardType="coin",amount=6}}},
        new WaveRewardGroup{wave=60,rewards=new List<WaveReward>{new WaveReward{rewardType="coin",amount=10},new WaveReward{rewardType="crystal",amount=300}}},
        },
        new List<WaveRewardGroup>{
        new WaveRewardGroup{wave=5,rewards=new List<WaveReward>{new WaveReward{rewardType="coin",amount=2}}},
        new WaveRewardGroup{wave=10,rewards=new List<WaveReward>{new WaveReward{rewardType="coin",amount=4}}},
        new WaveRewardGroup{wave=15,rewards=new List<WaveReward>{new WaveReward{rewardType="zar",amount=1}}},
        new WaveRewardGroup{wave=20,rewards=new List<WaveReward>{new WaveReward{rewardType="zar",amount=1}}},
        new WaveRewardGroup{wave=25,rewards=new List<WaveReward>{new WaveReward{rewardType="coin",amount=5}}},
        new WaveRewardGroup{wave=30,rewards=new List<WaveReward>{new WaveReward{rewardType="crystal",amount=150}}},
        new WaveRewardGroup{wave=35,rewards=new List<WaveReward>{new WaveReward{rewardType="zar",amount=1}}},
        new WaveRewardGroup{wave=40,rewards=new List<WaveReward>{new WaveReward{rewardType="zar",amount=1}}},
        new WaveRewardGroup{wave=45,rewards=new List<WaveReward>{new WaveReward{rewardType="weapon",amount=100}}},
        new WaveRewardGroup{wave=50,rewards=new List<WaveReward>{new WaveReward{rewardType="weapon",amount=100}}},
        new WaveRewardGroup{wave=55,rewards=new List<WaveReward>{new WaveReward{rewardType="zar",amount=2}}},
        new WaveRewardGroup{wave=60,rewards=new List<WaveReward>{new WaveReward{rewardType="zar",amount=2}}},
        new WaveRewardGroup{wave=65,rewards=new List<WaveReward>{new WaveReward{rewardType="crystal",amount=200}}},
        new WaveRewardGroup{wave=70,rewards=new List<WaveReward>{new WaveReward{rewardType="zar",amount=5},new WaveReward{rewardType="talent",amount=200}}},
        },
        new List<WaveRewardGroup>{
        new WaveRewardGroup{wave=5,rewards=new List<WaveReward>{new WaveReward{rewardType="coin",amount=2}}},
        new WaveRewardGroup{wave=10,rewards=new List<WaveReward>{new WaveReward{rewardType="coin",amount=3}}},
        new WaveRewardGroup{wave=15,rewards=new List<WaveReward>{new WaveReward{rewardType="weapon",amount=50}}},
        new WaveRewardGroup{wave=20,rewards=new List<WaveReward>{new WaveReward{rewardType="weapon",amount=50}}},
        new WaveRewardGroup{wave=25,rewards=new List<WaveReward>{new WaveReward{rewardType="coin",amount=4}}},
        new WaveRewardGroup{wave=30,rewards=new List<WaveReward>{new WaveReward{rewardType="crystal",amount=150}}},
        new WaveRewardGroup{wave=35,rewards=new List<WaveReward>{new WaveReward{rewardType="coin",amount=5}}},
        new WaveRewardGroup{wave=40,rewards=new List<WaveReward>{new WaveReward{rewardType="crystal",amount=150}}},
        new WaveRewardGroup{wave=45,rewards=new List<WaveReward>{new WaveReward{rewardType="weapon",amount=100}}},
        new WaveRewardGroup{wave=50,rewards=new List<WaveReward>{new WaveReward{rewardType="coin",amount=5}}},
        new WaveRewardGroup{wave=55,rewards=new List<WaveReward>{new WaveReward{rewardType="mistik",amount=5}}},
        new WaveRewardGroup{wave=60,rewards=new List<WaveReward>{new WaveReward{rewardType="mistik",amount=5}}},
        new WaveRewardGroup{wave=65,rewards=new List<WaveReward>{new WaveReward{rewardType="zar",amount=2}}},
        new WaveRewardGroup{wave=70,rewards=new List<WaveReward>{new WaveReward{rewardType="zar",amount=2}}},
        new WaveRewardGroup{wave=75,rewards=new List<WaveReward>{new WaveReward{rewardType="coin",amount=5}}},
        new WaveRewardGroup{wave=80,rewards=new List<WaveReward>{new WaveReward{rewardType="crystal",amount=300},new WaveReward{rewardType="weapon",amount=150}}},
        },
        new List<WaveRewardGroup>{
        new WaveRewardGroup{wave=5,rewards=new List<WaveReward>{new WaveReward{rewardType="crystal",amount=50}}},
        new WaveRewardGroup{wave=10,rewards=new List<WaveReward>{new WaveReward{rewardType="crystal",amount=50}}},
        new WaveRewardGroup{wave=15,rewards=new List<WaveReward>{new WaveReward{rewardType="weapon",amount=50}}},
        new WaveRewardGroup{wave=20,rewards=new List<WaveReward>{new WaveReward{rewardType="crystal",amount=100}}},
        new WaveRewardGroup{wave=25,rewards=new List<WaveReward>{new WaveReward{rewardType="coin",amount=4}}},
        new WaveRewardGroup{wave=30,rewards=new List<WaveReward>{new WaveReward{rewardType="crystal",amount=150}}},
        new WaveRewardGroup{wave=35,rewards=new List<WaveReward>{new WaveReward{rewardType="coin",amount=5}}},
        new WaveRewardGroup{wave=40,rewards=new List<WaveReward>{new WaveReward{rewardType="mistik",amount=5}}},
        new WaveRewardGroup{wave=45,rewards=new List<WaveReward>{new WaveReward{rewardType="weapon",amount=50}}},
        new WaveRewardGroup{wave=50,rewards=new List<WaveReward>{new WaveReward{rewardType="coin",amount=5}}},
        new WaveRewardGroup{wave=55,rewards=new List<WaveReward>{new WaveReward{rewardType="mistik",amount=5}}},
        new WaveRewardGroup{wave=60,rewards=new List<WaveReward>{new WaveReward{rewardType="mistik",amount=5}}},
        new WaveRewardGroup{wave=65,rewards=new List<WaveReward>{new WaveReward{rewardType="talent",amount=50}}},
        new WaveRewardGroup{wave=70,rewards=new List<WaveReward>{new WaveReward{rewardType="zar",amount=2}}},
        new WaveRewardGroup{wave=75,rewards=new List<WaveReward>{new WaveReward{rewardType="coin",amount=5}}},
        new WaveRewardGroup{wave=80,rewards=new List<WaveReward>{new WaveReward{rewardType="crystal",amount=300},new WaveReward{rewardType="weapon",amount=100}}},
        },
        new List<WaveRewardGroup>{
        new WaveRewardGroup{wave=5,rewards=new List<WaveReward>{new WaveReward{rewardType="coin",amount=2}}},
        new WaveRewardGroup{wave=10,rewards=new List<WaveReward>{new WaveReward{rewardType="coin",amount=4}}},
        new WaveRewardGroup{wave=15,rewards=new List<WaveReward>{new WaveReward{rewardType="mistik",amount=5}}},
        new WaveRewardGroup{wave=20,rewards=new List<WaveReward>{new WaveReward{rewardType="mistik",amount=5}}},
        new WaveRewardGroup{wave=25,rewards=new List<WaveReward>{new WaveReward{rewardType="zar",amount=2}}},
        new WaveRewardGroup{wave=30,rewards=new List<WaveReward>{new WaveReward{rewardType="zar",amount=2}}},
        new WaveRewardGroup{wave=35,rewards=new List<WaveReward>{new WaveReward{rewardType="coin",amount=5}}},
        new WaveRewardGroup{wave=40,rewards=new List<WaveReward>{new WaveReward{rewardType="weapon",amount=50}}},
        new WaveRewardGroup{wave=45,rewards=new List<WaveReward>{new WaveReward{rewardType="talent",amount=50}}},
        new WaveRewardGroup{wave=50,rewards=new List<WaveReward>{new WaveReward{rewardType="talent",amount=100}}},
        new WaveRewardGroup{wave=55,rewards=new List<WaveReward>{new WaveReward{rewardType="coin",amount=5}}},
        new WaveRewardGroup{wave=60,rewards=new List<WaveReward>{new WaveReward{rewardType="enerji",amount=30}}},
        new WaveRewardGroup{wave=65,rewards=new List<WaveReward>{new WaveReward{rewardType="zar",amount=2}}},
        new WaveRewardGroup{wave=70,rewards=new List<WaveReward>{new WaveReward{rewardType="zar",amount=2}}},
        new WaveRewardGroup{wave=75,rewards=new List<WaveReward>{new WaveReward{rewardType="coin",amount=5}}},
        new WaveRewardGroup{wave=80,rewards=new List<WaveReward>{new WaveReward{rewardType="crystal",amount=50}}},
        new WaveRewardGroup{wave=85,rewards=new List<WaveReward>{new WaveReward{rewardType="crystal",amount=50}}},
        new WaveRewardGroup{wave=90,rewards=new List<WaveReward>{new WaveReward{rewardType="crystal",amount=500},new WaveReward{rewardType="weapon",amount=100}}},
        },
        new List<WaveRewardGroup>{
        new WaveRewardGroup{wave=5,rewards=new List<WaveReward>{new WaveReward{rewardType="coin",amount=2}}},
        new WaveRewardGroup{wave=10,rewards=new List<WaveReward>{new WaveReward{rewardType="coin",amount=3}}},
        new WaveRewardGroup{wave=15,rewards=new List<WaveReward>{new WaveReward{rewardType="crystal",amount=20}}},
        new WaveRewardGroup{wave=20,rewards=new List<WaveReward>{new WaveReward{rewardType="mistik",amount=5}}},
        new WaveRewardGroup{wave=25,rewards=new List<WaveReward>{new WaveReward{rewardType="weapon",amount=50}}},
        new WaveRewardGroup{wave=30,rewards=new List<WaveReward>{new WaveReward{rewardType="weapon",amount=50}}},
        new WaveRewardGroup{wave=35,rewards=new List<WaveReward>{new WaveReward{rewardType="coin",amount=4}}},
        new WaveRewardGroup{wave=40,rewards=new List<WaveReward>{new WaveReward{rewardType="coin",amount=4}}},
        new WaveRewardGroup{wave=45,rewards=new List<WaveReward>{new WaveReward{rewardType="talent",amount=100}}},
        new WaveRewardGroup{wave=50,rewards=new List<WaveReward>{new WaveReward{rewardType="coin",amount=4}}},
        new WaveRewardGroup{wave=55,rewards=new List<WaveReward>{new WaveReward{rewardType="talent",amount=50}}},
        new WaveRewardGroup{wave=60,rewards=new List<WaveReward>{new WaveReward{rewardType="talent",amount=100}}},
        new WaveRewardGroup{wave=65,rewards=new List<WaveReward>{new WaveReward{rewardType="crystal",amount=20}}},
        new WaveRewardGroup{wave=70,rewards=new List<WaveReward>{new WaveReward{rewardType="crystal",amount=20}}},
        new WaveRewardGroup{wave=75,rewards=new List<WaveReward>{new WaveReward{rewardType="coin",amount=5}}},
        new WaveRewardGroup{wave=80,rewards=new List<WaveReward>{new WaveReward{rewardType="coin",amount=6},new WaveReward{rewardType="crystal",amount=50}}},
        new WaveRewardGroup{wave=85,rewards=new List<WaveReward>{new WaveReward{rewardType="mistik",amount=5}}},
        new WaveRewardGroup{wave=90,rewards=new List<WaveReward>{new WaveReward{rewardType="mistik",amount=5},new WaveReward{rewardType="weapon",amount=100}}},
        },
        new List<WaveRewardGroup>{
        new WaveRewardGroup{wave=5,rewards=new List<WaveReward>{new WaveReward{rewardType="weapon",amount=50}}},
        new WaveRewardGroup{wave=10,rewards=new List<WaveReward>{new WaveReward{rewardType="weapon",amount=50}}},
        new WaveRewardGroup{wave=15,rewards=new List<WaveReward>{new WaveReward{rewardType="mistik",amount=5}}},
        new WaveRewardGroup{wave=20,rewards=new List<WaveReward>{new WaveReward{rewardType="mistik",amount=5}}},
        new WaveRewardGroup{wave=25,rewards=new List<WaveReward>{new WaveReward{rewardType="talent",amount=50}}},
        new WaveRewardGroup{wave=30,rewards=new List<WaveReward>{new WaveReward{rewardType="talent",amount=50}}},
        new WaveRewardGroup{wave=35,rewards=new List<WaveReward>{new WaveReward{rewardType="mistik",amount=5}}},
        new WaveRewardGroup{wave=40,rewards=new List<WaveReward>{new WaveReward{rewardType="crystal",amount=20}}},
        new WaveRewardGroup{wave=45,rewards=new List<WaveReward>{new WaveReward{rewardType="coin",amount=2}}},
        new WaveRewardGroup{wave=50,rewards=new List<WaveReward>{new WaveReward{rewardType="coin",amount=3}}},
        new WaveRewardGroup{wave=55,rewards=new List<WaveReward>{new WaveReward{rewardType="coin",amount=4}}},
        new WaveRewardGroup{wave=60,rewards=new List<WaveReward>{new WaveReward{rewardType="coin",amount=5}}},
        new WaveRewardGroup{wave=65,rewards=new List<WaveReward>{new WaveReward{rewardType="crystal",amount=20}}},
        new WaveRewardGroup{wave=70,rewards=new List<WaveReward>{new WaveReward{rewardType="crystal",amount=30}}},
        new WaveRewardGroup{wave=75,rewards=new List<WaveReward>{new WaveReward{rewardType="coin",amount=5}}},
        new WaveRewardGroup{wave=80,rewards=new List<WaveReward>{new WaveReward{rewardType="coin",amount=5}}},
        new WaveRewardGroup{wave=85,rewards=new List<WaveReward>{new WaveReward{rewardType="weapon",amount=50}}},
        new WaveRewardGroup{wave=90,rewards=new List<WaveReward>{new WaveReward{rewardType="weapon",amount=50},new WaveReward{rewardType="crystal",amount=20}}},
        new WaveRewardGroup{wave=95,rewards=new List<WaveReward>{new WaveReward{rewardType="coin",amount=5}}},
        new WaveRewardGroup{wave=100,rewards=new List<WaveReward>{new WaveReward{rewardType="coin",amount=6},new WaveReward{rewardType="weapon",amount=100}}},
        },
        new List<WaveRewardGroup>{
        new WaveRewardGroup{wave=5,rewards=new List<WaveReward>{new WaveReward{rewardType="coin",amount=2}}},
        new WaveRewardGroup{wave=10,rewards=new List<WaveReward>{new WaveReward{rewardType="coin",amount=3}}},
        new WaveRewardGroup{wave=15,rewards=new List<WaveReward>{new WaveReward{rewardType="zar",amount=2}}},
        new WaveRewardGroup{wave=20,rewards=new List<WaveReward>{new WaveReward{rewardType="zar",amount=2}}},
        new WaveRewardGroup{wave=25,rewards=new List<WaveReward>{new WaveReward{rewardType="enerji",amount=10}}},
        new WaveRewardGroup{wave=30,rewards=new List<WaveReward>{new WaveReward{rewardType="enerji",amount=10}}},
        new WaveRewardGroup{wave=35,rewards=new List<WaveReward>{new WaveReward{rewardType="mistik",amount=5}}},
        new WaveRewardGroup{wave=40,rewards=new List<WaveReward>{new WaveReward{rewardType="crystal",amount=20}}},
        new WaveRewardGroup{wave=45,rewards=new List<WaveReward>{new WaveReward{rewardType="coin",amount=3}}},
        new WaveRewardGroup{wave=50,rewards=new List<WaveReward>{new WaveReward{rewardType="coin",amount=3}}},
        new WaveRewardGroup{wave=55,rewards=new List<WaveReward>{new WaveReward{rewardType="zar",amount=2}}},
        new WaveRewardGroup{wave=60,rewards=new List<WaveReward>{new WaveReward{rewardType="zar",amount=2}}},
        new WaveRewardGroup{wave=65,rewards=new List<WaveReward>{new WaveReward{rewardType="crystal",amount=20}}},
        new WaveRewardGroup{wave=70,rewards=new List<WaveReward>{new WaveReward{rewardType="crystal",amount=20}}},
        new WaveRewardGroup{wave=75,rewards=new List<WaveReward>{new WaveReward{rewardType="coin",amount=3}}},
        new WaveRewardGroup{wave=80,rewards=new List<WaveReward>{new WaveReward{rewardType="coin",amount=3}}},
        new WaveRewardGroup{wave=85,rewards=new List<WaveReward>{new WaveReward{rewardType="weapon",amount=50}}},
        new WaveRewardGroup{wave=90,rewards=new List<WaveReward>{new WaveReward{rewardType="coin",amount=5},new WaveReward{rewardType="crystal",amount=50}}},
        new WaveRewardGroup{wave=95,rewards=new List<WaveReward>{new WaveReward{rewardType="zar",amount=2}}},
        new WaveRewardGroup{wave=100,rewards=new List<WaveReward>{new WaveReward{rewardType="zar",amount=5},new WaveReward{rewardType="mistik",amount=10}}},
        },
        new List<WaveRewardGroup>{
        new WaveRewardGroup{wave=5,rewards=new List<WaveReward>{new WaveReward{rewardType="coin",amount=2}}},
        new WaveRewardGroup{wave=10,rewards=new List<WaveReward>{new WaveReward{rewardType="coin",amount=3}}},
        new WaveRewardGroup{wave=15,rewards=new List<WaveReward>{new WaveReward{rewardType="crystal",amount=20}}},
        new WaveRewardGroup{wave=20,rewards=new List<WaveReward>{new WaveReward{rewardType="mistik",amount=5}}},
        new WaveRewardGroup{wave=25,rewards=new List<WaveReward>{new WaveReward{rewardType="weapon",amount=50}}},
        new WaveRewardGroup{wave=30,rewards=new List<WaveReward>{new WaveReward{rewardType="weapon",amount=50}}},
        new WaveRewardGroup{wave=35,rewards=new List<WaveReward>{new WaveReward{rewardType="coin",amount=4}}},
        new WaveRewardGroup{wave=40,rewards=new List<WaveReward>{new WaveReward{rewardType="coin",amount=4}}},
        new WaveRewardGroup{wave=45,rewards=new List<WaveReward>{new WaveReward{rewardType="talent",amount=50}}},
        new WaveRewardGroup{wave=50,rewards=new List<WaveReward>{new WaveReward{rewardType="coin",amount=4}}},
        new WaveRewardGroup{wave=55,rewards=new List<WaveReward>{new WaveReward{rewardType="talent",amount=50}}},
        new WaveRewardGroup{wave=60,rewards=new List<WaveReward>{new WaveReward{rewardType="talent",amount=100}}},
        new WaveRewardGroup{wave=65,rewards=new List<WaveReward>{new WaveReward{rewardType="crystal",amount=20}}},
        new WaveRewardGroup{wave=70,rewards=new List<WaveReward>{new WaveReward{rewardType="crystal",amount=20}}},
        new WaveRewardGroup{wave=75,rewards=new List<WaveReward>{new WaveReward{rewardType="coin",amount=5}}},
        new WaveRewardGroup{wave=80,rewards=new List<WaveReward>{new WaveReward{rewardType="enerji",amount=20}}},
        new WaveRewardGroup{wave=85,rewards=new List<WaveReward>{new WaveReward{rewardType="coin",amount=5}}},
        new WaveRewardGroup{wave=90,rewards=new List<WaveReward>{new WaveReward{rewardType="coin",amount=6},new WaveReward{rewardType="crystal",amount=50}}},
        new WaveRewardGroup{wave=95,rewards=new List<WaveReward>{new WaveReward{rewardType="mistik",amount=5}}},
        new WaveRewardGroup{wave=100,rewards=new List<WaveReward>{new WaveReward{rewardType="mistik",amount=5},new WaveReward{rewardType="weapon",amount=100}}},
        },
        new List<WaveRewardGroup>{
        new WaveRewardGroup{wave=5,rewards=new List<WaveReward>{new WaveReward{rewardType="coin",amount=2}}},
        new WaveRewardGroup{wave=10,rewards=new List<WaveReward>{new WaveReward{rewardType="coin",amount=3}}},
        new WaveRewardGroup{wave=15,rewards=new List<WaveReward>{new WaveReward{rewardType="mistik",amount=5}}},
        new WaveRewardGroup{wave=20,rewards=new List<WaveReward>{new WaveReward{rewardType="mistik",amount=5}}},
        new WaveRewardGroup{wave=25,rewards=new List<WaveReward>{new WaveReward{rewardType="zar",amount=2}}},
        new WaveRewardGroup{wave=30,rewards=new List<WaveReward>{new WaveReward{rewardType="zar",amount=2}}},
        new WaveRewardGroup{wave=35,rewards=new List<WaveReward>{new WaveReward{rewardType="coin",amount=4}}},
        new WaveRewardGroup{wave=40,rewards=new List<WaveReward>{new WaveReward{rewardType="coin",amount=4}}},
        new WaveRewardGroup{wave=45,rewards=new List<WaveReward>{new WaveReward{rewardType="talent",amount=50}}},
        new WaveRewardGroup{wave=50,rewards=new List<WaveReward>{new WaveReward{rewardType="talent",amount=50}}},
        new WaveRewardGroup{wave=55,rewards=new List<WaveReward>{new WaveReward{rewardType="mistik",amount=5}}},
        new WaveRewardGroup{wave=60,rewards=new List<WaveReward>{new WaveReward{rewardType="mistik",amount=5}}},
        new WaveRewardGroup{wave=65,rewards=new List<WaveReward>{new WaveReward{rewardType="crystal",amount=20}}},
        new WaveRewardGroup{wave=70,rewards=new List<WaveReward>{new WaveReward{rewardType="mistik",amount=5}}},
        new WaveRewardGroup{wave=75,rewards=new List<WaveReward>{new WaveReward{rewardType="coin",amount=4}}},
        new WaveRewardGroup{wave=80,rewards=new List<WaveReward>{new WaveReward{rewardType="mistik",amount=5}}},
        new WaveRewardGroup{wave=85,rewards=new List<WaveReward>{new WaveReward{rewardType="zar",amount=2}}},
        new WaveRewardGroup{wave=90,rewards=new List<WaveReward>{new WaveReward{rewardType="coin",amount=5},new WaveReward{rewardType="zar",amount=5}}},
        new WaveRewardGroup{wave=95,rewards=new List<WaveReward>{new WaveReward{rewardType="talent",amount=100}}},
        new WaveRewardGroup{wave=100,rewards=new List<WaveReward>{new WaveReward{rewardType="weapon",amount=100},new WaveReward{rewardType="crystal",amount=50}}},
        },
        };
	}

	public void OnBolumBitti()
	{
        // Offline recovery from native 0x21ca004. Missing-reference guards are intentional.
        if(GameManager.GuideDone)levelalindi=true;
        else BolumuYerlestir();
	}

	private void EskiBolumOdulleri(int wave)
	{
        // Original ARM64 recovery 0x21b425c.
        int previous=GameManager.Level-1;
        var eligible=new List<WaveRewardGroup>();
        foreach(var group in GetWaveRewardGroupsForCurrentLevel(previous))
         if(group.wave<=wave&&!ES3.KeyExists(es3KeyPrefix+previous+"_"+group.wave))eligible.Add(group);
        if(eligible.Count>0){
         GiveRewards(eligible,true);
         foreach(var group in eligible)ES3.Save<bool>(es3KeyPrefix+previous+"_"+group.wave,true);
         if(SoundManager.instance!=null)SoundManager.instance.AmbienceEffectSfx(SoundManager.levelup);
        }
	}

	private List<WaveRewardGroup> GetWaveRewardGroupsForCurrentLevel(int levelT)
	{
        // Original ARM64 recovery 0x21b4054.
        if(levelT>=14) levelT=(levelT-14)%5+manualLevelRewards.Count-5;
        return manualLevelRewards[levelT];
	}

	public void CheckAndGiveWaveRewards(int wave)
	{
        // Original ARM64 recovery 0x21ca848.
        if(cameraHandler.draggingInfo)return;
        if(bestSurvive<wave){canvasJobs.OpenGoldYok(6);return;}
        var groups=GetWaveRewardGroupsForCurrentLevel(GameManager.Level);
        var eligible=new List<WaveRewardGroup>();
        foreach(var group in groups)
         if(group.wave<=wave&&!ES3.KeyExists(es3KeyPrefix+GameManager.Level+"_"+group.wave))eligible.Add(group);
        if(eligible.Count>0){
         GiveRewards(eligible,false);
         foreach(var group in eligible)ES3.Save<bool>(es3KeyPrefix+GameManager.Level+"_"+group.wave,true);
        }
        bestSurvive=GameManager.BestSurvive;
        UpdateWaveRewardUI();
	}

	private void GiveRewards(List<WaveRewardGroup> groups, bool eskibolumodulleri = false)
	{
        // Original ARM64 recovery 0x21ca07c.
        double coin=0;int weapon=0,mistik=0,crystal=0,energy=0,talent=0,dice=0;
        foreach(var group in groups)foreach(var reward in group.rewards){
         switch(reward.rewardType.ToLower()){
         case "coin":
          // ARM64 madd/mul wrap int32; scvtf/fmul each round to binary32 before widening.
          int raw=unchecked((unchecked(reward.amount*GameManager.Level)+reward.amount)*150);
          coin+=(double)(float)((float)raw*0.6f);
          // Original adds the running total for each coin entry, not only the current entry.
          Currencys.AddCoin(coin,"Meta","WaveRewards");break;
         case "crystal":crystal=unchecked(crystal+reward.amount);Currencys.AddCrystal(reward.amount,"Meta","WaveRewards");break;
         case "mistik":mistik=unchecked(mistik+reward.amount);Currencys.AddMistikToken(reward.amount,"Meta","WaveRewards");break;
         case "talent":talent=unchecked(talent+reward.amount);Currencys.AddTalentScroll(reward.amount,"Meta","WaveRewards");break;
         case "weapon":weapon=unchecked(weapon+reward.amount);Currencys.AddWeaponToken(reward.amount,"Meta","WaveRewards");break;
         case "energy":case "enerji":energy=unchecked(energy+reward.amount);Currencys.AddEnergy(reward.amount,"Meta","WaveRewards");break;
         case "zar":dice=unchecked(dice+reward.amount);Currencys.AddEventDice(reward.amount,"Meta","WaveRewards");break;
         default:UnityEngine.Debug.LogWarning("Bilinmeyen ödül tipi: "+reward.rewardType);break;
         }
        }
        if(collectedUi!=null)collectedUi.GiveRewardUI(coin,weapon,mistik,crystal,energy,talent,0,dice,eskibolumodulleri);
	}

	private void ResetWaveRewards()
	{
        // Original ARM64 recovery 0x21b4728.
        int previous=GameManager.Level-1;if(previous<1)return;
        foreach(var group in GetWaveRewardGroupsForCurrentLevel(previous)){
         string key=es3KeyPrefix+previous+"_"+group.wave;
         if(ES3.KeyExists(key))ES3.DeleteKey(key);
        }
	}

	private void Update()
	{
		// Offline recovery candidate; native RVA 0x21cad10.
		timercamera = (float)(timercamera + Time.deltaTime);
		if (!(timercamera > 0.01f)) return;
		if (cameraHandler.transform.position.z != oldpozcamera)
		{
		 UpdateBolumPositions();
		 oldpozcamera = cameraHandler.transform.position.z;
		}
		timercamera = 0f;
	}

	private void UpdateBolumPositionsOnce()
	{
		// Original single-step recycler; native RVA 0x21b2ce4, unchanged branch semantics.
		float anchor = (float)(cameraTransform.position.z + 250f);
		if ((float)(anchor - activeBolumler[0].transform.position.z) > 102f)
		{
		 Transform moved = activeBolumler[0].transform;
		 Vector3 p = moved.position;
		 moved.position = new Vector3(p.x, p.y, (float)(activeBolumler[2].transform.position.z + 102f));
		 GameObject first = activeBolumler[0];
		 activeBolumler[0] = activeBolumler[1]; activeBolumler[1] = activeBolumler[2]; activeBolumler[2] = first;
		 activeBolumler[0].SetActive(true); activeBolumler[1].SetActive(true); activeBolumler[2].SetActive(true);
		}
		if ((float)(anchor - activeBolumler[2].transform.position.z) < -102f)
		{
		 Transform moved = activeBolumler[2].transform;
		 Vector3 p = moved.position;
		 moved.position = new Vector3(p.x, p.y, (float)(activeBolumler[0].transform.position.z - 102f));
		 GameObject last = activeBolumler[2];
		 activeBolumler[2] = activeBolumler[1]; activeBolumler[1] = activeBolumler[0]; activeBolumler[0] = last;
		 activeBolumler[0].SetActive(!(activeBolumler[0].transform.position.z < -80f));
		}
	}
}
