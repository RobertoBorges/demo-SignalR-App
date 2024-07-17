using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR.Client;

class Program
{
    static async Task Main(string[] args)
    {
        var connection = new HubConnectionBuilder()
            .WithUrl("http://localhost:5142/notificationHub")
            .Build();

        connection.On<string, string>("ReceiveMessage", (user, message) =>
        {
            Console.WriteLine($"{user}: {message}");
        });

        try
        {
            await connection.StartAsync();
            Console.WriteLine("Connected to the SignalR hub.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error connecting to the SignalR hub: {ex.Message}");
        }

        Console.WriteLine("Press any key to exit...");
        Console.ReadKey();
        await connection.StopAsync();
    }
}
