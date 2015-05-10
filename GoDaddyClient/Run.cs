using GoDaddyClient.ServiceReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoDaddyClient
{
    class Run
    {

        public static void Main(string[] args)
        {
            
            Client client = new Client();
          
            while (true)
            {
                Console.WriteLine("Welcome to Command GoDaddy Chat");
                Console.WriteLine(" 'Register', 'Login', 'LogOut', 'AddFriend', 'ViewFriendsToAccept',\n 'AcceptFirend', 'SendMessage', GetMessageHistory");
                string command = Console.ReadLine();
                
                switch (command) {

                    case "Login":
                        login(client);
                        break;

                    case "LogOut":
                        logOut(client);
                        break;

                    case "Register":              
                        register(client);
                        break;

                    case "AddFriend":
                        AddFriend(client);
                        break;

                    case "ViewFriendsToAccept":
                        client.ReciveFriendsToAccept();
                        break;

                    case "AcceptFirend":
                        AcceptFirend(client);
                        break;

                    case "SendMessage":
                        sendMessage(client);
                        break;

                    case "GetMessageHistory":
                        printMessageHist(client);
                        break;
           
                }

            }
           
        }


        public static void register(Client client)
        {
            Console.WriteLine("Enter Username:");
            string userName = Console.ReadLine();

            Console.WriteLine("Enter Password:");
            string password = Console.ReadLine();

            Console.WriteLine("Enter Firstname:");
            string firstName = Console.ReadLine();

            Console.WriteLine("Enter Lastname:");
            string lastName = Console.ReadLine();

            User u = new User()
            {
                userName = userName,
                password = password,
                firstName = firstName,
                lastName = lastName
            };

            client.register(u);
            Console.WriteLine("Registration Success");
        }

        public static void login(Client client)
        {
            Console.WriteLine("Enter Username:");
            string username = Console.ReadLine();
            Console.WriteLine("Enter password:");
            string password = Console.ReadLine();

            if (client.login(username, password))
            {
                client.RecieveFriendList();
                client.ReciveFriendsToAccept();
                Console.WriteLine("Login Success");
                Console.WriteLine("Logged in as " + client.currentUser.userName);
            }
            else
            {
                Console.WriteLine("Login failed, register or check username and password");
            }
           
        }

        public static void logOut(Client client)
        {
            client.logOut();
            Console.WriteLine("You are now logged out");

        }

        public static void AddFriend(Client client){
              
            Console.WriteLine("Enter friend username");
            string friendUsername = Console.ReadLine();

            client.AddFriend(friendUsername);
            Console.WriteLine("Friend request sent"); 
        }

        public static void AcceptFirend(Client client)
        {

            Console.WriteLine("Enter friend username");
            string friendUsername = Console.ReadLine();

            client.AcceptFriend(friendUsername);
            Console.WriteLine("Friend accepted");
        }

        public static void sendMessage(Client client)
        {
            Console.WriteLine("Enter user - to send message to:");
            string user = Console.ReadLine();
            Console.WriteLine("Write message to send:");
            string message = Console.ReadLine();
            string response = client.sendMessage(user, message);
            Console.WriteLine("You sent: " + response);
        }

        public static void printMessageHist(Client client){

            Console.WriteLine("Enter user - to get hist from:");
            string fiendUsername = Console.ReadLine();
            List<Message> messageList = client.GetMessageHistory(fiendUsername);

            foreach (Message m in messageList)
            {
                Console.WriteLine("Receiver: "+m.receiverUserName+" Sender: "+m.senderUserName+" Send time: "+m.sendMessageTime+" Message: "+m.message);
            }

        }
        
    }
}
