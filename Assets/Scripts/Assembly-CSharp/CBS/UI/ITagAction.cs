using System;
using CBS.Models;

namespace CBS.UI
{
	public interface ITagAction
	{
		Action<ChatMember> TagAction { get; set; }
	}
}
