﻿using System;
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

            currentUser = serverProxy.Login(username, password);

            return (currentUser != null);
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

        public void RecieveFriendList(User[] friends)
        {
            Console.WriteLine("recieved friends = "+friends.Length);

            foreach (User u in friends)
            {
                Console.WriteLine("Name : "+u.firstName);
                Console.WriteLine("Status: "+u.status);
            }
        }

        public void UpdateFriendLits(User user)
        {
                Console.WriteLine("User is online now : " + user.firstName);

        }
        
    }
}
