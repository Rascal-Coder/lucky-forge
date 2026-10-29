using System;
using System.Collections.Generic;

namespace CBS.Models
{
	[Serializable]
	public class Categories
	{
		public List<string> List;

		public string TitleKey { get; set; }
	}
}
