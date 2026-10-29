using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace NotificationSamples.Demo
{
	public class GameController : MonoBehaviour
	{
		private class PendingInventoryItem
		{
			public DateTime DeliveryTime;

			public InventoryItemData ItemData;

			public float TimeRemaining => 0f;
		}

		private const float DefaultInspectorSpace = 10f;

		private const int MaxNewsFeedTitleLength = 50;

		private const int MaxNewsFeedSummaryLength = 150;

		[SerializeField]
		[Tooltip("Reference to the notification console.")]
		protected NotificationConsole console;

		[SerializeField]
		[Tooltip("Reference to the notification manager.")]
		protected GameNotificationsManager notificationsManager;

		[SerializeField]
		[Tooltip("For reading the news feed items.")]
		protected NewsFeedReader newsFeedReader;

		[SerializeField]
		[Tooltip("Buy item prefab to clone.")]
		protected BuyInventoryItem buyItemPrefab;

		[SerializeField]
		[Tooltip("Parent to hold the items to buy.")]
		protected Transform buyContentHolder;

		[SerializeField]
		[Tooltip("Prefab of bought items.")]
		protected InventoryItem itemPrefab;

		[SerializeField]
		[Tooltip("Parent to hold the bought items.")]
		protected Transform contentHolder;

		[SerializeField]
		[Tooltip("Label to display the currency.")]
		protected TextMeshProUGUI currencyLabel;

		[SerializeField]
		[Tooltip("Label to display the currency bonus.")]
		protected TextMeshProUGUI bonusLabel;

		[SerializeField]
		[Tooltip("Label to display the current time.")]
		protected TextMeshProUGUI timeLabel;

		[SerializeField]
		[Tooltip("Label to display log messages.")]
		protected TextMeshProUGUI logLabel;

		[SerializeField]
		[Tooltip("Loading icon to show the news feed is being loaded.")]
		protected GameObject newsFeedLoadingIcon;

		[SerializeField]
		[Tooltip("Turn speed of the news feed loading icon.")]
		protected float newsFeedLoadingIconTurnSpeed;

		[SerializeField]
		[Tooltip("News feed button.")]
		protected Button newsFeedButton;

		[Space(10f)]
		[SerializeField]
		[Tooltip("Start the game with this currency.")]
		protected float initialCurrency;

		[SerializeField]
		[Tooltip("Get the news feed (RSS) from this url.")]
		protected string newsFeedUrl;

		[SerializeField]
		[Tooltip("Schedule news feed notifications this time in the future (minutes).")]
		protected float newsNotificationTime;

		[SerializeField]
		[Tooltip("Schedule a reminder to play the game at this hour (e.g. 6:00, 13:00, etc.).")]
		protected int playReminderHour;

		[Space(10f)]
		[SerializeField]
		[Tooltip("Inventory items data to use in the game.")]
		protected InventoryItemData[] itemsData;

		private float currency;

		private float currencyBonus;

		private DateTime? applicationPausedTime;

		private readonly List<PendingInventoryItem> pendingItems;

		private readonly Dictionary<InventoryItemData, InventoryItem> items;

		private readonly List<BuyInventoryItem> buyItems;

		private void Awake()
		{
		}

		private void OnApplicationPause(bool pauseStatus)
		{
		}

		private void Update()
		{
		}

		public void OnNewsFeed()
		{
		}

		public void OnPlayReminder()
		{
		}

		public void DisplayLastNotification()
		{
		}

		private void AwardCurrencyBonus(float elapsedTime)
		{
		}

		private void OnBuy(BuyInventoryItem item)
		{
		}

		private void UpdateControls()
		{
		}

		private void UpdatePendingItems()
		{
		}

		private void UpdateNewsFeedLoadingIcon(float dt)
		{
		}

		private void OnDeliveredItem(InventoryItemData itemData)
		{
		}

		private void SetCurrency(float newCurrency)
		{
		}

		private void ShowNewsFeedLoadingIcon(bool visible)
		{
		}

		private void OnGetFirstItem(NewsFeedReader.NewsItem newsItem)
		{
		}
	}
}
