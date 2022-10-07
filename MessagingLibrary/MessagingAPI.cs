using MessagingLibrary.Data;
using Newtonsoft.Json;
using System.Net;

namespace MessagingLibrary
{
    public class MessagingAPI
    {

        private static string ApiUrl = Environment.GetEnvironmentVariable("SERVER_API_URL");

        // Get all the messages sent to all users from server
        public async static Task<List<MessageData>> GetMessages()
        {
            string CallUrl = ApiUrl + "/api/getMessages";

            string? responseString;
            try
            {
                HttpClient client = new HttpClient();

                var response = await client.GetAsync(CallUrl);
                responseString = await response.Content.ReadAsStringAsync();

                var model = JsonConvert.DeserializeObject<List<MessageData>>(responseString);

                if (model == null)
                {
                    throw new Exception("Empty list"); // Returns new empty list
                }

                return model;
            }
            catch (Exception e)
            {
                return new List<MessageData>();
            }
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
        public async static Task<List<MessageData>> GetMessagesForUser(String User)
        {
            string CallUrl = ApiUrl + "/api/getMessagesForUser";
            string Parameters = "?User=" + User;

            string? responseString;
            try
            {
                HttpClient client = new HttpClient();

                var response = await client.GetAsync(CallUrl + Parameters);
                responseString = await response.Content.ReadAsStringAsync();

                var model = JsonConvert.DeserializeObject<List<MessageData>>(responseString);

                if (model == null)
                {
                    throw new Exception("Empty list"); // Returns new empty list
                }

                return model;
            }
            catch (Exception e)
            {
                return new List<MessageData>();
            }
        }

        // Mark the message with the given Id as read
        public static async Task<string> MarkMessageRead(String Id)
        {
            string CallUrl = ApiUrl + "/api/markMessageRead";
            string Parameters = "?Id=" + Id;

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
    }
}