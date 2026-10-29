using System.Collections;
using UnityEngine;

namespace Proyecto26
{
	public static class StaticCoroutine
	{
		private class CoroutineHolder : MonoBehaviour
		{
		}

		private static CoroutineHolder _runner;

		private static CoroutineHolder Runner => null;

		public static Coroutine StartCoroutine(IEnumerator coroutine)
		{
			return null;
		}
	}
}
