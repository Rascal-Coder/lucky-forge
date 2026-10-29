using UnityEngine;

namespace CBS.Scriptable
{
	[CreateAssetMenu(fileName = "EditorData", menuName = "CBS/Add new Editor Data")]
	public class EditorData : CBSScriptable
	{
		public Color AddColor;

		public Color AddPrizeColor;

		public Color RemoveColor;

		public Color SaveColor;

		public Color EditColor;

		public Color DuplicateColor;

		public Color EventColor;

		public Color StartColor;

		public Color StopColor;

		public Color ExecuteColor;

		public Color ConfigureColor;

		public Color RecipeTarget;

		public Color RecipeContent;

		public Color RecipePrice;

		public Color RecipeCustomData;

		public Color UpgradeTitle;

		public Color StoreEnabledTitle;

		public Color StoreDisabledTitle;

		public Color StoreContent;

		public Color BattlePassInfoTitle;

		public Color BattlePassConfigTitle;

		public Color BattlePassLevelTitle;

		public Color BattlePassExtraLevelTitle;

		public Color TicketTitle;

		public Color TicketContent;

		public Color NotificationTitle;

		public Color NotificationExtend;

		public Color ProfileEventBackground;

		public Color LootboxCurrencySlot;

		public Color LootboxItemSlot;

		public override string ResourcePath => null;
	}
}
