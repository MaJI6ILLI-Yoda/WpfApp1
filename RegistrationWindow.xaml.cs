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
using System.Windows.Shapes;
using System.Xml.Linq;

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для RegistrationWindow.xaml
    /// </summary>
    public partial class RegistrationWindow : Window
    {
        private Account account = new Account();

        public RegistrationWindow()
        {
            InitializeComponent();
            DataContext = account;
        }

        private void textBoxUserNameRegistration_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            textBoxUserName.Clear();
        }

        private void textBoxPhoneRegistration_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            textBoxPhone.Clear();
        }

        private void textBoxEmailRegistration_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            textBoxEmailRegistration.Clear();
        }

        private void textBoxPasswordRegistration_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            textBoxPasswordRegistration.Clear();
        }

        private void ButtonRegistration_Click(object sender, RoutedEventArgs e)
        {
            // Строка для хранения сообщений об ошибках
            StringBuilder errorMessages = new StringBuilder();

            // Сначала присваиваем значения полям account
            account.UserName = textBoxUserName.Text;
            account.PhoneNumber = textBoxPhone.Text;
            account.EmailAdress = textBoxEmailRegistration.Text;
            account.Password = textBoxPasswordRegistration.Text;

            // Проверка имени пользователя
            if (!ValidateUserName(account.UserName))
            {
                errorMessages.AppendLine("Имя пользователя должно состоять только из букв");
            }

            if (string.IsNullOrWhiteSpace(account.UserName))
                errorMessages.AppendLine("Поле 'Имя пользователя' не может быть пустым!");

            // Проверка телефона
            if (!ValidatePhone(account.PhoneNumber))
            {
                errorMessages.AppendLine("Номер телефона должен начинаться с 7 или 8 и содержать 10 цифр");
            }

            if (string.IsNullOrWhiteSpace(account.PhoneNumber))
                errorMessages.AppendLine("Поле 'Номер телефона' не может быть пустым!");
            else if (LogiClickeEntities.GetContext().Account.Any(row => row.PhoneNumber == account.PhoneNumber))
                errorMessages.AppendLine("Данный Номер Телефона уже существует!");

            // Проверка email
            if (!ValidateEmail(account.EmailAdress))
            {
                errorMessages.AppendLine("Некорректный email");
            }

            if (string.IsNullOrWhiteSpace(account.EmailAdress))
                errorMessages.AppendLine("Поле 'Email' не может быть пустым!");
            else if (LogiClickeEntities.GetContext().Account.Any(row => row.EmailAdress == account.EmailAdress))
                errorMessages.AppendLine("Данный Email уже существует!");

            // Проверка пароля
            if (!ValidatePassword(account.Password))
            {
                errorMessages.AppendLine("Пароль должен состоять только из букв и символов");
            }

            if (string.IsNullOrWhiteSpace(account.Password))
                errorMessages.AppendLine("Поле 'Пароль' не может быть пустым!");

            // Если есть ошибки, выводим их
            if (errorMessages.Length > 0)
            {
                MessageBox.Show(errorMessages.ToString(), "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            try
            {
                var context = LogiClickeEntities.GetContext();
                account.id_role = 3; // Предполагаем, что роль всегда одна и та же

                context.Account.Add(account);
                context.SaveChanges();

                // Если все проверки пройдены, можно продолжить регистрацию
                MessageBox.Show("Регистрация успешна!", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);

                MainWindow mainWindow = new MainWindow();
                mainWindow.Show(); 
                this.Close(); 
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private bool ValidateUserName(string userName)
        {
            return Regex.IsMatch(userName, @"^[A-Za-zА-Яа-яЁё]+$");
        }

        private bool ValidatePhone(string phone)
        {
            return Regex.IsMatch(phone, @"^(8|7)\d{10}$");
        }

        private bool ValidateEmail(string email)
        {
            return Regex.IsMatch(email, @"^[A-Za-z][A-Za-z0-9_]*@[A-Za-z0-9]+.[A-Za-z0-9]+$");
        }

        private bool ValidatePassword(string password)
        {
            return Regex.IsMatch(password, @"^[A-Za-zА-Яа-яЁё0-9!@#$%^&*()_+=-]+$");
        }

        private void BtnAuthorization_Click(object sender, RoutedEventArgs e)
        {
            AuthorizationWindow authorizationWindow = new AuthorizationWindow();
            authorizationWindow.Show();
            this.Close();
        }

        private void ButtonRegistrationClickOut(object sender, RoutedEventArgs e)
        {
            AuthorizationWindow authorizationWindow = new AuthorizationWindow();
            authorizationWindow.Show();
            this.Close();
        }
    }
}
