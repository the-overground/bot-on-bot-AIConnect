using System;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace BotOnBot.BotConnect
{
    public static class Api
    {
        private const int BOT_PORT = 1337;

        /// <summary>
        /// Connects the bot to the server and sends its welcome message.
        /// </summary>
        public static async Task<BotClient> Connect(IPAddress destinationAddress, string name, string author)
        {
            Console.WriteLine($"(BotConnect) Attempting to connect to {destinationAddress.ToString()}...");

            var client = new TcpClient(AddressFamily.InterNetwork);
            await client.ConnectAsync(destinationAddress, BOT_PORT);

            var botClient = new BotClient(client);
            await botClient.SendStartInformation(name, author);

            return botClient;
        }
    }
}
