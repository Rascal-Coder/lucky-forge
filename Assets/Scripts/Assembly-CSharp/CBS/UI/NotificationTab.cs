using UnityEngine;
using UnityEngine.UI;

namespace CBS.UI
{
	[RequireComponent(typeof(Toggle))]
	public class NotificationTab : MonoBehaviour
	{
		[SerializeField]
		private NotificationMenu TabType;

		[SerializeField]
		private Text Title;

		[SerializeField]
		private Color ActiveColor;

		[SerializeField]
		private Color DisableColor;

		private Toggle Toggle { get; set; }

		private void Awake()
		{
		}

		private void OnDestroy()
		{
		}

		private void OnEnable()
		{
		}

		private void DrawState(bool state)
		{
		}

		public NotificationMenu GetTabType()
		{
			return NotificationMenu.MESSAGES;
		}

		private void OnStateChange(bool state)
		{
		}
	}
}
