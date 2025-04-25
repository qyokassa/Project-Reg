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
    /// Логика взаимодействия для CaptchaWindow.xaml
    /// </summary>
    public partial class CaptchaWindow : Window
    {
        private string correctAnswer;
        private readonly LoginWindow loginWindow;

        public CaptchaWindow(LoginWindow loginWindow)
        {
            InitializeComponent();
            this.loginWindow = loginWindow;
            GenerateHardCaptcha();
        }

        private void GenerateHardCaptcha()
        {
            // Список русских слов для анаграммы
            string[] words = { "Высокопревосходительство", "безопасность", "микроскоп", "вермишель", "самоуничтожение", "защита", "микротик", "энергообеспечение", "аэрозоль" };
            Random rand = new Random();
            string word = words[rand.Next(words.Length)];
            correctAnswer = word;

            // Перемешиваем буквы
            char[] scrambled = word.ToCharArray();
            for (int i = 0; i < scrambled.Length; i++)
            {
                int j = rand.Next(scrambled.Length);
                (scrambled[i], scrambled[j]) = (scrambled[j], scrambled[i]);
            }

            CaptchaTextBlock.Text = $"Разгадайте слово: {new string(scrambled)}";
        }

        private void CheckCaptchaButton_Click(object sender, RoutedEventArgs e)
        {
            if (CaptchaAnswerTextBox.Text.Trim().ToLower() == correctAnswer)
            {
                MessageBox.Show("Капча решена правильно. Теперь можно  войти.");
                loginWindow.AllowRetryAfterCaptcha();
                this.Close();
            }
            else
            {
                MessageBox.Show("Неправильный ответ. Возвращаем на вход.");
                loginWindow.Show();
                this.Close();
            }
        }
    }
}
