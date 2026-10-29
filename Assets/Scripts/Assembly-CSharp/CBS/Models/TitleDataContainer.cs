using System.Collections.Generic;

namespace CBS.Models
{
	public class TitleDataContainer
	{
		public Dictionary<string, CBSTitleData> TitleData;

		public TitleDataContainer()
		{
		}

		public TitleDataContainer(Dictionary<string, string> inputData)
		{
		}

		public void Add(string dataKey, CBSTitleData titleData)
		{
		}

		public void Add(CBSTitleData titleData)
		{
		}

		public void Remove(string dataKey)
		{
		}

		public Dictionary<string, CBSTitleData> GetAll()
		{
			return null;
		}
	}
}
