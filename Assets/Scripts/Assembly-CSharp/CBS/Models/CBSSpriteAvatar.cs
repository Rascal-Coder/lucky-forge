namespace CBS.Models
{
	public class CBSSpriteAvatar
	{
		public string ID;

		public bool HasLevelLimit;

		public bool Purchasable;

		public int LevelLimit;

		public CBSPrice Price;

		public CBSAvatarState ToState()
		{
			return null;
		}
	}
}
