

using Microsoft.AspNetCore.SignalR.Client;

namespace MessagingLibrary
{
    public class HubLink
    {

        // Last updated times for every user
        private static Dictionary<string, DateTime> ReloadTimes = new Dictionary<string, DateTime>();

        // The signalR hub connection
        private static HubConnection? connection;


        // Mark the message with the given Id as read
        public async static void LoginUser(String User)
        {
            ReloadTimes.Add(User, DateTime.MinValue);

            connection = new HubConnectionBuilder()
                .WithUrl(new Uri(MessagingAPI.ApiUrl + "/messagingHub"))
                .WithAutomaticReconnect()
                .Build();

            connection.On<string>("ReloadMessageClient", (userClient) =>
            {
                ReloadTimes[userClient] = DateTime.Now;
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

        // The updated time for last message for this user
        public static string ChangedTime(String User)
        {
            return ReloadTimes[User].ToString();
        }
    }
}
