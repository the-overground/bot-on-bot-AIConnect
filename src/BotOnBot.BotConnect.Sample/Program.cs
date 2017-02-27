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
            Console.WriteLine("I will now connect to the server and send start information!");
            var client = await Api.Connect(IPAddress.Loopback, "Sample.bot", "bot irl");

            Console.WriteLine("I connected to the server!");
            
            var response = await client.ReadNextMessage();
            Console.WriteLine($"I received a response! The type was {response.Type.ToString()}. Owww :S");

            _running = false;
        }
    }
}