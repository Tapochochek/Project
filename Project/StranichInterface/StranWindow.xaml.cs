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
    /// Логика взаимодействия для StranWindow.xaml
    /// </summary>
    public partial class StranWindow : Window
    {
        public StranWindow()
        {
            InitializeComponent();
            MainFrame.Navigate(new Page2());
            Manager.MainFrame = MainFrame;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.GoBack();
        }
        private void MainFrame_ContentRendered(object sender, EventArgs e)
        {
            if (MainFrame.CanGoBack)
            {
                BackButton.Visibility = Visibility.Visible;
            }
            else
            {
                BackButton.Visibility = Visibility.Hidden;
            }
        }
    }
}
