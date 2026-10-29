using UnityEngine;

public class ClanTaskLocal : MonoBehaviour
{
	public class GorevlerClan
	{
		public int Login;

		public int EnemyKill;

		public int DungeonClear;

		public int BossKill;

		public int FindTalent;

		public int NewSiege;

		public int MergeEquipment;

		public int UpgradeWeapon;

		public int ReklamOduluAl;

		public int SatinAlim;

		public int SpawnMistik;

		public int GuildBoss1;

		public int GuildBoss2;

		public int GuildBoss3;

		public int GuildBoss4;
	}

	public static GorevlerClan gorevlerClan;

	private const string saveKey = "lastClanUTCResetDate";

	private void Start()
	{
	}

	private void LoadData()
	{
	}

	public bool CheckForUTCReset()
	{
		return false;
	}

	public void ResetData()
	{
	}

	public void Saveit()
	{
	}

	public static void ClanTaskPointEkle(int num, int adet)
	{
	}

	private void Update()
	{
	}
}
