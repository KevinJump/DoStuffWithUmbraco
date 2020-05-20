# SignalR

SignalR is a realtime communication framework for asp.net that lets you
communicate with browser clients from c# code without you having to worry
about all the pesky websockets stuff, 

https://dotnet.microsoft.com/apps/aspnet/signalr

## In Umbraco
Umbraco has bits of SignalR already built in (it is used in previews). 
Using this layer we can get signalR clients up fairly quickly

### SignalR Hubs
A Hub in signalR is the commication center for communication to/from a client, you need a hub as the thing to connect to.

Your hub is impliented in C# - [DoStuffHub.cs](DoStuffHub.cs) depending on how you want to communicate with the clients
your hub doesn't have to have any methods in it. 


### Javascript 
The javascript for our hub lives in our [SignalR App_Plugins folder](../App_Plugins/DoStuff.SignalR).
the hub initializes signalR and starts our hub up. 

the code for the hub is slightly complicated by two factors:

1. You might not be the first person to start up signalR. 

   There is a chance that something else has initialized signalR 
   before you came along, in this isntance you don't want to load
   up the libraries again as they re-initialize everything.

2. You have to ensure your events are registered before you start your hub - this is why we stop the hub first in the hubScript.


### ClientIds/Caller
Typically you can send messages with signalR in two ways, 1) to everyone via the `Clients.All`, or 2) a specific client (usally the on who called you)

When communicating directly with a hub - the hub can use the `Clients.Caller` object to send information directly back to the calling client. 

If you use signalR within an API controller then you may have to pass the clientId to the Controller method, this can then be used to get the client from the hub and send messages back to only that client. 