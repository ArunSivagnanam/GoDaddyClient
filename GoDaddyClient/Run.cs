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

            Console.WriteLine("Login test: ");

            Boolean test = client.login("Hans","1234");
            if (test)
            {
                Console.WriteLine("Login test: Success");
            }
            else
            {
                Console.WriteLine("Login test: Failed");
            }

            // SEND MESSAGE TEST
            Console.WriteLine("Send message test: ");

            string response = client.sendMessage("Peter", "haaaai peeeeeter!!");
            Console.WriteLine("Sending message: /n"+response);
    
            // finished
            
            Console.WriteLine("\nMain finished");
            Console.Read();
            

        }
        
    }
}
