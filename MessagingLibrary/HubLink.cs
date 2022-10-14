

using Microsoft.AspNetCore.SignalR.Client;

namespace MessagingLibrary
{
    public class HubLink
    {

        // The user name logged in
        private static string UserName = "";

        // The last time messages was reloaded for this user after login
        private static DateTime ReloadTime = DateTime.MinValue;

        // The signalR hub connection
        private static HubConnection? connection;


        // Mark the message with the given Id as read
        public async static void LoginUser(String User)
        {
            UserName = User;

            connection = new HubConnectionBuilder()
                .WithUrl(new Uri(MessagingAPI.ApiUrl + "/messagingHub"))
                .WithAutomaticReconnect()
                .Build();

            connection.On<string>("ReloadMessageClient", (userClient) =>
            {
                if (UserName.Equals(userClient))
                {
                    ReloadTime = DateTime.Now;
                }
            });

            try
            {
                await connection.StartAsync();
            }
            catch (Exception ex)
            {
            }

        }

        // Send message to all connected signalR clients
        public async static void SendReloadMessage(String User)
        {
            try
            {
                await connection.InvokeAsync("ReloadMessage", User);
            }
            catch (Exception ex)
            {
            }
        }

        public static string ChangedTime()
        {
            return ReloadTime.ToString();
        }
    }
}
