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

namespace Project
{
    /// <summary>
    /// Логика взаимодействия для Authorization.xaml
    /// </summary>
    public partial class Authorization : Window
    {
        AuthorizationDBEntities6 db;
        int counter = 0;
        public Authorization()
        {
            InitializeComponent();
        }

        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            RegisterWindow registerWindow = new RegisterWindow();
            registerWindow.Show();
            this.Close();
        }
        private void Apply(object sender, RoutedEventArgs e)
        {
            db = new AuthorizationDBEntities6();
            string login = LoginBox.Text.Trim();
            string password = passwordBox.Text.Trim();

            try
            {
                var user = db.Users.Where(d => d.login == login).FirstOrDefault();
                if (user != null)
                {
                    if (VerifyPassword(password, user.password))
                    {
                        Menu menu = new Menu();
                        menu.Show();
                        this.Close();
                    }
                    else
                    {
                        counter++;
                        MessageBox.Show("Неправильный логин или пароль");
                        if(counter == 3)
                        {
                            CaptchaWindow captchaWindow = new CaptchaWindow();
                            captchaWindow.Show();
                            this.Close();
                        }
                        
                    }
                }
                else
                {
                    MessageBox.Show("Пользователь не найден");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public static bool VerifyPassword(string password, string hashedPassword)
        {
            return BCrypt.Net.BCrypt.Verify(password, hashedPassword);
        }
    }
}
 