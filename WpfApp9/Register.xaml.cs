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
using System.Windows.Shapes;

namespace WpfApp9
{
    /// <summary>
    /// Логика взаимодействия для Register.xaml
    /// </summary>
    public partial class Register : Window
    {
        
        
            public Register()
            {
                InitializeComponent();
            }

            private void RegisterButton_Click(object sender, RoutedEventArgs e)
            {
                string username = UsernameTextBox.Text.Trim();
                string password = PasswordBox.Password;
                string confirmPassword = ConfirmPasswordBox.Password;

                if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
                {
                    StatusTextBlock.Text = "Все поля должны быть заполнены.";
                    return;
                }

                if (password != confirmPassword)
                {
                    StatusTextBlock.Text = "Пароли не совпадают.";
                    return;
                }

               
            }
        }
    }



