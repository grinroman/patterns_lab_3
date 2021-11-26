using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace patterns_lab_3
{

    interface IChat
    {
        void SendMessage(string message, User user);
        void AppendUser(User user);
    }

    class ChatMediator : IChat
    {
        private List<User> users;
        public ChatMediator() => users = new List<User>();
        public void AppendUser(User user) => users.Add(user);
        public void SendMessage(string message, User me)
        {
            users.Where(user => user != me)
                 .ToList()
                 .ForEach(e => e.PrintMessage(message));
           Console.WriteLine("====");
        }
    }

    class User
    {
        private IChat chatroom;
        private string nickname;
        public string Nickname => nickname;
        public User(IChat chat, string nick)
        {
            this.chatroom = chat;
            this.nickname = nick;
        }

        public void SendMessage(string text) { chatroom.SendMessage(text, this); }
        public void PrintMessage(string text) { Console.WriteLine($"{nickname}: {text}"); }
    }
}
