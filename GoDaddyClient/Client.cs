using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using GoDaddyClient.ServiceReference;

namespace GoDaddyClient
{

    class Client : InterfaceServerChatServiceCallback
    {

        ServiceReference.InterfaceServerChatServiceClient serverProxy;

        User currentUser;


        public Client()
        {
            serverProxy = new InterfaceServerChatServiceClient(new InstanceContext(this));
        }

        public Boolean login(String username, String password)
        {
            return false;
        }

        public Boolean logOut()
        {
            return false;
        }


        public string register(User user)
        {
            String status = serverProxy.Register(user);

            return status;
        }


        public void sendMessage(String username, String message)
        {

        }

        public String test()
        {
           // User u = new User();
           // u.userName = "magic mike";
           // return serverProxy.Register(u);
            return null;
        }
         
        //** CALL BACK METHODS **//

        public void RecievMessage(String message)
        {
                Console.Write(message);
        }

        

    }
}
