using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

public class foto2 : MonoBehaviour
{
	public enum CaptureSize
	{
		CameraSize = 0,
		ScreenResolution = 1,
		FixedSize = 2
	}

	[CompilerGenerated]
	private sealed class _003Cfotosirala2_003Ed__15 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public foto2 _003C_003E4__this;

		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return null;
			}
		}

		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return null;
			}
		}

		[DebuggerHidden]
		public _003Cfotosirala2_003Ed__15(int _003C_003E1__state)
		{
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			return false;
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		[DebuggerHidden]
		void IEnumerator.Reset()
		{
		}
	}

	[CompilerGenerated]
	private sealed class _003Cfotosirala_003Ed__16 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public foto2 _003C_003E4__this;

		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return null;
			}
		}

		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return null;
			}
		}

		[DebuggerHidden]
		public _003Cfotosirala_003Ed__16(int _003C_003E1__state)
		{
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			return false;
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		[DebuggerHidden]
		void IEnumerator.Reset()
		{
		}
	}

	public Camera targetCamera;

	public CaptureSize captureSize;

	public Vector2 pixelSize;

	public string savePath;

	public string fileName;

	private Vector2 size;

	private Vector2 sizenew;

	private void Start()
	{
	}

	public void saveCapture()
	{
	}

	public static Texture2D capture(Camera camera)
	{
		return null;
	}

	public static Texture2D capture(Camera camera, int width, int height)
	{
		return null;
	}

	public static void saveTexture(string path, Texture2D texture)
	{
	}

	private void Update()
	{
	}

	private void Gettry()
	{
	}

	[IteratorStateMachine(typeof(_003Cfotosirala2_003Ed__15))]
	private IEnumerator fotosirala2()
	{
		return null;
	}

	[IteratorStateMachine(typeof(_003Cfotosirala_003Ed__16))]
	private IEnumerator fotosirala()
	{
		return null;
	}
}
