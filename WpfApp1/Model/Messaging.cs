using DasBessereDIscord.Client.Model;
using DasBessereDIscord.Client.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Model
{
    public class Messaging
    {
        string userName;
        string userMessage;
        string fullMessage;
        int Clientnumber;
        //IService server;
        public Client client;
        public ViewModelMessageing viewModelMessageing;
        public Messaging()
        {
            client = new Client() { messaging = this };
        }
        #region LogIn
        public void LogInAndSaveUserName(string userName)
        {
            this.userName = userName;
            //server.ClientLogIntoServer(true);
        }
        public void SaveClientNumber(int Clientnumber)
        {
            this.Clientnumber = Clientnumber;
        }
        #endregion
        #region SenduserMessage
        public void GetUserMessage(string userMessage)
        {
            this.userMessage = userMessage;
            CreateFullMessage();
        }

        public void CreateFullMessage()
        {
            this.fullMessage = DateTime.Now.ToString() + " von " + userName + " : " + userMessage;
            SendFullMessageToInterfaces();
        }

        public void SendFullMessageToInterfaces()
        {
            client.SendMessageInternal(fullMessage);
            //server.ServerGetMessageFromClient(fullMessage);
        }
        #endregion
        #region ReceiveMessageFromServer
        public string serverMessage;
        public void PrintMessageInChatRoom()
        {
            this.serverMessage = client.ReceiveMessageIntern();
            viewModelMessageing.PrintServerMessageInChatroom(serverMessage);
            //server.ServerSendMessageToClient(serverMessage);
        }
        #endregion
        #region LogOut
        public void LogOutFromServer()
        {
            //server.ClientLogOutOfServer(false);
            this.userName = null;
        }
        #endregion LogOutCo
    }
}
