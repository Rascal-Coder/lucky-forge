using System.Collections;
using UnityEngine;

namespace CBS.Context
{
	public class CoroutineRunner : MonoBehaviour, ICoroutineRunner
	{
		Coroutine ICoroutineRunner.StartCoroutine(IEnumerator coroutine)
		{
			return null;
		}

		void ICoroutineRunner.StopAllCoroutines()
		{
		}

		void ICoroutineRunner.StopCoroutine(Coroutine coroutine)
		{
		}
	}
}
