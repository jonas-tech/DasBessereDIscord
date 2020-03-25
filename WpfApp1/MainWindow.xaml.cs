using DasBessereDIscord.Client.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ViewModelMessageing viewModel;
        public MainWindow()
        {
            InitializeComponent();
            
        }


        public void PrintMessage(string Message)
        {
            ChatroomTextBlock.Text += "\n" + Message;
        }

        private void SendMessageButton_Click(object sender, RoutedEventArgs e)
        {
            string userMessage;
            //string message;
            userMessage = SendMessageTextBox.Text;
            SendMessageTextBox.Text = "";
        }

        private void LogInButton_Click(object sender, RoutedEventArgs e)
        {
            viewModel.SetuserName(UserNameTextBox.Text);
            LogINScreen.Visibility = Visibility.Hidden;
            Chatroom.Visibility = Visibility.Visible;
        }
    }
}
