using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LeaderBoardUi : MonoBehaviour
{
	public Transform _leaderboardarea;

	public GameObject _oduller;

	public LeaderBoard _leaders;

	public Slider _sliderleader;

	public TextMeshProUGUI _titlehead;

	public TextMeshProUGUI _name;

	public TextMeshProUGUI _diggedfloor;

	public TextMeshProUGUI _rewards;

	public TextMeshProUGUI _weeklyrewards;

	public TextMeshProUGUI _resetin;

	[Header("RANK1-2-3")]
	public TextMeshProUGUI _rank1name;

	[Header("RANK1-2-3")]
	public TextMeshProUGUI _rank2name;

	[Header("RANK1-2-3")]
	public TextMeshProUGUI _rank3name;

	public TextMeshProUGUI _rank1puan;

	public TextMeshProUGUI _rank2puan;

	public TextMeshProUGUI _rank3puan;

	public Image _rank1icon;

	public Image _rank2icon;

	public Image _rank3icon;

	public TextMeshProUGUI _benname;

	public TextMeshProUGUI _benrankpuan;

	public TextMeshProUGUI _benkacinci;

	private void Start()
	{
	}

	private void Update()
	{
	}

	public void OdullerGoster(bool nedir)
	{
	}

	public bool HandleBackButton()
	{
		return false;
	}

	public void CloseLeaders()
	{
	}

	public void OpenLeaders()
	{
	}

	private void ResetTimeNeZaman()
	{
	}
}
