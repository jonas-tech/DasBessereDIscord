using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DasBessereDIscord
{
    public interface IClient
    {
        //Set Messages
        string ClientSendMessageToServer();
        //Get Messages
        void ReceiveMessageFromServer(string fullMessage);
    }
}
