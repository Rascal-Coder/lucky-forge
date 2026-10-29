using System.Collections.Generic;
using UnityEngine;

public class CollectiblesManager : MonoBehaviour
{
	public List<CollectibleItem> allCollectibles;

	public Sprite[] collectiblesicons;

	private const string saveKey = "CollectiblesSave";

	public string Names(int key)
	{
		// Native RVA0x1f55484, original 51-entry pointer table at0x440c738.
		switch(key){
		case 0:return "Vortexa";
		case 1:return "Solara";
		case 2:return "Prismata";
		case 3:return "Chaos";
		case 4:return "Seraph";
		case 5:return "Aurora";
		case 6:return "Mirage";
		case 7:return "Pulse";
		case 8:return "Arcadia";
		case 9:return "Harmonia";
		case 10:return "Euphoria";
		case 11:return "Lyric";
		case 12:return "Zephyr";
		case 13:return "Obsidian";
		case 14:return "Celestia";
		case 15:return "Kaleido";
		case 16:return "Phaedra";
		case 17:return "Quanta";
		case 18:return "Rhapsody";
		case 19:return "Silhouette";
		case 20:return "Symphony";
		case 21:return "Transcend";
		case 22:return "Utopia";
		case 23:return "Verve";
		case 24:return "Xenon";
		case 25:return "Yugen";
		case 26:return "Zenobia";
		case 27:return "Amethyst";
		case 28:return "Bloom";
		case 29:return "Cascade";
		case 30:return "Dreamscape";
		case 31:return "Equinox";
		case 32:return "Fathom";
		case 33:return "Glyphic";
		case 34:return "Horizon";
		case 35:return "Illusion";
		case 36:return "Jubilee";
		case 37:return "Labyrinth";
		case 38:return "Monochrome";
		case 39:return "Novae";
		case 40:return "Opus";
		case 41:return "Polyphony";
		case 42:return "Requiem";
		case 43:return "Silence";
		case 44:return "Tempest";
		case 45:return "Umbra";
		case 46:return "Vestige";
		case 47:return "Whisper";
		case 48:return "Xylograph";
		case 49:return "Zodiac";
		case 50:return "Owa";
		default:return "Collectible";
		}
	}

	public string Ozellik(string key)
	{
		// Native RVA0x1f55744, UI label forwarding only.
		return Lang.CollectionsTitles(key);
	}

	private void Start()
	{
	}

	public void Initialize()
	{
	}

	public void Collect(int id)
	{
	}

	public bool IsCollected(int id)
	{
		return false;
	}

	public void Save()
	{
	}

	public void UpdateTotalBonuses()
	{
	}
}
