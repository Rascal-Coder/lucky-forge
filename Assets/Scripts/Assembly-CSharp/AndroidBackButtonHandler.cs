using System;
using System.Collections.Generic;
using System.Reflection;
using Unity.Profiling;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AndroidBackButtonHandler : MonoBehaviour
{
	[Serializable]
	public class BackPanelEntry
	{
		public GameObject panel;

		public MonoBehaviour handler;

		public string closeMethodName;
	}

	private const string LogTag = "[Back_BTN]";

	private const string BackHandlerVersion = "fix-cache-include-v1";

	[Header("Highest priority first (optional)")]
	public BackPanelEntry[] panels;

	public WarController warController;

	public PageReferences pageReferences;

	public Reklamlar reklamlar;

	public NewOfflineRewards offlineRewards;

	public MergeUIManager mergeUiManager;

	public BottomPages bottomPages;

	private const FindObjectsInactive CacheScanMode = FindObjectsInactive.Include;

	private static readonly bool EnableVerboseBackLogs;

	private GuideJustGear[] _cacheGuideJustGear;

	private GuideManagerRPG[] _cacheGuideManagerRpg;

	private ClanLogin[] _cacheClanLogin;

	private MenuGeneralSettings[] _cacheMenuSettings;

	private DropChanceTalentShow[] _cacheDropChance;

	private TalentFinder[] _cacheTalentFinder;

	private TalentsUiManager[] _cacheTalentsUiManager;

	private FindNewWeapons[] _cacheFindNewWeapons;

	private FortuneTellerUi[] _cacheFortuneTellerUi;

	private DailySpin[] _cacheDailySpin;

	private ForgeSpinner[] _cacheForgeSpinner;

	private MistikInGameUI[] _cacheMistikInGameUi;

	private CommanderMissionUI[] _cacheCommanderMissionUi;

	private DailyLoginEvent[] _cacheDailyLoginEvent;

	private GunlukGorevler[] _cacheGunlukGorevler;

	private EnergyRightsCanvas[] _cacheEnergyRightsCanvas;

	private PassGame[] _cachePassGame;

	private GunlukHediye[] _cacheGunlukHediye;

	private ChallangeEventManager[] _cacheChallangeEventManager;

	private X2Kazanc[] _cacheX2Kazanc;

	private MerdivenEventManager[] _cacheMerdivenEventManager;

	private PromosyonUi[] _cachePromosyonUi;

	private OneTimeOffer[] _cacheOneTimeOffer;

	private VipPackOffer[] _cacheVipPackOffer;

	private PiggyBank[] _cachePiggyBank;

	private ShopUi[] _cacheShopUi;

	private WarSpeedUi[] _cacheWarSpeedUi;

	private EventsPage[] _cacheEventsPage;

	private RateUsPage[] _cacheRateUsPage;

	private BonusesExtraPage[] _cacheBonusesExtraPage;

	private MistikResetUi[] _cacheMistikResetUi;

	private EquipmentPageParent[] _cacheEquipmentPageParent;

	private SkillTreeGenelUi[] _cacheSkillTreeGenelUi;

	private UpgradeAllParent[] _cacheUpgradeAllParent;

	private HeroUpgradeUI[] _cacheHeroUpgradeUi;

	private LeaderBoardUi[] _cacheLeaderBoardUi;

	private DungeonUi[] _cacheDungeonUi;

	private SquareGachaSystem[] _cacheSquareGachaSystem;

	private InventoryGearUI[] _cacheInventoryGearUi;

	private CollectedUnitsSpin[] _cacheCollectedUnitsSpin;

	private GuideinsideWar[] _cacheGuideInsideWar;

	private RogueLikeSkillSec[] _cacheRogueLikeSkillSec;

	private static readonly Dictionary<string, MethodInfo> CachedMethods;

	private static readonly HashSet<string> MissingMethods;

	private static readonly Dictionary<Type, FieldInfo[]> CachedTutorialHandFields;

	private static readonly ProfilerMarker BackPressMarker;

	private static readonly ProfilerMarker OverlayMarker;

	private static readonly ProfilerMarker ReflectionFallbackMarker;

	private static readonly ProfilerMarker BlockerScanMarker;

	private static readonly string[] CloseMethodPriority;

	public static AndroidBackButtonHandler Instance { get; private set; }

	private void Awake()
	{
	}

	private void OnEnable()
	{
	}

	private void OnDestroy()
	{
	}

	private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
	{
	}

	private void Start()
	{
	}

	private void Update()
	{
	}

	private bool IsTutorialOrHandGestureActive(out string reason)
	{
		reason = null;
		return false;
	}

	private void LogTutorialBlockDetails()
	{
	}

	private static bool IsTutorialHandFieldName(string fieldName)
	{
		return false;
	}

	private static bool TryGetActiveTutorialHandPointer(Component guide, out string activeFieldName)
	{
		activeFieldName = null;
		return false;
	}

	private static bool TryGetActiveTutorialHandFromField(Component guide, FieldInfo field, out string label)
	{
		label = null;
		return false;
	}

	private static string DescribeActiveTutorialHandFields(Component guide)
	{
		return null;
	}

	private static FieldInfo[] GetCachedTutorialHandFields(Type type)
	{
		return null;
	}

	private static bool IsActive(GameObject go)
	{
		return false;
	}

	private void RefreshCoreCaches(bool force)
	{
	}

	private void RefreshOverlayCaches(bool force)
	{
	}

	private static void BackLog(string message)
	{
	}

	private string BuildStateSnapshot()
	{
		return null;
	}

	private void LogQuitEligibility(string knownUiBlocker = null)
	{
	}

	private string BuildDetailedQuitBlockReason(string knownUiBlocker = null)
	{
		return null;
	}

	private string GetKnownUiOpenBlocker()
	{
		return null;
	}

	private void ResolveReferences()
	{
	}

	private static bool WasBackPressed()
	{
		return false;
	}

	private bool IsWarEndBlocked()
	{
		return false;
	}

	private bool TryCloseRegisteredPanel()
	{
		return false;
	}

	private bool TryCloseWarUi()
	{
		return false;
	}

	private bool TryCloseCollectedUnitsSpin()
	{
		return false;
	}

	private bool TryBlockBackDuringActiveSpin(out string reason)
	{
		reason = null;
		return false;
	}

	private bool TryToggleBattlePause()
	{
		return false;
	}

	private bool IsRogueLikeSkillSecActive()
	{
		return false;
	}

	private void OnApplicationPause(bool pauseStatus)
	{
	}

	private bool IsAnyGuideInsideWarGestureVisible()
	{
		return false;
	}

	private bool TryHandleGuideInsideWarBack()
	{
		return false;
	}

	private bool TryCloseOverlayPopups()
	{
		return false;
	}

	private bool TryCloseClanLogin()
	{
		return false;
	}

	private static bool TryCloseClanGenelUiOverlays(ClanGenelUi ui)
	{
		return false;
	}

	private bool TryCloseMenuSettings()
	{
		return false;
	}

	private bool TryCloseBlockingPopups()
	{
		return false;
	}

	private bool TryCloseOfflineRewards()
	{
		return false;
	}

	private bool TryCloseTalentChestUi()
	{
		return false;
	}

	private bool IsTalentsUiShowVisible()
	{
		return false;
	}

	private bool TryCloseFortuneTellerUi()
	{
		return false;
	}

	private bool TryCloseDailySpin()
	{
		return false;
	}

	private bool TryCloseFindNewWeapons()
	{
		return false;
	}

	private bool TryCloseGearAndMergeUi()
	{
		return false;
	}

	private bool TryCloseBuiltInPanels()
	{
		return false;
	}

	private bool TryCloseHandleBackButtonPopups()
	{
		return false;
	}

	private bool TryInvokeHandleBackButton<T>() where T : MonoBehaviour
	{
		return false;
	}

	private static bool InvokeHandleBackButton(MonoBehaviour target)
	{
		return false;
	}

	private bool TryCloseShopUi()
	{
		return false;
	}

	private void ReturnToBattleTabIfNeeded()
	{
	}

	private bool TryCloseBottomNavigation()
	{
		return false;
	}

	private bool IsBattlePageOnlyVisible()
	{
		return false;
	}

	private bool IsOnBattleHomeTab(string knownUiBlocker = null)
	{
		return false;
	}

	private bool TryCloseByReflection()
	{
		return false;
	}

	private bool TryCloseComponent<T>(string methodName) where T : MonoBehaviour
	{
		return false;
	}

	private static bool InvokeClose(MonoBehaviour target, string methodName)
	{
		return false;
	}

	private bool ShouldQuitFromMainMenu(string knownUiBlocker = null)
	{
		return false;
	}

	private bool IsComponentVisibleInHierarchy<T>() where T : MonoBehaviour
	{
		return false;
	}

	private T[] GetComponentsForType<T>() where T : MonoBehaviour
	{
		return null;
	}

	private bool TryGetCachedComponents<T>(out T[] components) where T : MonoBehaviour
	{
		components = null;
		return false;
	}

	private static MethodInfo GetCachedMethod(Type type, string methodName, BindingFlags flags, bool requireBoolReturn)
	{
		return null;
	}

	private bool AnyRegisteredPanelOpen()
	{
		return false;
	}

	private static void ClearPageFlags()
	{
	}

	private static void QuitApp()
	{
	}
}
