using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using GoDaddyClient.ServiceReference;

namespace GoDaddyClient
{

  
    class run
    {
        public static void Main(string[] args)
        {

            CallBackMethods callback = new CallBackMethods();



            ServiceReference.InterfaceServerChatServiceClient client = 
                new InterfaceServerChatServiceClient(new InstanceContext(callback));

            User u = new User();
            u.name = "Arun";
            Console.Write(client.Register(u));
            Console.Read();
        }

        //** CALL BACK METHODS **//

        class CallBackMethods : InterfaceServerChatServiceCallback
        {

            public void RecievMessage(String message)
            {
                Console.Write(message);
            }

        }





    }
}
