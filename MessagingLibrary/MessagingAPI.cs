using System.Net;

namespace MessagingLibrary
{
    public class MessagingAPI
    {

        private static string ApiUrl = Environment.GetEnvironmentVariable("SERVER_API_URL");

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

        public static void SendMessage(String SentTime, String Content, String MessageCategory, String MessageUser)
        {
            string CallUrl = ApiUrl + "/api/sendMessage";
            string Parameters = "SentTime=" + SentTime + "&Content=" + Content + "&MessageCategory=" + MessageCategory + "&MessageUser=" + MessageUser;

            try
            {   
                using (WebClient wc = new WebClient())
                {
                    wc.Headers[HttpRequestHeader.ContentType] = "application/x-www-form-urlencoded";
                    string HtmlResult = wc.UploadString(CallUrl, Parameters);
                }
            }
            catch (Exception e)
            {
                // Error
            }
        }
    }
}