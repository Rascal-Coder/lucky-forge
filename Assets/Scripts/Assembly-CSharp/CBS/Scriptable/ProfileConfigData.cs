using System.Collections.Generic;
using CBS.Models;
using CBS.Utils;
using UnityEngine;

namespace CBS.Scriptable
{
	[CreateAssetMenu(fileName = "ProfileConfigData", menuName = "CBS/Add new Profile Config Data")]
	public class ProfileConfigData : CBSScriptable
	{
		[Header("Online Status")]
		public bool EnableOnlineStatus;

		public OnlineStatusBehavior OnlineUpdateBehavior;

		public int ConsiderInactiveAfter;

		public int UpdateInterval;

		public List<string> TriggerMethods;

		[Header("Avatars")]
		public AvatarDisplayOptions AvatarDisplay;

		public bool UseCacheForAvatars;

		public Sprite DefaultAvatar;

		public override string ResourcePath => null;

		public bool UseImageCache => false;
	}
}
