using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public class CoinSlotUI
{
	public TextMeshProUGUI title;

	public TextMeshProUGUI priceText;

	public TextMeshProUGUI amountText;

	public TextMeshProUGUI limitText;

	public Button buyButton;

	public GameObject checkIcon;

	public ParticleSystem buyeff;
}
