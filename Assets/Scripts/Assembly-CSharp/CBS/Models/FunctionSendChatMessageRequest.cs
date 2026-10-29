namespace CBS.Models
{
	public class FunctionSendChatMessageRequest : FunctionBaseRequest
	{
		public string ChatID;

		public string SenderProfileID;

		public string ReceiverProfileID;

		public string InterlocutorProfileID;

		public MessageContent ContentType;

		public ChatTarget Target;

		public ChatAccess Visibility;

		public string CustomData;

		public string MessageBody;

		public string ItemInstanceID;

		public string StickerID;

		public bool IsValidInput()
		{
			return false;
		}
	}
}
