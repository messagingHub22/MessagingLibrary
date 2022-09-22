using System.Net;

namespace MessagingLibrary
{
    public class MessagingAPI
    {
        // TODO: Replace with environment variable for server url. Temperarily testing with localhost
        private static string ApiUrl = "https://localhost:7047";

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
            } catch (Exception e)
            {
                return "Error";
            }

            return json;
        }
    }
}