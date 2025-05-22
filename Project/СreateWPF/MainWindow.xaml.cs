using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml.Linq;

namespace Project
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        AuthorizationDBEntities6 db;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void AddClick(object sender, RoutedEventArgs e)
        {
            JobTitle jobTitle = new JobTitle();
            jobTitle.id_JobTitle = Convert.ToInt32(tbId.Text);
            jobTitle.NameJobTitle = (tbN.Text);
            jobTitle.Seylary = Convert.ToInt32(tbS.Text);
            db.JobTitle.Add(jobTitle);
            db.SaveChanges();
            dgMedicament.ItemsSource = db.JobTitle.ToList();

        }
        private void UpdateClick(object sender, RoutedEventArgs e)
        {
            int sDid = Convert.ToInt32(tbId.Text);
            var selectDId = db.JobTitle.Where(w => w.id_JobTitle == sDid).FirstOrDefault();
            db.JobTitle.Remove(selectDId);
            db.SaveChanges();
            dgMedicament.ItemsSource = db.JobTitle.ToList();
        }
        private void DeleteClick(object sender, RoutedEventArgs e)
        {
            int sUpId = Convert.ToInt32(tbId.Text);
            var selecUptId = db.JobTitle.Where(w => w.id_JobTitle == sUpId).FirstOrDefault();
            selecUptId.id_JobTitle = Convert.ToInt32(tbId.Text);
            selecUptId.NameJobTitle = Convert.ToString(tbN.Text);
            selecUptId.Seylary = Convert.ToInt32(tbS.Text);
            db.SaveChanges();
            dgMedicament.ItemsSource = db.JobTitle.ToList();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            db = new AuthorizationDBEntities6();
            dgMedicament.ItemsSource = db.JobTitle.ToList();
        }

        private void dgMedicament_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (dgMedicament.SelectedItem is JobTitle selectedJobTitle)
            {
                tbId.Text = selectedJobTitle.id_JobTitle.ToString();
                tbN.Text = selectedJobTitle.NameJobTitle.ToString();
                tbS.Text = selectedJobTitle?.Seylary.ToString();
                // Добавь остальные поля по аналогии
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder csvContent = new StringBuilder();


            csvContent.AppendLine("id_JobTitle,NameJobTitle,Seylary");

            foreach (JobTitle job in dgMedicament.ItemsSource)
            {
                csvContent.AppendLine($"{job.id_JobTitle},{job.NameJobTitle},{job.Seylary}");
            }

            string filePath = "exported_direct.csv";
            File.WriteAllText(filePath, csvContent.ToString(), Encoding.UTF8);

            MessageBox.Show("Экспорт выполнен успешно!", "Готово", MessageBoxButton.OK, MessageBoxImage.Information);
            System.Diagnostics.Process.Start(filePath);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog openFileDialog = new Microsoft.Win32.OpenFileDialog();
            openFileDialog.Filter = "CSV files (*.csv)|*.csv|All files (*.*)|*.*";

            if (openFileDialog.ShowDialog() == true)
            {
                string[] lines = File.ReadAllLines(openFileDialog.FileName, Encoding.UTF8);

                if (lines.Length < 2)
                {
                    MessageBox.Show("Файл пустой или не содержит данных.", "Ошибка импорта", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                // Пропускаем заголовок
                for (int i = 1; i < lines.Length; i++)
                {
                    string[] fields = lines[i].Split(',');

                    if (fields.Length < 3) continue; // Пропускаем строки с недостаточным числом колонок

                    try
                    {
                        JobTitle jobTitle = new JobTitle
                        {
                            id_JobTitle = Convert.ToInt32(fields[0]),
                            NameJobTitle = fields[1],
                            Seylary = Convert.ToInt32(fields[2])
                        };

                        // Проверка, существует ли уже элемент с таким ID
                        var existing = db.JobTitle.Find(jobTitle.id_JobTitle);
                        if (existing == null)
                        {
                            db.JobTitle.Add(jobTitle);
                        }
                        else
                        {
                            // Обновить существующую запись
                            existing.NameJobTitle = jobTitle.NameJobTitle;
                            existing.Seylary = jobTitle.Seylary;
                        }
                    }
                    catch
                    {
                        // Можно логировать ошибки или выводить сообщение
                        continue;
                    }
                }

                db.SaveChanges();
                dgMedicament.ItemsSource = db.JobTitle.ToList();

                MessageBox.Show("Импорт завершён!", "Успешно", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

    }
}