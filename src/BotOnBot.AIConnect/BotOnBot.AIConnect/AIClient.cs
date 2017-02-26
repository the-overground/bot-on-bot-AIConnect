using System.IO;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace BotOnBot.AIConnect
{
    public sealed class AIClient
    {
        private readonly TcpClient _client;

        internal AIClient(TcpClient client)
        {
            _client = client;
        }

        public async Task<string> ReadNextMessage()
        {
            var result = string.Empty;
            using (StreamReader sr = new StreamReader(_client.GetStream()))
            {
                result = await sr.ReadToEndAsync();
            }
            return result;
        }

        public async Task SendMessage(string message)
        {
            using (StreamWriter sw = new StreamWriter(_client.GetStream()))
            {
                await sw.WriteAsync(message);
            }
        }

        public void Disconnect()
        {
            _client.Client.Shutdown(SocketShutdown.Both);
        }
    }
}
