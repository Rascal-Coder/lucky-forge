using System;
using System.Collections.Generic;
using CBS.Models;

namespace CBS
{
	public interface ITitleModule
	{
		void GetTitleDataByKey<T>(string key, Action<CBSGetTitleDataResult<T>> result) where T : TitleCustomData;

		void GetAllTitleData(Action<CBSGetAllTitleDataResult> result);

		void UpdateCacheFromServer(Action<CBSBaseResult> result);

		T GetFromCacheByKey<T>(string key) where T : TitleCustomData;

		Dictionary<string, CBSTitleData> GetAllFromCache();
	}
}
