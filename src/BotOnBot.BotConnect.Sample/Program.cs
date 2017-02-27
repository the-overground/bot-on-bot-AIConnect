using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace BotOnBot.BotConnect.Sample
{
    internal static class Program
    {
        private static bool _running = true;

        internal static void Main(string[] args)
        {
            Task.Run(() => Connect());

            while (_running)
                Thread.Sleep(1);

            Console.ReadKey();
        }

        private static async Task Connect()
        {
            var api = new Api();
            var client = await api.Connect(IPAddress.Loopback);

            Console.WriteLine("I connected to the server! Sending start information");

            await client.SendStartInformation("Sample.bot", "bot irl");

            Console.WriteLine("Sent start information!");

            var gameSessionData = await client.ReadNextMessage();

            Console.WriteLine("I received the game session data!");

            _running = false;
        }
    }
}