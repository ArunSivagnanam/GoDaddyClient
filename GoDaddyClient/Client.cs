using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using GoDaddyClient.ServiceReference;

namespace GoDaddyClient
{
    class Client
    {
        static void Main(string[] args)
        {
            ChatInterfaceClient client = new ChatInterfaceClient();

            User u = new User();
            u.name = "Arun";
            Console.Write(client.Login(u));
            Console.Read();
        }
    }
}
