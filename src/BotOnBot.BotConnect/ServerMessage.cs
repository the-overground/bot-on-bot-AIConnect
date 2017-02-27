namespace BotOnBot.BotConnect
{
    public struct ServerMessage
    {
        public readonly string Message;
        public readonly ServerMessageType Type;

        internal ServerMessage(string message, ServerMessageType type)
        {
            Message = message;
            Type = type;
        }
    }
}
