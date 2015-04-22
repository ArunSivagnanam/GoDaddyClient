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

            Console.Write("\nRegister test: ");
            Console.Write(client.register(u));


            Console.Write(client.test());

            Console.Write("\nMain finished");
            Console.Read();
            

        }
        
    }
}
