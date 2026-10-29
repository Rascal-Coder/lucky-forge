using System.Collections.Generic;
using FunGames.Tools.Debugging;
using IngameDebugConsole;
using UnityEngine;
using UnityEngine.UI;

[DefaultExecutionOrder(-39)]
public class FGDebugConsoleBuilder : MonoBehaviour
{
	public GameObject container;

	public RectTransform menuButtons;

	public Text moduleNameText;

	public Button previousButton;

	public Button nextButton;

	public List<DebugElement> menus;

	private List<DebugElement> pool;

	[SerializeField]
	private Sprite spriteOpenIcon;

	[SerializeField]
	private Sprite spriteCloseIcon;

	[SerializeField]
	private Button uiToggleButton;

	[SerializeField]
	private Button hideDebugMenu;

	[SerializeField]
	private FGDebugConsole console;

	[SerializeField]
	private GameObject debugMenuLayout;

	private Image uiToggleButtonImage;

	private int _currentIndex;

	public bool IsOpen { get; private set; }

	private DebugLogManager DebugLogManager => null;

	private void Awake()
	{
	}

	private void Start()
	{
	}

	public void ToggleDebugMenu()
	{
	}

	public void ToggleLogsUI()
	{
	}

	private void ShowPrevious()
	{
	}

	private void ShowNext()
	{
	}
}
