using EinBesseresDiscord;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace DasBessereDIscord.Server
{
    class ChatServer : IServer
    {
        private byte[] chatBuffer = new byte[3600];

        private List<Socket> clientSockets = new List<Socket>();

        Socket chatSocket;

        IPHostEntry chatIPhost;

        IPAddress clientIPadress;

        IPEndPoint clientIPendPoint;


        public void ClientLogIntoServer(bool ClientisLoggedin)
        {
            if (ClientisLoggedin == true)
            {
                chatIPhost = Dns.GetHostEntry("");

                clientIPadress = chatIPhost.AddressList[0];

                clientIPendPoint = new IPEndPoint(clientIPadress, 4510);

                chatSocket.Bind(clientIPendPoint);

                chatSocket.Listen(2);

                chatSocket.BeginAccept(new AsyncCallback(ChatAcceptCallBack), null);
            }
        }

        public void ServerSendMessageToClient(string clientMessage)
        {
          
        }

        public void ServerGetMessageFromClient(IAsyncResult asyncResult)
        {
            Socket chatSocketfromGetcallBackfromAsyncresult = (Socket)asyncResult.AsyncState;

            int clientMessagefromAsyncresult = chatSocketfromGetcallBackfromAsyncresult.EndReceive(asyncResult);

            byte[] messageBuffer = new byte[clientMessage];

            Array.Copy(chatBuffer, messageBuffer, clientMessage);

            string clientMessage = Encoding.ASCII.GetString(messageBuffer);

            IsClientMessageNull(clientMessage, chatSocketfromGetcallBackfromAsyncresult);
        }

        public void ClientLogOutOfServer(bool ClientisLoggedin)
        {
        }

        private void ChatAcceptCallBack(IAsyncResult asyncResult)
        {
            Socket chatSocketfromAcceptcallBackfromAsyncresult = chatSocket.EndAccept(asyncResult);

            clientSockets.Add(chatSocketfromAcceptcallBackfromAsyncresult);

            chatSocket.BeginReceive(chatBuffer, 0, chatBuffer.Length, SocketFlags.None, new AsyncCallback(ServerGetMessageFromClient), chatSocketfromAcceptcallBackfromAsyncresult);

            chatSocketfromAcceptcallBackfromAsyncresult.BeginAccept(new AsyncCallback(ChatAcceptCallBack), null);
        }

        private void IsClientMessageNull(string clientMessage, Socket chatSocketfromGetcallBack)
        {
            if (clientMessage == null)
            {
                return;
            }
            else
            {
                byte[] clientMessagelength = Encoding.ASCII.GetBytes(clientMessage);

                ServerSendMessageToClient(clientMessage);

                chatSocketfromGetcallBack.BeginSend(clientMessage, 0, clientMessagelength.Length, SocketFlags.None, new AsyncCallback(SendMessageCallBack), chatSocketfromGetcallBack);
            }
        }
        private void SendMessageCallBack(IAsyncResult asyncResult)
        {
            Socket sendClientmessageSocket = (Socket).asyncResult.AsyncState;

            sendClientmessageSocket.EndSend(asyncResult);
        }
    }
}
