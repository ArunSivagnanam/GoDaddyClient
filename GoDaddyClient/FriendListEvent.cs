using GoDaddyClient.ServiceReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoDaddyClient
{
    public class FriendListEvent : EventArgs
    {
        public FriendListEvent(User u)
        {
            this.u = u;
        }
       public User u;
    }
}
