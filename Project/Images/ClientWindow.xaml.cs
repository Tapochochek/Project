using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Media.Imaging;

namespace Project
{
    public partial class ClientWindow : Window
    {
        private AuthorizationDBEntities6 db;
        private readonly string projectImagesPath = Path.Combine(Directory.GetCurrentDirectory(), "Image");

        public ClientWindow()
        {
            InitializeComponent();
            db = new AuthorizationDBEntities6();
            LoadImagesFromDatabase();
        }

        private void LoadImagesFromDatabase()
        {
            try
            {
                var images = db.collect.ToList();


                var imageItems = images.Select(i => new ImageItem
                {
                    FileName = i.img,
                    ImageSource = LoadBitmapImage(Path.Combine(projectImagesPath, i.img))
                }).ToList();

                dgImages.ItemsSource = imageItems;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки изображений: {ex.Message}");
            }
        }

        private BitmapImage LoadBitmapImage(string path)
        {
            if (!File.Exists(path)) return null;

            var bitmap = new BitmapImage();
            bitmap.BeginInit();
            bitmap.UriSource = new Uri(path, UriKind.Absolute);
            bitmap.CacheOption = BitmapCacheOption.OnLoad;
            bitmap.EndInit();
            bitmap.Freeze();
            return bitmap;
        }
    }

    public class ImageItem
    {
        public string FileName { get; set; }
        public BitmapImage ImageSource { get; set; }
    }
}
