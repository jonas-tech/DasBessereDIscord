using DasBessereDIscord.Client.Model;
using DasBessereDIscord.Client.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.Proxy;

namespace WpfApp1.Model
{
    class Messaging
    {
        private string userName;
        private string userMessage;
        private string fullMessage;
        IService server;
        private Client client;

        public Messaging()
        {
            client = new Client();
        }

        #region LogIn
        public void LogInAndSaveUserName(string userName)
        {
            this.userName = userName;
            server.ClientLogIntoServer(true);
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
        }

        public void SendFullMessageToInterfaces()
        {
            client.SendMessageInternal(fullMessage);
        }
        #endregion

        #region ReceiveMessageFromServer
        public string serverMessage;
        public void PrintMessageInChatRoom()
        {
            this.serverMessage = client.ReceiveMessageIntern();
        }
        #endregion

        #region LogOut
        public void LogOutFromServer()
        {
            server.ClientLogOutOfServer(false);
            this.userName = null;
        }
        #endregion LogOut

    }
}
