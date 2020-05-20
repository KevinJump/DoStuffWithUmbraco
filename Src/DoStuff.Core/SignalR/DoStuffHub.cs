using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;

namespace DoStuff.Core.SignalR
{
    public class DoStuffHub : Hub
    {
        /// <summary>
        ///  super simple chat app :)
        /// </summary>
        /// <remarks>
        ///  you don't have to call hub methods, to be 
        ///  able to send messages - but here if this
        ///  method is called, then its broadcast 
        ///  to all subscribed signalR clients.
        /// </remarks>
        /// <param name="message"></param>
        public void Hello(string message)
        {
            // all clients get a 'hello' event.
            this.Clients.All.Hello( $"{message} {DateTime.Now}" );

            // this is the person who sent the message
            this.Clients.Caller.Notify("sent");
        }
    }
}
