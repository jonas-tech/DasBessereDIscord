using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;
using DasBessereDIscord.Server;

namespace DasBessereDIscord.Server
{
    class ChatServer : IServer
    {
        private List<Socket> clientSockets = new List<Socket>();

        Socket chatSocket;

        Socket clientSocket;

        IPHostEntry chatIPhost;

        IPAddress clientIPadress;

        IPEndPoint clientIPendPoint;

        int amountOfclients;

        public void ClientLogIntoServer(bool ClientisLoggedin)
        {
            if (ClientisLoggedin == true)
            {
                chatIPhost = Dns.GetHostEntry("");

                clientIPadress = chatIPhost.AddressList[0];

                clientIPendPoint = new IPEndPoint(clientIPadress, 53225);

                chatSocket.Bind(clientIPendPoint);

                chatSocket.Listen(2);

                clientSocket.Connect(clientIPendPoint);

                clientSockets.Add(clientSocket);

                amountOfclients++;
            }
        }

        public string ServerSendMessageToClient(string clientMessage)
        {
            return clientMessage;
        }

        public void ServerGetMessageFromClient(string clientMessage)
        {
            IsClientMessageNull(clientMessage);

        }

        public void ClientLogOutOfServer(bool ClientisLoggedin, int clientNumber)
        {
            if (ClientisLoggedin == false)
            {
                clientSockets[clientNumber].Close();

                clientSockets.Remove(clientSockets[clientNumber]);

                amountOfclients--;
            }
        }

        private void IsClientMessageNull(string clientMessage)
        {
            if (clientMessage == null)
            {
                return;
            }
            else
            {
                ServerSendMessageToClient(clientMessage);
            }
        }
    }
}
