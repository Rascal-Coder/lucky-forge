using System;
using System.Collections.Generic;
using CBS.Models;
using CBS.Playfab;

namespace CBS
{
	public class CBSTitleDataModule : CBSModule, ITitleModule
	{
		private IFabTitle FabTitle { get; set; }

		private Dictionary<string, CBSTitleData> TitleCache { get; set; }

		protected override void Init()
		{
		}

		public void GetTitleDataByKey<T>(string key, Action<CBSGetTitleDataResult<T>> result) where T : TitleCustomData
		{
		}

		public void GetAllTitleData(Action<CBSGetAllTitleDataResult> result)
		{
		}

		public void UpdateCacheFromServer(Action<CBSBaseResult> result)
		{
		}

		public T GetFromCacheByKey<T>(string key) where T : TitleCustomData
		{
			return null;
		}

		public Dictionary<string, CBSTitleData> GetAllFromCache()
		{
			return null;
		}

		internal void ParseData(Dictionary<string, string> data)
		{
		}

		private void ClearCache()
		{
		}

		protected override void OnLogout()
		{
		}
	}
}
