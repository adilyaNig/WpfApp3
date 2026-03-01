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
using WpfApp3.Pages.Components;

namespace WpfApp3.Pages
{ 
    /// <summary>
    /// Логика взаимодействия для ServiceListPage.xaml
    /// </summary>
    public partial class ServiceListPage : Page
    {
        public ServiceListPage()
        {
            InitializeComponent();
            if (AvtorizationPage.authorizedUser.RoleID != 1)
            {
                AddBtn.Visibility = Visibility.Collapsed; 
                EntriesBtn.Visibility = Visibility.Collapsed; 
            }
            foreach (var service in Connection.DBConnection.schoolEntities.Service.ToList())
            {
                ServiceWp.Children.Add(new ServiceUserControl(service));
            }
        }

        private void UpdateListServices()
        {
            var services = Connection.DBConnection.schoolEntities.Service.ToList();
            if(SortCb.SelectedIndex > 0)
            {
                if (SortCb.SelectedIndex == 1)
                {
                    services = services.OrderBy(x=>x.Cost).ToList();
                }
                else if (SortCb.SelectedIndex == 2)
                {
                    services = services.OrderByDescending(x => x.Cost).ToList();
                }
            }
            ServiceWp.Children.Clear();
            foreach (var service in services)
            {
                ServiceWp.Children.Add(new ServiceUserControl(service));
            }
        }
        private void SortCb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateListServices();
        }
    }
}
