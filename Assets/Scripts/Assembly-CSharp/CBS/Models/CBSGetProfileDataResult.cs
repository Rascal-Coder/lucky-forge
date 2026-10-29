using System.Collections.Generic;
using PlayFab.ClientModels;

namespace CBS.Models
{
	public class CBSGetProfileDataResult : CBSBaseResult
	{
		public Dictionary<string, UserDataRecord> Data;
	}
}
