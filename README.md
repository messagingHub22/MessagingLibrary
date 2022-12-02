# MessagingLibrary

MessagingLibrary is a C# class library that is used to send requests from server and can pass the results back to the client.  
It also sends signalR requests to update messages when a new message or user message is created.  
MessagingLibrary is a dependency of MessagingClient. Clone both projects in their folders which should be placed in the same directory and then MessagingClient can be compiled.  


### Main files description

**MessagingLibrary/MessagingAPI.cs** - It is a class that makes requests to the server and it is used to fetch the results.  
**MessagingLibrary/HubLink.cs** - It is a class used by MessagingAPI to send requests to signalR to update messages for connected clients.  
**MessagingLibrary/Data/MessageData.cs** - It is a data class to represent a server to user message.  
**MessagingLibrary/Data/MessageUser.cs** - It is a data class to represent a user to user message.  
