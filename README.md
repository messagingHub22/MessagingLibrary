# MessagingLibrary

MessagingLibrary is a C# class library that is used to send requests from server and can pass the results back to the client.  
It also sends signalR requests to update messages when a new message or user messsage is created.

### Main files description

**MessagingLibrary/MessagingAPI.cs** - It is a class that makes reequests to the server and it is used to fetch the results.  
**MessagingLibrary/HubLink.cs** - It is a class used by MessagingAPI to send requests to signalR to update messages for connected clients.  
**MessagingLibrary/Data/MessageData.cs** - It is a data class to represent a server to user message.  
**MessagingLibrary/Data/MessageUser.cs** - It is a data class to represent a user to user message.  
