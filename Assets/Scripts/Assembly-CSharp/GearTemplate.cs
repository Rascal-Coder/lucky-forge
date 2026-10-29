using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Gear/GearTemplate")]
public class GearTemplate : ScriptableObject
{
	[Serializable]
	public class Perk
	{
		public string stat;

		public float value;
	}

	public int gearName;

	public GearSlot slot;

	public GearType type;

	public Sprite icon;

	public Sprite sloticon;

	[SerializeField]
	public long[] baseAttackRaritys;

	public List<Perk> perks;
}
