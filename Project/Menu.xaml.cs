using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
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
    /// Логика взаимодействия для Menu.xaml
    /// </summary>
    public partial class Menu : Window
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            StranWindow stran = new StranWindow();
            stran.Show();
        }

        private void LoadQr(object sender, RoutedEventArgs e)
        {
            QrCodeGenerate qr = new QrCodeGenerate();
            qr.Show();
        }

        private void InstallImage(object sender, RoutedEventArgs e)
        {
            Window1 window1 = new Window1();
            window1.Show();
        }

        private void ShowImage(object sender, RoutedEventArgs e)
        {
            ClientWindow clientWindow = new ClientWindow();
            clientWindow.Show();
        }

        private void LINQ(object sender, RoutedEventArgs e)
        {
            BasketWindow basket = new BasketWindow();
            basket.Show();
        }

        private void CRUD(object sender, RoutedEventArgs e)
        {
            string path = @"C:\Users\roman\Downloads\Telegram Desktop\WpfApp3 (2)\WpfApp3\WpfApp3\bin\Debug\net8.0-windows\WpfApp3.exe";
            if (File.Exists(path))
            {
                // Запускаем процесс с аргументом
                Process.Start(path);
            }
            else
            {
                MessageBox.Show("Файл WpfApp3.exe не найден!");
            }
        }

        private void Migrations(object sender, RoutedEventArgs e)
        {
            string path = @"C:\Users\roman\source\repos\WpfApp6\WpfApp6\bin\Debug\WpfApp6.exe";
            if (File.Exists(path))
            {
                // Запускаем процесс с аргументом
                Process.Start(path);
            }
            else
            {
                MessageBox.Show("Файл WpfApp3.exe не найден!");
            }
        }
    }
}
