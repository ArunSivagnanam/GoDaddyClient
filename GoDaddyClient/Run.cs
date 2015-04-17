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

            Console.Write(client.test());
            

        }
        
    }
}
