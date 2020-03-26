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

namespace DasBessereDIscord.Client.ViewModel
{
    public class ViewModelMessageing 
    {
        Messaging messaging;

        public ViewModelMessageing()
        {
            messaging = new Messaging();
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
