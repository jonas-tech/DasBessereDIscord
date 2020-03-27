using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DasBessereDIscord.Server
{
    interface IServer
    {
        void ClientLogIntoServer(bool ClientisLoggedin);

        string ServerSendMessageToClient(string clientMessage);

        void ServerGetMessageFromClient(string clientMessage);

        void ClientLogOutOfServer(bool ClientisLoggedin, int clientNumber);
    }
}
