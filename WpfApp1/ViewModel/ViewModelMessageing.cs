using DasBessereDIscord.Server.Client.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1;

namespace DasBessereDIscord.Server.Client.ViewModel
{
    public class ViewModelMessageing
    {
        MainWindow window;
        Model.Client messaging = new Model.Client();
        string Message;

        public void SetuserName(string userName)
        {
            messaging.SetUserName(userName);
        }

        public void SendMessage(string userMessage)
        {
            messaging.SetMessage(userMessage);
        }

        public void ReceiveMessage(string Message)
        {
            window.PrintMessage(Message);
        }
    }
}
