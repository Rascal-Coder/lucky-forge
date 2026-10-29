using CBS;
using CBS.Core;
using CBS.Models;
using CBS.UI;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ClanTekli : MonoBehaviour, IScrollableItem<ClanLeaderboardEntry>
{
	public TextMeshProUGUI DisplayName;

	public TextMeshProUGUI subtitle;

	public TextMeshProUGUI clanlvl;

	public TextMeshProUGUI memberstext;

	public TextMeshProUGUI memberscount;

	public TextMeshProUGUI applyorjointxt;

	public Button applybtn;

	public PlaceDrawer Place;

	public ClanAvatarDrawer Avatar;

	private ClanEntity clan;

	private IProfile ProfileModule;

	public TextMeshProUGUI Value;

	private ClanLogin clanLogin;

	private IClan Clan { get; set; }

	public void Display(ClanLeaderboardEntry data)
	{
	}

	private void OnGet(CBSGetClanFullInfoResult result)
	{
	}

	public void JoinOrRequest()
	{
	}

	public void SendJoinRequest()
	{
	}

	public void JoinHandler()
	{
	}

	private void Start()
	{
	}

	private void Update()
	{
	}
}
