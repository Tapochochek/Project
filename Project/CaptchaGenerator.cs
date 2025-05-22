using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Media;
using System.Windows;

public class CaptchaGenerator
{
    private static Random rnd = new Random();
    private const string chars = "ABCDEFGHJKLMNPQRSTUVWXYZ23456789";
    Bitmap bmp;

    public string CaptchaText { get; private set; }

    public Bitmap GenerateCaptchaImage(int width = 200, int height = 80)
    {
        int textLength = rnd.Next(4, 8);
        CaptchaText = GenerateRandomText(textLength);

        bmp = new Bitmap(width, height);
        using (Graphics g = Graphics.FromImage(bmp))
        {
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.Clear(GetRandomLightColor());

            // Добавление шумов
            DrawNoise(g, width, height);

            // Добавление линий
            DrawLines(g, width, height);

            int x = 10;
            for (int i = 0; i < CaptchaText.Length; i++)
            {
                string letter = CaptchaText[i].ToString();
                int fontSize = rnd.Next(24, 36);
                Font font = new Font(System.Drawing.FontFamily.GenericSansSerif, fontSize, System.Drawing.FontStyle.Bold);

                System.Drawing.Brush brush = new SolidBrush(GetRandomDarkColor());

                float angle = rnd.Next(-30, 30);
                g.TranslateTransform(x, height / 2);
                g.RotateTransform(angle);
                g.DrawString(letter, font, brush, 0, -fontSize / 2);
                g.ResetTransform();

                x += fontSize - 5;
            }
        }

        return bmp;
    }

    private string GenerateRandomText(int length)
    {
        char[] buffer = new char[length];
        for (int i = 0; i < length; i++)
            buffer[i] = chars[rnd.Next(chars.Length)];
        return new string(buffer);
    }

    private void DrawNoise(Graphics g, int width, int height)
    {
        for (int i = 0; i < 100; i++)
        {
            int x = rnd.Next(width);
            int y = rnd.Next(height);
            bmp.SetPixel(x, y, GetRandomDarkColor());
        }
    }

    private void DrawLines(Graphics g, int width, int height)
    {
        for (int i = 0; i < 5; i++)
        {
            System.Drawing.Pen pen = new System.Drawing.Pen(GetRandomDarkColor(), 1);
            System.Drawing.Point p1 = new System.Drawing.Point(rnd.Next(width), rnd.Next(height));
            System.Drawing.Point p2 = new System.Drawing.Point(rnd.Next(width), rnd.Next(height));
            g.DrawLine(pen, p1, p2);
        }
    }

    private System.Drawing.Color GetRandomLightColor() =>
        System.Drawing.Color.FromArgb(rnd.Next(200, 255), rnd.Next(200, 255), rnd.Next(200, 255));

    private System.Drawing.Color GetRandomDarkColor() =>
        System.Drawing.Color.FromArgb(rnd.Next(0, 100), rnd.Next(0, 100), rnd.Next(0, 100));
}
