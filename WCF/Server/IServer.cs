using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EinBesseresDiscord
{
    interface IServer
    {
        void ClientLogIntoServer(bool ClientisLoggedin);

        void ServerSendMessageToClient(string clientMessage);

        void ServerGetMessageFromClient(string clientMessage);

        void ClientLogOutOfServer(bool ClientisLoggedin);
    }
}
