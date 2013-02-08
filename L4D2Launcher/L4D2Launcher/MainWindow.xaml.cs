using L4D2Launcher.Helper;
using L4D2Launcher.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace L4D2Launcher
{
    public partial class MainWindow : Window
    {
        Parameters parameter;

        public MainWindow()
        {
            InitializeComponent();
            Bind();
        }


        private void Bind()
        {
            parameter = new Parameters();
            parameter.Console = true;
            parameter.Insecure = true;
            parameter.Steam = true;
            parameter.Lan = true;
            parameter.LobbyOnly = true;
            parameter.Difficulty = 1;
            parameter.MaxPlayers = 8;
            parameter.Physcannon = true;
            parameter.Cheats = true;

            DataContext = parameter;
            MapList.ItemsSource = DataHelper.LoadMaps();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            CommandHelper.Execute(parameter);
        }

    }
}
