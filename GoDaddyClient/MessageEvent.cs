using GoDaddyClient.ServiceReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoDaddyClient
{
    public class MessageEvent : EventArgs
    {
        //privvate Message msg { get;};gh
        public Message message { get; private set; }
        public MessageEvent(Message message)
        {
            this.message = message;
        }
    }
}
