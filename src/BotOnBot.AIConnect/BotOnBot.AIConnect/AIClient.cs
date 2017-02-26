using System.Net.Sockets;
using System.Threading.Tasks;

namespace BotOnBot.AIConnect
{
    /// <summary>
    /// Connects your AI to the game server.
    /// </summary>
    public sealed class AIClient
    {
        private readonly TcpClient _client;

        internal AIClient(TcpClient client)
        {
            _client = client;
        }

        /// <summary>
        /// Reads and returns the next message from the game server.
        /// </summary>
        public async Task<string> ReadNextMessage()
        {
            var result = string.Empty;
            using (var sr = StreamFactory.CreateReader(_client.GetStream()))
            {
                result = await sr.ReadLineAsync();
            }
            return result;
        }

        /// <summary>
        /// Sends a custom message to the game server.
        /// </summary>
        public async Task SendMessage(string message)
        {
            using (var sw = StreamFactory.CreateWriter(_client.GetStream()))
            {
                await sw.WriteLineAsync(message);
            }
        }

        public async Task SendStartInformation(string name, string author)
        {
            await SendMessage($"{{\"name\":\"{name}\",\"author\":\"{author}\"}}");
        }

        /// <summary>
        /// Closes the connection to the game server.
        /// </summary>
        public void Disconnect()
        {
            _client.Client.Shutdown(SocketShutdown.Both);
        }
    }
}
