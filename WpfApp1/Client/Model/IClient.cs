using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DasBessereDIscord
{
    interface IClient
    {
        //Set Messages
        string ClientSendMessageToServer(string clientMessage);
        //Get Messages
        void ReceiveMessageFromServer(string serverMessage);
    }
}
