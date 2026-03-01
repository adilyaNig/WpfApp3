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
using WpfApp3.Connection;

namespace WpfApp3.Pages
{
    /// <summary>
    /// Логика взаимодействия для AvtorizationPage.xaml
    /// </summary>
    public partial class AvtorizationPage : Page
    {
        public static User authorizedUser;
        public AvtorizationPage()
        {
            InitializeComponent();
        }

       

        private void LoginBtn_Click(object sender, RoutedEventArgs e)
        {
            authorizedUser = DBConnection.schoolEntities.User.ToList().Find
                (x => x.Login == LoginTb.Text && x.Password   
            == PasswordTb.Text); //Find возвращает одну строку 
            if (authorizedUser != null)
            {
                NavigationService.Navigate(new ServiceListPage());
            }
            else
            { MessageBox.Show("неверный логин или пароль");
              }
        }
        private void RegistrationTb_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new RegistrationPage());
        }
    }
}
