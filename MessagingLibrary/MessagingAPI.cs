using System.Net;

namespace MessagingLibrary
{
    public class MessagingAPI
    {

        private static string ApiUrl = Environment.GetEnvironmentVariable("SERVER_API_URL");

        // Get all the messages sent to all users from server
        public static string GetMessages()
        {
            string CallUrl = ApiUrl + "/api/getMessages";
            string Json;

            try
            {
                using (WebClient wc = new WebClient())
                {
                    Json = wc.DownloadString(CallUrl);
                }
            }
            catch (Exception e)
            {
                return "Error";
            }

            return Json;
        }

        // Send a message to a user from server
        public static async Task<string> SendMessage(String SentTime, String Content, String MessageCategory, String MessageUser)
        {
            string CallUrl = ApiUrl + "/api/sendMessage";
            string Parameters = "?SentTime=" + SentTime + "&Content=" + Content + "&MessageCategory=" + MessageCategory + "&MessageUser=" + MessageUser;

            string? responseString;
            try
            {
                HttpClient client = new HttpClient();

                var response = await client.PostAsync(CallUrl + Parameters, null);
                responseString = await response.Content.ReadAsStringAsync();
            }
            catch (Exception e)
            {
                responseString = "Error";
            }

            return responseString;
        }

        // Get the messages sent to a user from server
        public static string GetMessagesForUser(String User)
        {
            string CallUrl = ApiUrl + "/api/getMessagesForUser";
            string Parameters = "?User=" + User;
            string Json;

            try
            {
                using (WebClient wc = new WebClient())
                {
                    Json = wc.DownloadString(CallUrl + Parameters);
                }
            }
            catch (Exception e)
            {
                return "Error";
            }

            return Json;
        }
    }
}