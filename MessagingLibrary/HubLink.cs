

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
                // Method that sends the user who got update to everyone
                // await connection.InvokeAsync("ReloadMessage", User);

                // Method to only send the update to the user got new message
                await connection.InvokeAsync("ReloadMessageForUser", User);
            }
            catch (Exception ex)
            {
            }
        }


        // Send user message update to all connected signalR clients
        public static async void SendReloadUserMessage(String User)
        {
            if (connection == null || connection.State == HubConnectionState.Disconnected)
            {
                await Task.Run(() => StartConnection());
            }

            try
            {
                // Method to only send the update to the user got new user message
                await connection.InvokeAsync("ReloadUserMessageForUser", User);
            }
            catch (Exception ex)
            {
            }
        }

    }
}
