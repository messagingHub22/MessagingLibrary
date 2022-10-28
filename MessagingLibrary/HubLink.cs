

using Microsoft.AspNetCore.SignalR.Client;

namespace MessagingLibrary
{
    public class HubLink
    {

        // The signalR hub connection
        private static HubConnection? connection;

        // Try to connect to hub
        public static async void StartConnection()
        {
            connection = new HubConnectionBuilder()
                .WithUrl(new Uri(MessagingAPI.ApiUrl + "/messagingHub"))
                .WithAutomaticReconnect()
                .Build();

            try
            {
                await connection.StartAsync();
            }
            catch (Exception ex)
            {
            }

        }

        // Send message to all connected signalR clients
        public static async void SendReloadMessage(String User)
        {
            if (connection == null || connection.State == HubConnectionState.Disconnected)
            {
                await Task.Run(() => StartConnection());
            }

            try
            {
                await connection.InvokeAsync("ReloadMessage", User);
            }
            catch (Exception ex)
            {
            }
        }

    }
}
