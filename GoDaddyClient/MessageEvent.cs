using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoDaddyClient
{
    public class MessageEvent : EventArgs
    {
        //privvate Message msg { get;};
        public string message { get; private set; }
        public MessageEvent(string message)
        {
            this.message = message;
        }
    }
}
