using Microsoft.AspNet.SignalR.Client.Hubs;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Net;
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

namespace GitNotifierClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        ObservableCollection<string> listSource = new ObservableCollection<string>();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Grid_Loaded_1(object sender, RoutedEventArgs e)
        {
            Start();
        }

        private void Start()
        {
            listNotifications.ItemsSource = listSource;
            Task.Factory.StartNew(() => Connect());
        }

        private void Connect()
        {
            var connection = new HubConnection("http://localhost/GitNotifier/");
            connection.Credentials = CredentialCache.DefaultNetworkCredentials;
            IHubProxy chat = connection.CreateHubProxy("ClientNotificationHub");
            chat.On<string>("Send", MessageReceived);
            connection.Start().Wait();
        }


        private void MessageReceived(string message)
        {
            try
            {
                listSource.Add(message);
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Received= " + message);
                Debug.WriteLine(ex.ToString());
            }

        }



    }
}
