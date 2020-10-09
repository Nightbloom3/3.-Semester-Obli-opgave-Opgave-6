using System;

namespace Opgave_6_TCP_server
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "My TCP Server";

            Server server = new Server();
            server.Start();
        }
    }
}
