﻿using MessagingLibrary.Data;
using Microsoft.AspNetCore.SignalR.Client;
using Newtonsoft.Json;
using System.Net;

namespace MessagingLibrary
{
    public class MessagingAPI
    {

        // The URL for server
        public static string ApiUrl = Environment.GetEnvironmentVariable("SERVER_API_URL");

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

            HubLink.SendReloadMessage(MessageUser);

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

        // Get the groups
        public async static Task<List<string>> GetGroups()
        {
            string CallUrl = ApiUrl + "/api/getGroups";

            string? responseString;
            try
            {
                HttpClient client = new HttpClient();

                var response = await client.GetAsync(CallUrl);
                responseString = await response.Content.ReadAsStringAsync();

                var model = JsonConvert.DeserializeObject<List<string>>(responseString);

                if (model == null)
                {
                    throw new Exception("Empty list"); // Returns new empty list
                }

                return model;
            }
            catch (Exception e)
            {
                return new List<String>();
            }
        }

        // Add a member to a group
        public static async Task<string> AddMemberToGroup(String GroupName, String MemberName)
        {
            string CallUrl = ApiUrl + "/api/addMemberToGroup";
            string Parameters = "?GroupName=" + GroupName + "&MemberName=" + MemberName;

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

        // Get the members in a group
        public async static Task<List<string>> GetGroupMembers(String Group)
        {
            string CallUrl = ApiUrl + "/api/getGroupMembers";
            string Parameters = "?Group=" + Group;

            string? responseString;
            try
            {
                HttpClient client = new HttpClient();

                var response = await client.GetAsync(CallUrl + Parameters);
                responseString = await response.Content.ReadAsStringAsync();

                var model = JsonConvert.DeserializeObject<List<string>>(responseString);

                if (model == null)
                {
                    throw new Exception("Empty list"); // Returns new empty list
                }

                return model;
            }
            catch (Exception e)
            {
                return new List<string>();
            }
        }
    }
}