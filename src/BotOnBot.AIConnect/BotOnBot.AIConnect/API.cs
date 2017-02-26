using System;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace BotOnBot.AIConnect
{
    public sealed class Api
    {
        private const int AI_PORT = 1337;

        public async Task<AIClient> Connect(IPAddress address)
        {
            Console.WriteLine($"(AIConnect) Attempting to connect to {address.ToString()}...");

            var client = new TcpClient(AddressFamily.InterNetwork);
            await client.ConnectAsync(address, AI_PORT);

            return new AIClient(client);
        }
    }
}
