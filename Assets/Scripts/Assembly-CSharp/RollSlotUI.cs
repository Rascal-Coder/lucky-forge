using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public class RollSlotUI
{
	public Image icon;

	public TextMeshProUGUI nameText;

	public TextMeshProUGUI amountText;

	public TextMeshProUGUI priceText;

	public Button buyButton;

	public GameObject soldOutLabel;

	public TextMeshProUGUI limitText;

	public Image rarityImage;

	public ParticleSystem particlebuy;
}
