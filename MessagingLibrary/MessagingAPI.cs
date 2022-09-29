using System.Net;

namespace MessagingLibrary
{
    public class MessagingAPI
    {

        private static string ApiUrl = Environment.GetEnvironmentVariable("SERVER_API_URL");

        public static string GetMessages()
        {
            string CallUrl = ApiUrl + "/api/getMessages";
            string json;

            try
            {
                using (WebClient wc = new WebClient())
                {
                    json = wc.DownloadString(CallUrl);
                }
            }
            catch (Exception e)
            {
                return "Error";
            }

            return json;
        }
    }
}