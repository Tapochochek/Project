using Microsoft.Win32;
using System;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Media.Imaging;

namespace Project
{
    public partial class Window1 : Window
    {
        public string ImageName; // Сохраняем имя выбранного изображения
        AuthorizationDBEntities6 db;

        // Путь к папке для хранения изображений
        private readonly string projectImagesPath = Path.Combine(Directory.GetCurrentDirectory(), "Image");

        public Window1()
        {
            InitializeComponent();
            Loaded += Window_Loaded;

            // Создаём папку Image, если её нет
            if (!Directory.Exists(projectImagesPath))
            {
                Directory.CreateDirectory(projectImagesPath);
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            db = new AuthorizationDBEntities6(); // Инициализация подключения к БД
        }

        // Кнопка ЗАГРУЗИТЬ изображение
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var openFile = new OpenFileDialog
            {
                Title = "Выберите изображение",
                Filter = "Изображения (*.jpg;*.jpeg;*.png;*.bmp)|*.jpg;*.jpeg;*.png;*.bmp|Все файлы (*.*)|*.*",
                Multiselect = false
            };

            if (openFile.ShowDialog() == true)
            {
                try
                {
                    string selectedFilePath = openFile.FileName;
                    string fileName = Path.GetFileName(selectedFilePath);
                    ImageName = fileName;
                    string destinationPath = Path.Combine(projectImagesPath, fileName);

                    // Копируем изображение в папку
                    File.Copy(selectedFilePath, destinationPath, overwrite: true);

                    // Отображаем изображение
                    image.Source = new BitmapImage(new Uri(destinationPath));
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        // Кнопка СОХРАНИТЬ имя изображения в БД
        private void Button_Click1(object sender, RoutedEventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(ImageName))
                {
                    MessageBox.Show("Сначала загрузите изображение!");
                    return;
                }

                var imageEntry = new collect
                {
                    img = ImageName // Сохраняем имя файла, а не имя контрола
                };

                db.collect.Add(imageEntry);
                db.SaveChanges();

                MessageBox.Show("Имя изображения успешно сохранено в базу данных!");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при сохранении в базу данных: {ex.Message}");
            }
        }
    }
}
