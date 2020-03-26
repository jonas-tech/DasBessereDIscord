using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DasBessereDIscord.Client.ViewModel;
using WpfApp1.Proxy;
using WpfApp1.Model;

namespace DasBessereDIscord.Client.Model
{
    public class Client : IClient
    {
        string fullMessage;
        //Set Messages
        public void SendMessageInternal(string fullMessage)
        {
            this.fullMessage = fullMessage;
            ClientSendMessageToServer();
        }
        public string ClientSendMessageToServer()
        {
            return fullMessage;
        }

        //Get Messages
        public void ReceiveMessageFromServer(string fullMessage)
        {
            this.fullMessage = fullMessage;
            ReceiveMessageIntern();
        }

        public string ReceiveMessageIntern()
        {
            return fullMessage;
        }
    }
}
