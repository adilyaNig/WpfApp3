using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Логика взаимодействия для RegistrationPage.xaml
    /// </summary>
    public partial class RegistrationPage : Page
    {
        public RegistrationPage()
        {
            InitializeComponent();
            Gendercmb.ItemsSource=DBConnection.schoolEntities.Gender.ToList();
            Gendercmb.DisplayMemberPath="Name";

        }

        private void LoginBtn_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(FirstNameTb.Text) ||
              string.IsNullOrWhiteSpace(LastNameTb.Text) ||
              string.IsNullOrWhiteSpace(LastNameTb.Text) ||
              string.IsNullOrWhiteSpace(LoginTb.Text) ||
              string.IsNullOrWhiteSpace(PasswordTb.Text) ||
              Gendercmb.SelectedIndex == 0 ||
              BirthDateDp.SelectedDate == null)
            {
                MessageBox.Show("Заполните все поля!!!");
            }
            else if (DBConnection.schoolEntities.User.ToList().Any(x => x.Login == LoginTb.Text))
                // Any возвращает user когда найет 1 = tru
            {
                MessageBox.Show("Логин занят!!!");

            }
            else if (PasswordTb.Text.Length < 6
                || !Regex.IsMatch(PasswordTb.Text, "[A-Z]") //через регулярные выражения
                || !Regex.IsMatch(PasswordTb.Text, "[0-9]")
                || !Regex.IsMatch(PasswordTb.Text, "[!!@#$%^.]"))
            {
                MessageBox.Show("Минимум 6 символов/");
            }

            else if (!EmailTb.Text.EndsWith("@mail.com") || !EmailTb.Text.EndsWith("@gmail.com"))
            {
                MessageBox.Show("неверная почта!!!");
            }
            else
            {
                var user = DBConnection.schoolEntities.User.Add(new User()
                {
                    Login = LoginTb.Text,
                    Password = PasswordTb.Text,
                    RoleID = 2
                });
                DBConnection.schoolEntities.Client.Add(new Client()
                {
                    FirstName = FirstNameTb.Text,
                    LastName = LastNameTb.Text,
                    Patronymic = PatronomicTb.Text,
                    RegistrationDate = DateTime.Now,
                    Birthday = BirthDateDp.SelectedDate,
                    Email = EmailTb.Text,
                    Phone = PhoneTb.Text,
                    UserID = user.ID,
                    GenderID = (Gendercmb.SelectedItem as Gender).ID
                });
                DBConnection.schoolEntities.SaveChanges();
            }
        }
        private void RegistrationTb_Click(object sender, RoutedEventArgs e)
        {
          
        }
    }
}
