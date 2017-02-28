namespace BotOnBot.BotConnect
{
    public struct ServerMessage
    {
        public readonly string Message;
        public readonly string Status;

        internal ServerMessage(string message, string status)
        {
            Message = message;
            Status = status;
        }
    }
}
