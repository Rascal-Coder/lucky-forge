using System;
using System.Collections.Generic;

namespace RSG
{
	public class Promise<PromisedT> : IPromise<PromisedT>, IPendingPromise<PromisedT>, IRejectable, IPromiseInfo
	{
		private Exception rejectionException;

		private PromisedT resolveValue;

		private List<RejectHandler> rejectHandlers;

		private List<ProgressHandler> progressHandlers;

		private List<Action<PromisedT>> resolveCallbacks;

		private List<IRejectable> resolveRejectables;

		private readonly int id;

		public int Id => 0;

		public string Name { get; private set; }

		public PromiseState CurState { get; private set; }

		public Promise()
		{
		}

		public Promise(Action<Action<PromisedT>, Action<Exception>> resolver)
		{
		}

		private void AddRejectHandler(Action<Exception> onRejected, IRejectable rejectable)
		{
		}

		private void AddResolveHandler(Action<PromisedT> onResolved, IRejectable rejectable)
		{
		}

		private void AddProgressHandler(Action<float> onProgress, IRejectable rejectable)
		{
		}

		private void InvokeHandler<T>(Action<T> callback, IRejectable rejectable, T value)
		{
		}

		private void ClearHandlers()
		{
		}

		private void InvokeRejectHandlers(Exception ex)
		{
		}

		private void InvokeResolveHandlers(PromisedT value)
		{
		}

		private void InvokeProgressHandlers(float progress)
		{
		}

		public void Reject(Exception ex)
		{
		}

		public void Resolve(PromisedT value)
		{
		}

		public void ReportProgress(float progress)
		{
		}

		public void Done(Action<PromisedT> onResolved, Action<Exception> onRejected)
		{
		}

		public void Done(Action<PromisedT> onResolved)
		{
		}

		public void Done()
		{
		}

		public IPromise<PromisedT> WithName(string name)
		{
			return null;
		}

		public IPromise Catch(Action<Exception> onRejected)
		{
			return null;
		}

		public IPromise<PromisedT> Catch(Func<Exception, PromisedT> onRejected)
		{
			return null;
		}

		public IPromise<ConvertedT> Then<ConvertedT>(Func<PromisedT, IPromise<ConvertedT>> onResolved)
		{
			return null;
		}

		public IPromise Then(Func<PromisedT, IPromise> onResolved)
		{
			return null;
		}

		public IPromise Then(Action<PromisedT> onResolved)
		{
			return null;
		}

		public IPromise<ConvertedT> Then<ConvertedT>(Func<PromisedT, IPromise<ConvertedT>> onResolved, Func<Exception, IPromise<ConvertedT>> onRejected)
		{
			return null;
		}

		public IPromise Then(Func<PromisedT, IPromise> onResolved, Action<Exception> onRejected)
		{
			return null;
		}

		public IPromise Then(Action<PromisedT> onResolved, Action<Exception> onRejected)
		{
			return null;
		}

		public IPromise<ConvertedT> Then<ConvertedT>(Func<PromisedT, IPromise<ConvertedT>> onResolved, Func<Exception, IPromise<ConvertedT>> onRejected, Action<float> onProgress)
		{
			return null;
		}

		public IPromise Then(Func<PromisedT, IPromise> onResolved, Action<Exception> onRejected, Action<float> onProgress)
		{
			return null;
		}

		public IPromise Then(Action<PromisedT> onResolved, Action<Exception> onRejected, Action<float> onProgress)
		{
			return null;
		}

		public IPromise<ConvertedT> Then<ConvertedT>(Func<PromisedT, ConvertedT> transform)
		{
			return null;
		}

		private void ActionHandlers(IRejectable resultPromise, Action<PromisedT> resolveHandler, Action<Exception> rejectHandler)
		{
		}

		private void ProgressHandlers(IRejectable resultPromise, Action<float> progressHandler)
		{
		}

		public IPromise<IEnumerable<ConvertedT>> ThenAll<ConvertedT>(Func<PromisedT, IEnumerable<IPromise<ConvertedT>>> chain)
		{
			return null;
		}

		public IPromise ThenAll(Func<PromisedT, IEnumerable<IPromise>> chain)
		{
			return null;
		}

		public static IPromise<IEnumerable<PromisedT>> All(params IPromise<PromisedT>[] promises)
		{
			return null;
		}

		public static IPromise<IEnumerable<PromisedT>> All(IEnumerable<IPromise<PromisedT>> promises)
		{
			return null;
		}

		public IPromise<ConvertedT> ThenRace<ConvertedT>(Func<PromisedT, IEnumerable<IPromise<ConvertedT>>> chain)
		{
			return null;
		}

		public IPromise ThenRace(Func<PromisedT, IEnumerable<IPromise>> chain)
		{
			return null;
		}

		public static IPromise<PromisedT> Race(params IPromise<PromisedT>[] promises)
		{
			return null;
		}

		public static IPromise<PromisedT> Race(IEnumerable<IPromise<PromisedT>> promises)
		{
			return null;
		}

		public static IPromise<PromisedT> Resolved(PromisedT promisedValue)
		{
			return null;
		}

		public static IPromise<PromisedT> Rejected(Exception ex)
		{
			return null;
		}

		public IPromise<PromisedT> Finally(Action onComplete)
		{
			return null;
		}

		public IPromise ContinueWith(Func<IPromise> onComplete)
		{
			return null;
		}

		public IPromise<ConvertedT> ContinueWith<ConvertedT>(Func<IPromise<ConvertedT>> onComplete)
		{
			return null;
		}

		public IPromise<PromisedT> Progress(Action<float> onProgress)
		{
			return null;
		}
	}
	public class Promise : IPromise, IPendingPromise, IRejectable, IPromiseInfo
	{
		public struct ResolveHandler
		{
			public Action callback;

