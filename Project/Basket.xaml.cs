using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Project
{
    public partial class BasketWindow : Window
    {
        AuthorizationDBEntities6 db;

        public BasketWindow()
        {
            InitializeComponent();
            Loaded += Window_Loaded;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            db = new AuthorizationDBEntities6();
            LoadComboBoxes();
            LoadDataGrid();
        }

        private void LoadComboBoxes()
        {
            cbClient.ItemsSource = db.Client.ToList();
            cbMedicament.ItemsSource = db.Medicament.ToList();
            cbWorker.ItemsSource = db.Workers.ToList();
            cbUser.ItemsSource = db.Users.ToList();
        }

        private void LoadDataGrid()
        {
            dgBasket.ItemsSource = db.Basket
                .Include("Client")
                .Include("Medicament")
                .Include("Workers")
                .Include("Users")
                .ToList();
        }

        private void AddClick(object sender, RoutedEventArgs e)
        {
            try
            {
                if (cbClient.SelectedItem == null || cbMedicament.SelectedItem == null ||
                    cbWorker.SelectedItem == null || cbUser.SelectedItem == null ||
                    string.IsNullOrWhiteSpace(tbCount.Text))
                {
                    MessageBox.Show("Заполните все поля!");
                    return;
                }

                var basket = new Basket
                {
                    ficClient = ((Client)cbClient.SelectedItem).ficClient,
                    id_Medicament = ((Medicament)cbMedicament.SelectedItem).id_Medicament,
                    id_Workers = ((Workers)cbWorker.SelectedItem).id_Workers,
                    Id = ((Users)cbUser.SelectedItem).Id,
                    countMedicament = Convert.ToInt32(tbCount.Text)
                };

                db.Basket.Add(basket);
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
            if (dgBasket.SelectedItem == null) return;

            try
            {
                var selectedBasket = (Basket)dgBasket.SelectedItem;
                var basket = db.Basket.Find(selectedBasket.id_Basket);

                if (basket != null)
                {
                    basket.ficClient = ((Client)cbClient.SelectedItem).ficClient;
                    basket.id_Medicament = ((Medicament)cbMedicament.SelectedItem).id_Medicament;
                    basket.id_Workers = ((Workers)cbWorker.SelectedItem).id_Workers;
                    basket.Id = ((Users)cbUser.SelectedItem).Id;
                    basket.countMedicament = Convert.ToInt32(tbCount.Text);

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
            if (dgBasket.SelectedItem == null) return;

            try
            {
                var selectedBasket = (Basket)dgBasket.SelectedItem;
                var basket = db.Basket.Find(selectedBasket.id_Basket);

                if (basket != null)
                {
                    db.Basket.Remove(basket);
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
            cbClient.SelectedItem = null;
            cbMedicament.SelectedItem = null;
            cbWorker.SelectedItem = null;
            cbUser.SelectedItem = null;
            tbCount.Text = "";
            dgBasket.SelectedItem = null;
        }

        private void dgBasket_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dgBasket.SelectedItem is Basket selected)
            {
                cbClient.SelectedItem = db.Client.FirstOrDefault(c => c.ficClient == selected.ficClient);
                cbMedicament.SelectedItem = db.Medicament.FirstOrDefault(m => m.id_Medicament == selected.id_Medicament);
                cbWorker.SelectedItem = db.Workers.FirstOrDefault(w => w.id_Workers == selected.id_Workers);
                cbUser.SelectedItem = db.Users.FirstOrDefault(u => u.Id == selected.Id);
                tbCount.Text = selected.countMedicament.ToString();
            }
        }

        private void ListViewMenu_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Count == 0 || !((ListViewItem)e.AddedItems[0]).IsSelected)
                return;


            if (GridMain == null)
            {
                MessageBox.Show("Ошибка: GridMain не найден!");
                return;
            }

            // Очищаем текущее содержимое
            GridMain.Children.Clear();

            switch (((ListViewItem)e.AddedItems[0]).Name)
            {
                case "ItemHome":
                    GridMain.Children.Add(new UserControlHome());
                    break;

                case "ItemBasket":
                    GridMain.Children.Add(new Grid { Children = { BasketContent } });
                    break;

                case "ItemTickets":
                    GridMain.Children.Add(new UserControlCreate());
                    break;

                case "ItemMessages":
                    GridMain.Children.Add(new Grid { Children = { BasketContent } });
                    break;
            }
        }
    }
}