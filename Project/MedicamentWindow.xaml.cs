using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Project
{
    public partial class MedicamentWindow : Window
    {
        AuthorizationDBEntities6 db;

        public MedicamentWindow()
        {
            InitializeComponent();
            Loaded += Window_Loaded;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            db = new AuthorizationDBEntities6();
            LoadDataGrid();
        }

        private void LoadDataGrid()
        {
            dgMedicament.ItemsSource = db.Medicament.ToList();
        }

        private void AddClick(object sender, RoutedEventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(tbName.Text) || string.IsNullOrWhiteSpace(tbPrice.Text))
                {
                    MessageBox.Show("Заполните обязательные поля!");
                    return;
                }

                var medicament = new Medicament
                {
                    nameMedicament = tbName.Text,
                    medicamentOnRecept = cbOnRecept.IsChecked ?? false,
                    healthEffect = tbEffect.Text,
                    priceMedicament = Convert.ToInt32(tbPrice.Text)
                };

                db.Medicament.Add(medicament);
                db.SaveChanges();
                LoadDataGrid();
                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка добавления: {ex.Message}");
            }
        }

        private void UpdateClick(object sender, RoutedEventArgs e)
        {
            if (dgMedicament.SelectedItem == null)
            {
                MessageBox.Show("Выберите лекарство для редактирования!");
                return;
            }

            try
            {
                int id = ((Medicament)dgMedicament.SelectedItem).id_Medicament;
                var medicament = db.Medicament.FirstOrDefault(m => m.id_Medicament == id);

                if (medicament != null)
                {
                    medicament.nameMedicament = tbName.Text;
                    medicament.medicamentOnRecept = cbOnRecept.IsChecked ?? false;
                    medicament.healthEffect = tbEffect.Text;
                    medicament.priceMedicament = Convert.ToInt32(tbPrice.Text);

                    db.SaveChanges();
                    LoadDataGrid();
                    ClearFields();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка обновления: {ex.Message}");
            }
        }

        private void DeleteClick(object sender, RoutedEventArgs e)
        {
            if (dgMedicament.SelectedItem == null)
            {
                MessageBox.Show("Выберите лекарство для удаления!");
                return;
            }

            try
            {
                int id = ((Medicament)dgMedicament.SelectedItem).id_Medicament;
                var medicament = db.Medicament.FirstOrDefault(m => m.id_Medicament == id);

                if (medicament != null)
                {
                    db.Medicament.Remove(medicament);
                    db.SaveChanges();
                    LoadDataGrid();
                    ClearFields();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка удаления: {ex.Message}");
            }
        }

        private void ClearClick(object sender, RoutedEventArgs e)
        {
            ClearFields();
        }

        private void ClearFields()
        {
            tbName.Text = "";
            cbOnRecept.IsChecked = false;
            tbEffect.Text = "";
            tbPrice.Text = "";
            dgMedicament.SelectedItem = null;
        }

        private void dgMedicament_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (dgMedicament.SelectedItem is Medicament selected)
            {
                tbName.Text = selected.nameMedicament;
                cbOnRecept.IsChecked = selected.medicamentOnRecept;
                tbEffect.Text = selected.healthEffect;
                tbPrice.Text = selected.priceMedicament.ToString();
            }
        }
    }
}