			public IRejectable rejectable;
		}

		public static bool EnablePromiseTracking;

		private static EventHandler<ExceptionEventArgs> unhandlerException;

		private static int nextPromiseId;

		internal static readonly HashSet<IPromiseInfo> PendingPromises;

		private Exception rejectionException;

		private List<RejectHandler> rejectHandlers;

		private List<ResolveHandler> resolveHandlers;

		private List<ProgressHandler> progressHandlers;

		private readonly int id;

		public int Id => 0;

		public string Name { get; private set; }

		public PromiseState CurState { get; private set; }

		public static event EventHandler<ExceptionEventArgs> UnhandledException
		{
			add
			{
			}
			remove
			{
			}
		}

		public static IEnumerable<IPromiseInfo> GetPendingPromises()
		{
			return null;
		}

		public Promise()
		{
		}

		public Promise(Action<Action, Action<Exception>> resolver)
		{
		}

		internal static int NextId()
		{
			return 0;
		}

		private void AddRejectHandler(Action<Exception> onRejected, IRejectable rejectable)
		{
		}

		private void AddResolveHandler(Action onResolved, IRejectable rejectable)
		{
		}

		private void AddProgressHandler(Action<float> onProgress, IRejectable rejectable)
		{
		}

		private void InvokeRejectHandler(Action<Exception> callback, IRejectable rejectable, Exception value)
		{
		}

		private void InvokeResolveHandler(Action callback, IRejectable rejectable)
		{
		}

		private void InvokeProgressHandler(Action<float> callback, IRejectable rejectable, float progress)
		{
		}

		private void ClearHandlers()
		{
		}

		private void InvokeRejectHandlers(Exception ex)
		{
		}

		private void InvokeResolveHandlers()
		{
		}

		private void InvokeProgressHandlers(float progress)
		{
		}

		public void Reject(Exception ex)
		{
		}

		public void Resolve()
		{
		}

		public void ReportProgress(float progress)
		{
		}

		public void Done(Action onResolved, Action<Exception> onRejected)
		{
		}

		public void Done(Action onResolved)
		{
		}

		public void Done()
		{
		}

		public IPromise WithName(string name)
		{
			return null;
		}

		public IPromise Catch(Action<Exception> onRejected)
		{
			return null;
		}

		public IPromise<ConvertedT> Then<ConvertedT>(Func<IPromise<ConvertedT>> onResolved)
		{
			return null;
		}

		public IPromise Then(Func<IPromise> onResolved)
		{
			return null;
		}

		public IPromise Then(Action onResolved)
		{
			return null;
		}

		public IPromise<ConvertedT> Then<ConvertedT>(Func<IPromise<ConvertedT>> onResolved, Func<Exception, IPromise<ConvertedT>> onRejected)
		{
			return null;
		}

		public IPromise Then(Func<IPromise> onResolved, Action<Exception> onRejected)
		{
			return null;
		}

		public IPromise Then(Action onResolved, Action<Exception> onRejected)
		{
			return null;
		}

		public IPromise<ConvertedT> Then<ConvertedT>(Func<IPromise<ConvertedT>> onResolved, Func<Exception, IPromise<ConvertedT>> onRejected, Action<float> onProgress)
		{
			return null;
		}

		public IPromise Then(Func<IPromise> onResolved, Action<Exception> onRejected, Action<float> onProgress)
		{
			return null;
		}

		public IPromise Then(Action onResolved, Action<Exception> onRejected, Action<float> onProgress)
		{
			return null;
		}

		private void ActionHandlers(IRejectable resultPromise, Action resolveHandler, Action<Exception> rejectHandler)
		{
		}

		private void ProgressHandlers(IRejectable resultPromise, Action<float> progressHandler)
		{
		}

		public IPromise ThenAll(Func<IEnumerable<IPromise>> chain)
		{
			return null;
		}

		public IPromise<IEnumerable<ConvertedT>> ThenAll<ConvertedT>(Func<IEnumerable<IPromise<ConvertedT>>> chain)
		{
			return null;
		}

		public static IPromise All(params IPromise[] promises)
		{
			return null;
		}

		public static IPromise All(IEnumerable<IPromise> promises)
		{
			return null;
		}

		public IPromise ThenSequence(Func<IEnumerable<Func<IPromise>>> chain)
		{
			return null;
		}

		public static IPromise Sequence(params Func<IPromise>[] fns)
		{
			return null;
		}

		public static IPromise Sequence(IEnumerable<Func<IPromise>> fns)
		{
			return null;
		}

		public IPromise ThenRace(Func<IEnumerable<IPromise>> chain)
		{
			return null;
		}

		public IPromise<ConvertedT> ThenRace<ConvertedT>(Func<IEnumerable<IPromise<ConvertedT>>> chain)
		{
			return null;
		}

		public static IPromise Race(params IPromise[] promises)
		{
			return null;
		}

		public static IPromise Race(IEnumerable<IPromise> promises)
		{
			return null;
		}

		public static IPromise Resolved()
		{
			return null;
		}

		public static IPromise Rejected(Exception ex)
		{
			return null;
		}

		public IPromise Finally(Action onComplete)
		{
			return null;
		}

		public IPromise ContinueWith(Func<IPromise> onComplete)
		{
			return null;
		}

		public IPromise<ConvertedT> ContinueWith<ConvertedT>(Func<IPromise<ConvertedT>> onComplete)
		{
			return null;
		}

		public IPromise Progress(Action<float> onProgress)
		{
			return null;
		}

		internal static void PropagateUnhandledException(object sender, Exception ex)
		{
		}
	}
}
