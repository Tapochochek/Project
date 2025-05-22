using QRCoder;
using QRCoder.Xaml;
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
    /// Логика взаимодействия для QrCodeGenerate.xaml
    /// </summary>
    public partial class QrCodeGenerate : Window
    {
        public QrCodeGenerate()
        {
            InitializeComponent();
        }

        private void qrImage_SourceUpdated(object sender, DataTransferEventArgs e)
        {

        }

        public void Button_Click(object sender, RoutedEventArgs e)
        {
            QRCodeGenerator qrCodeGenerator = new QRCodeGenerator();
            QRCodeData qRCodeData = qrCodeGenerator.CreateQrCode(InputBox.Text, QRCodeGenerator.ECCLevel.H);
            XamlQRCode qRCode = new XamlQRCode(qRCodeData);
            DrawingImage qrCodeAsXml = qRCode.GetGraphic(20);
            qrImage.Source = qrCodeAsXml;
        }

        public void Button_Click_1(object sender, RoutedEventArgs e)
        {
            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(InputBox.Text, QRCodeGenerator.ECCLevel.Q);

            XamlQRCode qrCode = new XamlQRCode(qrCodeData);

            DrawingImage qrCodeImage = qrCode.GetGraphic(
                pixelsPerModule: 20,
                darkColorHex: "#FF0000",
                lightColorHex: "#FFFFFF"
            );

            qrImage.Source = qrCodeImage;
        }
    }
}
