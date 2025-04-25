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
    /// Логика взаимодействия для LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {

        
        private int failedAttempts = 0;
        private bool captchaPassed = false;

        public LoginWindow()
        {
            InitializeComponent();
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            string username = UsernameTextBox.Text.Trim();
            string password = PasswordBox.Password;

            if (UserStore.Login(username, password))
            {
                MessageBox.Show("Вход выполнен успешно!");
                MainWindow main = new MainWindow();
                main.Show();
                this.Close();
            }
            else
            {
                failedAttempts++;
                StatusTextBlock.Text = $"Ошибка входа. Попытка: {failedAttempts}";

                if (failedAttempts >= 3 && !captchaPassed)
                {
                    CaptchaWindow captcha = new CaptchaWindow(this);
                    captcha.Show();
                    this.Hide();
                }
            }
        }

        public void AllowRetryAfterCaptcha()
        {
            captchaPassed = true;
            this.Show();
        }
    }


}

