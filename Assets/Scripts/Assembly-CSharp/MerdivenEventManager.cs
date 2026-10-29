using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MerdivenEventManager : MonoBehaviour
{
	public Sprite[] Odulicons;

	public static int MerdivenMateryali;

	public static int MerdivenSeviyesi;

	public static int upgsayisi;

	public static int OdulKacaKadarToplandi;

	public static int MerdivenEventTamamlandi;

	public TextMeshProUGUI _kalanzaman;

	public RectTransform _odullercontent;

	public TextMeshProUGUI _headtitle;

	public TextMeshProUGUI _subtitle;

	public Slider _lvlslider;

	public TextMeshProUGUI _kacakac;

	public TextMeshProUGUI _level;

	public TextMeshProUGUI _materyal;

	public TextMeshProUGUI _kaynakyok;

	public ParticleSystem _upgeff;

	public ParticleSystem _milestoneeff;

	public kart hediye_1_EventKart;

	public kart hediye_2_EventKart;

	public GameObject _infoicon;

	public ParticleSystem _btnupgeff;

	public Button _closebtn;

	public GameManager gameManager;

	private float timersavees3;

	private bool saved;

	private float movetimer;

	public float heighthesap;

	public bool readyforcollect;

	public PageReferences _pageRef;

	public static bool PaidRewardsFree => false;

	public int GuncelMilestone()
	{
		return 0;
	}

	private void OnEnable()
	{
	}

	private void Start()
	{
	}

	private void Update()
	{
	}

	public void gotoList(bool lightup)
	{
	}

	private void DataUpdate()
	{
	}

	public void UpgradeMe()
	{
	}

	private void LevelUp()
	{
	}

	public void Closeit()
	{
	}

	public void Openit()
	{
	}

	public void OpenitEventten(GameObject gameobj)
	{
	}

	public void RebuildSizeContent()
	{
	}

	public void ApplyGppFreeRewards()
	{
	}
}
