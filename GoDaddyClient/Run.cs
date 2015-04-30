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
            Console.WriteLine("Welcome to Command stage");
            Console.WriteLine("Command choice - 'Login', 'SendMessage' 'Register'");
            string command = Console.ReadLine();
            Client client = new Client();

            while (true)
            {
                switch (command) {
 

                case "Login":
                Console.WriteLine("Enter Username:");
                string Lusername = Console.ReadLine();
                Console.WriteLine("Enter password:");
                string Lpassword = Console.ReadLine();
                client.login(Lusername, Lpassword);
                Console.WriteLine("Login Success");
                break;

                case "SendMessage":
                Console.WriteLine("Enter user - to send message to:");
                string Muser = Console.ReadLine();
                Console.WriteLine("Write message to send:");
                string Mmessage = Console.ReadLine();
                client.sendMessage(Muser, Mmessage);
                Console.WriteLine("SendMessage Success");
                break;


                case "Register":              
                Console.WriteLine("Enter Username:");
                string RuserName = Console.ReadLine();

                Console.WriteLine("Enter Password:");
                string rPassword = Console.ReadLine();

                Console.WriteLine("Enter Firstname:");
                string rFirstName = Console.ReadLine();

                Console.WriteLine("Enter Lastname:");
                string rLastName = Console.ReadLine();

                User u = new User()
                {
                    userName = RuserName,
                    password = rPassword,
                    firstName = rFirstName,
                    lastName = rLastName,
                };
                client.register(u);
                Console.WriteLine("Registration Success");
                break;
            }
            }
            //test();
            


        }


        public static void test()
        {
            Client client = new Client();


            // REGISTER TEST 

            User u = new User()
            {
                firstName = "Hans",
                lastName = "Hansen",
                userName = "hh",
                password = "1234",
                status = 1
            };

            Console.WriteLine("Register test: ");
            Console.WriteLine(client.register(u));


            // LOGIN TEST

            Console.Write("Login test: ");

            Boolean test = client.login("Peter", "1234");
            if (test)
            {
                Console.WriteLine("Success");
            }
            else
            {
                Console.WriteLine("Failed");
            }


            // RECIEVE FRIENDS TEST
            Console.WriteLine("Recieve friends test: ");

            client.RecieveFriendList();


            // SEND MESSAGE TEST
            //Console.WriteLine("Send message test: ");

            //string response = client.sendMessage("Peter", "haaaai peeeeeter!!");
            //Console.WriteLine("Sending message: /n" + response);


            // ADD FRIEND TEST
            //Console.WriteLine("Add friend test: ");
            //String addFriendResponse = client.AddFriend("Peter");
            //Console.WriteLine(addFriendResponse);

            // RECIEVE FRIENDS TO ACCEPT TEST
            
            Console.WriteLine("Receive friends to accept test: ");
            client.ReciveFriendsToAccept();

            // ACCEPT FIRNED TEST
            Console.WriteLine("Accept friend test: ");
            string result = client.AcceptFriend("Hans");
            Console.WriteLine(result);
            
            
            
            
            // finished

            Console.WriteLine("\nMain finished");
            Console.Read();
        }
        
    }
}
