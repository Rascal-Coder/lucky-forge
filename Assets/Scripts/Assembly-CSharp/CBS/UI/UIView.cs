using System.Collections.Generic;
using UnityEngine;

namespace CBS.UI
{
	public class UIView : MonoBehaviour
	{
		private static readonly string InstanceName;

		private static readonly string CanvasPath;

		private static UIView instance;

		private Dictionary<int, GameObject> WindowsDictionary;

		private Transform rootWindow;

		private static UIView Instance => null;

		public static GameObject RootCanvas => null;

		private Transform RootWindow => null;

		public static GameObject ShowWindow(GameObject uiPrefab)
		{
			return null;
		}

		public static void HideWindow(GameObject uiPrefab)
		{
		}

		public static void HideAll()
		{
		}

		public static GameObject GetInstance(GameObject uiPrefab)
		{
			return null;
		}

		public GameObject GetInstance(int id)
		{
			return null;
		}

		public GameObject ShowOrCreateWindows(int id, GameObject prefab)
		{
			return null;
		}

		public void HideAllWindows()
		{
		}

		public void HideWindow(int id)
		{
		}
	}
}
