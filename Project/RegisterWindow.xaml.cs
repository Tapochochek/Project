using System;
using System.Collections.Generic;
using System.IO.Packaging;
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
using BCrypt.Net;
using BCrypt;



namespace Project
{
    /// <summary>
    /// Логика взаимодействия для RegisterWindow.xaml
    /// </summary>
    public partial class RegisterWindow : Window
    {       
        AuthorizationDBEntities6 db;

        public RegisterWindow()
        {
            InitializeComponent();
        }

        private void OkButtonReg_Click(object sender, RoutedEventArgs e)
        {
            db = new AuthorizationDBEntities6();

            string login = LoginBoxReg.Text.Trim();
            string password = passwordBoxReg.Text.Trim();

            if (string.IsNullOrWhiteSpace(login) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Введите логин и пароль!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            try
            {
                // Проверка, есть ли такой пользователь
                var existingUser = db.Users.FirstOrDefault(u => u.login == login);
                if (existingUser != null)
                {
                    MessageBox.Show("Пользователь с таким логином уже существует!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                // Хеширование пароля
                string hashedPassword = HashPassword(password);

                // Создание нового пользователя
                Users newUser = new Users
                {
                    login = login,
                    password = hashedPassword,
                    email = null
                };

                // Добавление в базу
                db.Users.Add(newUser);
                db.SaveChanges();

                MessageBox.Show("Регистрация успешна!", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);

                // Переход на окно авторизации
                Authorization authWindow = new Authorization();
                authWindow.Show();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка: " + ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }

        public static string HashPassword(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password);
        }
    }
}
