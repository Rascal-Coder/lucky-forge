using System;
using System.Collections.Generic;

namespace RSG
{
	public class PromiseTimer : IPromiseTimer
	{
		private float curTime;

		private int curFrame;

		private readonly LinkedList<PredicateWait> waiting;

		public IPromise WaitFor(float seconds)
		{
			return null;
		}

		public IPromise WaitWhile(Func<TimeData, bool> predicate)
		{
			return null;
		}

		public IPromise WaitUntil(Func<TimeData, bool> predicate)
		{
			return null;
		}

		public bool Cancel(IPromise promise)
		{
			return false;
		}

		private LinkedListNode<PredicateWait> FindInWaiting(IPromise promise)
		{
			return null;
		}

		public void Update(float deltaTime)
		{
		}

		private LinkedListNode<PredicateWait> RemoveNode(LinkedListNode<PredicateWait> node)
		{
			return null;
		}
	}
}
