using System.Collections.Generic;
using CBS.Models;
using UnityEngine;

namespace CBS.Scriptable
{
	[CreateAssetMenu(fileName = "IAPConfig", menuName = "CBS/Add new IAP Config")]
	public class IAPConfig : CBSScriptable
	{
		public bool EnableIAP;

		public List<CBSExternalProduct> ExternalIDs;

		public override string ResourcePath => null;
	}
}
