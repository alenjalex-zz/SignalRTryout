
namespace SignalRClientTest1
{
    using Microsoft.AspNetCore.SignalR.Client;
    using System;

    class Program
    {
        private static readonly Action<string> OnReceivedAction = OnReceived;

        static void Main(string[] args)
        {
            Console.WriteLine("Connecting...");
            Connect();
            Console.ReadLine();
        }

        private static async void Connect()
        {
            var hubConnectionBuilder = new HubConnectionBuilder();

            var hubConnection = hubConnectionBuilder.WithUrl("http://localhost:56349/timeHub").Build();

            await hubConnection.StartAsync();
            Console.WriteLine("Connected");
            var on = hubConnection.On("ReceiveMessage", OnReceivedAction);

            Console.WriteLine("Receiving");

            Console.ReadLine();
            Console.WriteLine("Done..");

            on.Dispose();
            await hubConnection.StopAsync();
        }

        static void OnReceived(string message)
        {
            Console.WriteLine($"{message}");
        }
    }
}
