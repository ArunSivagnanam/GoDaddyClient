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

        public Boolean login(String username, String password);

        public Boolean logOut();
       

        public Boolean register(User user);
        

        public void sendMessage(String username, String message);

        public String test()
        {
            User u = new User();
            u.name = "magic mike";
            return serverProxy.Register(u);
        }
         
        //** CALL BACK METHODS **//

        public void RecievMessage(String message)
        {
                Console.Write(message);
        }

        public void RecievLoggedInUsers(String message)
        {
                Console.Write(message);
        }

    }
}
