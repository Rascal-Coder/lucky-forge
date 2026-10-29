namespace CBS.Models
{
	public enum MatchmakingStatus
	{
		None = 0,
		CreateTicket = 1,
		WaitingForPlayers = 2,
		WaitingForMatch = 3,
		Canceled = 4,
		Matched = 5
	}
}
