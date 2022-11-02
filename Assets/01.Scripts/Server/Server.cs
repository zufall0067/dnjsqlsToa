using System;
using System.Net;
using WebSocketSharp;
using WebSocketSharp.Server;

namespace Example
{
    class Server : WebSocketBehavior
    {
        protected override void OnMessage(MessageEventArgs e)
        {
            var msg = e.Data;
            Send(msg);
        }
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            var wssv = new WebSocketServer(IPAddress.Any, 6000);
            wssv.AddWebSocketService<Server>("/Server");
            wssv.Start();
            Console.ReadKey(true);
            wssv.Stop();


        }
    }

}
