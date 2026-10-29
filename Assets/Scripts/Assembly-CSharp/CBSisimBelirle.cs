using CBS;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CBSisimBelirle : MonoBehaviour
{
	public TextMeshProUGUI title;

	public TextMeshProUGUI avatartitle;

	public TMP_InputField isimgir;

	public TextMeshProUGUI logintxt;

	private string namegiris;

	public LeaderBoard _leaders;

	public CanvasJobs canvasJobs;

	public ClanLogin clanLogin;

	public Button createbtn;

	private IProfile ProfileModule { get; set; }

	private void Start()
	{
	}

	public void UpdateNickname()
	{
	}

	private void Update()
	{
	}
}
