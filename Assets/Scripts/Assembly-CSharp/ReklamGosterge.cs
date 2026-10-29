using System;
using TMPro;
using UnityEngine;

public class ReklamGosterge : MonoBehaviour
{
	public GameObject[] _objectssirayla;

	public TextMeshProUGUI _text_toplupara;

	public TextMeshProUGUI _text_crystal;

	public GameManager _gm;

	public float[] _timer;

	private float geneltimer;

	public double parasi;

	public int topluparareklamilimit;

	private DateTime lastResetTime;

	private const string LastResetTimeKey = "TopluCoinResetTime";

	private const string RemainingTriesKey = "TopluParaRemainingTries";

	private void Start()
	{
	}

	public void getdata()
	{
	}

	private void Update()
	{
	}

	private void LoadData()
	{
	}

	private void SaveData()
	{
	}

	private void ResetTriesIfNeeded()
	{
	}

	public void CoinReklamIzlendi()
	{
	}
}
