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
        private int _captchaAnswer;
        private int _failedAttempts = 0;
        private const int MaxAttempts = 3;
        private DateTime _lockEndTime;

        public Register()
        {
            InitializeComponent();
            GenerateCaptcha();
        }

        private void GenerateCaptcha()
        {
            Random rand = new Random();
            int a = rand.Next(-1000, 1000);
            int b = rand.Next(-1000, 1000);
            _captchaAnswer = a + b;
            CaptchaTextBlock.Text = $"Сколько будет {a} + {b}?";
        }

        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            if (DateTime.Now < _lockEndTime)
            {
                StatusTextBlock.Text = $"Слишком много попыток. Подождите ещё {(int)(_lockEndTime - DateTime.Now).TotalSeconds} секунд.";
                return;
            }

            string username = UsernameTextBox.Text.Trim();
            string password = PasswordBox.Password;
            string confirmPassword = ConfirmPasswordBox.Password;

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                ShowError("Поля не должны быть пустыми.");
                return;
            }

            if (password.Length < 4)
            {
                ShowError("Пароль слишком короткий. Минимум 4 символа.");
                return;
            }

            if (password != confirmPassword)
            {
                ShowError("Пароли не совпадают.");
                return;
            }

            if (!int.TryParse(CaptchaAnswerTextBox.Text, out int userAnswer) || userAnswer != _captchaAnswer)
            {
                ShowError("Неверная капча.");
                return;
            }

            bool success = UserStore.Register(username, password);
            if (!success)
            {
                ShowError("Пользователь уже существует.");
                return;
            }

            StatusTextBlock.Foreground = Brushes.Green;
            StatusTextBlock.Text = "Регистрация успешна!";
            MainWindow main = new MainWindow();
            main.Show();
            this.Close();
        }

        private void ShowError(string message)
        {
            _failedAttempts++;
            StatusTextBlock.Foreground = Brushes.Red;
            StatusTextBlock.Text = message;
            if (_failedAttempts >= MaxAttempts)
            {
                _lockEndTime = DateTime.Now.AddSeconds(30);
                StatusTextBlock.Text += "\nВвод временно заблокирован.";
            }
        }
    }


}
