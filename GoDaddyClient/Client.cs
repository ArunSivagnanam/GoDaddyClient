using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using GoDaddyClient.ServiceReference;

namespace GoDaddyClient
{

    public class Client : InterfaceServerChatServiceCallback
    {

        public event EventHandler<MessageEvent> msgEvent;
        public event EventHandler<FriendListEvent> friendListEvent;
        ServiceReference.InterfaceServerChatServiceClient serverProxy;

        public User currentUser;
        public List<User> friendsList;
        public List<User> friendsToAccept; // pending friendsdd


        private void ThrowUpdateFriendListEvent(User u){

            EventHandler<FriendListEvent> handler = friendListEvent;
            if(friendListEvent != null) {
                handler(this, new FriendListEvent(u));
            }
        }


        public Client()
        {
            serverProxy = new InterfaceServerChatServiceClient(new InstanceContext(this));
            friendsList = new List<User>();
            friendsToAccept = new List<User>();
        }

        public Boolean login(String username, String password)
        {

            currentUser = serverProxy.Login(username, password);

            return (currentUser != null);
        }

        public Boolean logOut()
        {
            serverProxy.LogOut(currentUser.userName);
            return false;
        }

        public string register(User user)
        {
            String status = serverProxy.Register(user);

            return status;
        }


        public string sendMessage(String recieverName, String message)
        {
            Message m = new Message()
            {
                senderUserName = currentUser.userName,
                receiverUserName = recieverName,
                sendMessageTime = DateTime.Now,
                message = message
            };
            string response = serverProxy.SendMessage(m);
            return response;
        }

        public List<Message> GetMessageHistory(string friendUsername)
        {
            return (serverProxy.GetMessageHistory(currentUser.userName, friendUsername)).OfType<Message>().ToList();
        }

        public List<User> RecieveFriendList()
        { // kaldes kun en gang efter login, herefter opdatere callback metoden lsiten

            friendsList = (serverProxy.ReceiveFriendList(currentUser.userName)).OfType<User>().ToList(); // this isn't going to be fast.
            return friendsList;
            //Console.WriteLine("recieved friends = " + friendsList.Count);

            //foreach (User u in friendsList)
            //{
             // Console.WriteLine("Name : " + u.firstName);
              //Console.WriteLine("Status: " + u.status);
            //}
        }

        public List<User> ReciveFriendsToAccept()
        { // Kaldes kun en gang efter login, herefter updateres listen af callback metoder
            friendsToAccept = (serverProxy.ReceiveFriendsToAccept(currentUser.userName)).OfType<User>().ToList();
            return friendsToAccept;



           // Console.WriteLine("recieved friends to accept = " + friendsToAccept.Count);

            //I en liste
           // foreach (User u in friendsList)
           // {
            //    Console.WriteLine("Name : " + u.firstName);
           //     Console.WriteLine("Status: " + u.status);
           // }
        }


        public string AddFriend(string friendUsername)
        {
            return serverProxy.AddFriend(currentUser.userName,friendUsername);
        }

        public string AcceptFriend(string requesterFriend)
        {
            return serverProxy.AcceptFriend(requesterFriend, currentUser.userName);
        }

        //** CALL BACK METHODS **//

        public void RecievMessage(String message)
        {

            EventHandler<MessageEvent> handler = msgEvent;
            if (msgEvent != null)
            {
                handler(this, new MessageEvent(message));
            }

            Console.WriteLine("Received message : "+message);
        }

       
        public void UpdateFriendList(User user)// den nye bruger som gået online
        {
                Console.WriteLine("User is online now : " + user.firstName);
                friendsList.Add(user);

                ThrowUpdateFriendListEvent(user);
        }

        public void UpdateFriendListRemove(User user)
        {
            Console.WriteLine("User is offline: " + user.firstName);
            friendsList.Remove(user);
        }

        public void UpdateFriendsToAcceptList(User user)
        {
            friendsToAccept.Add(user);
        }

       public void removeFromPendingList(User user)
       {
           friendsToAccept.Remove(user);
       }       
        
    }
}
