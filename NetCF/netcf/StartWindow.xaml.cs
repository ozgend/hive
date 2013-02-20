using denolk.netcf.Helper;
using denolk.netcf.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace denolk.netcf
{
    public partial class StartWindow : Window
    {
        ObservableCollection<NetworkConfigModel> listNICSource = new ObservableCollection<NetworkConfigModel>();
        ObservableCollection<NetworkConfigModel> listProfileSource = new ObservableCollection<NetworkConfigModel>();

        public StartWindow()
        {
            InitializeComponent();
        }

        private void DockPanel_Loaded_1(object sender, RoutedEventArgs e)
        {
            Bind();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Save();
        }


        private void listProfiles_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ApplyProfile(sender);
        }

        private void Bind()
        {
            listNICnames.ItemsSource = listNICSource;
            listProfiles.ItemsSource = listProfileSource;

            var settings = NICHelper.ReadNICSettings();
            foreach (var key in settings.Keys)
            {
                listNICSource.Add(settings[key]);
            }
            listNICnames.SelectedIndex = 0;

            var profiles = DataHelper.LoadProfiles();
            listProfiles.IsEnabled = profiles.Count > 0;
            foreach (var item in profiles)
            {
                listProfileSource.Add(item);
            }

            
        }

        private void Save()
        {
            var model = gridNICSettings.DataContext;
            NICHelper.SaveNICSettings(model as NetworkConfigModel);
            MessageBox.Show("Configruation saved", "netcf", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void ApplyProfile(object sender)
        {
            var applyModel = ((sender as ListBox).SelectedItem as NetworkConfigModel);
            var nicModel = (gridNICSettings.DataContext as NetworkConfigModel);

            applyModel.InterfaceName = nicModel.InterfaceName;
            applyModel.NetworkName = nicModel.NetworkName;

            gridNICSettings.DataContext = applyModel;
        }

        private void listNICnames_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            gridNICSettings.DataContext = ((sender as ListBox).SelectedItem as NetworkConfigModel);
        }


    }
}
