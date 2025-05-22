using System;
using System.Drawing;
using System.IO;
using System.Windows;
using System.Windows.Media.Imaging;

namespace Project
{
    public partial class CaptchaWindow : Window
    {
        private CaptchaGenerator generator;

        public bool IsPassed { get; private set; } = false;

        public CaptchaWindow()
        {
            InitializeComponent();
            generator = new CaptchaGenerator();
            var bmp = generator.GenerateCaptchaImage();
            captchaImage.Source = BitmapToImageSource(bmp);
        }

        private BitmapImage BitmapToImageSource(Bitmap bitmap)
        {
            using (var ms = new MemoryStream())
            {
                bitmap.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                ms.Position = 0;
                BitmapImage img = new BitmapImage();
                img.BeginInit();
                img.StreamSource = ms;
                img.CacheOption = BitmapCacheOption.OnLoad;
                img.EndInit();
                img.Freeze();
                return img;
            }
        }

        private void ValidateCaptcha(object sender, RoutedEventArgs e)
        {
            if (tbInput.Text.Trim().ToUpper() == generator.CaptchaText.ToUpper())
            {
                IsPassed = true;
                Authorization authorization = new Authorization();
                authorization.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Неправильный ввод. Попробуйте снова.");
                generator = new CaptchaGenerator();
                var newCaptcha = generator.GenerateCaptchaImage();
                captchaImage.Source = BitmapToImageSource(newCaptcha);

                // Очистка поля ввода
                tbInput.Clear();
            }
        }
    }
}
