using DasBessereDIscord.Client.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1;
using WpfApp1.Model;
using System.Windows;

namespace DasBessereDIscord.Client.ViewModel
{
    public class ViewModelMessageing 
    {
        public Messaging messaging;
        public MainWindow window;
        public ViewModelMessageing()
        {
            messaging = new Messaging { viewModelMessageing = this };
        }
        #region LogIn
        public void LogIn(string userName)
        {
            messaging.LogInAndSaveUserName(userName);
        }
        #endregion
        #region SendeMessage
        public void SendMessage(string userMessage)
        {
            messaging.GetUserMessage(userMessage);
        }
        #endregion
        #region ReceiveMessage
        string Message = "";
        public void PrintServerMessageInChatroom(string Message)
        {
            this.Message = messaging.serverMessage;
            window.PrintMessage();
        }

        public string ReturnServerMessageInViewModel()
        {
            return Message;
        }
        #endregion
        #region LogOut
        public void LogOut()
        {
            messaging.LogOutFromServer();
        }

        #endregion
    }
}
