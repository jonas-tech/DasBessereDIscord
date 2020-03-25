using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DasBessereDIscord.Client.ViewModel;

namespace DasBessereDIscord.Client.Model
{
    class Messaging
    {
        string userName;
        string userMessage;
        string fullMesssage;

        public void SetUserName(string userName)
        {
            this.userName = userName;
        }

        public void SetMessage(string userMessage)
        {
            this.userMessage = userMessage;
            CreatFullMessage();
        }

        public void CreatFullMessage()
        {
            this.fullMesssage = DateTime.Now.ToString() + " von " + userName + " : " + userMessage;
        }

    }
}
