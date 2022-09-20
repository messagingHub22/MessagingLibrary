using System.Net;

namespace MessagingLibrary
{
    public class Class1
    {
        // TODO: Replace with environment variable for server url. Temperarily testing with localhost
        private static string ApiUrl = "https://localhost:7047";

        public static string GetMessage()
        {
            string CallUrl = ApiUrl + "/MessageData";
            string json;

            using (WebClient wc = new WebClient())
            {
                json = wc.DownloadString(CallUrl);
            }

            return json;
        }
    }
}