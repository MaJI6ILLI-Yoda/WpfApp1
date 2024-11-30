using System;
using System.Collections.Generic;
using System.Linq;
using  System.Net;
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
using System.Data.Entity;


namespace WpfApp1
{
  public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.Loaded += (s, e) =>
            {
                var screenWidth = SystemParameters.PrimaryScreenWidth;
                var screenHeight = SystemParameters.PrimaryScreenHeight;

                this.Left = (screenWidth - this.Width) / 2;
                this.Top = (screenHeight - this.Height) / 2;
            };
            this.Loaded += MainWindow_Loaded;
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            RefreshNetoSkyDataBaseDataGrid();
            ComboStatus.ItemsSource = NetoSkyDataBaseEntities.GetContext().RequestStatus.ToList();
            Box.Text = NetoSkyDataBaseEntities.GetContext().Requests.Count(r => r.status_id == 2).ToString();
            Vis();
        }

        private void RefreshNetoSkyDataBaseDataGrid()
        {
            var context = NetoSkyDataBaseEntities.GetContext();
            var requestWithRelations = context.Requests
                .Include(r => r.Product)
                .Include(r => r.ProductTypes)
                .Include(r => r.Clients)
                .Include(r => r.Workers)
                .ToList();

            NetoSky.ItemsSource = requestWithRelations;
        }
        private void Vis()
        {
            switch (Authorization.authorizationRole)
            {
                case "Администратор":
                    MessageBox.Show("Здравствуйте, Администратор!");
                    break;
                case "Модератор":
                    MessageBox.Show("Здравствуйте, Модератор!");
                    BtnDelet.Visibility = Visibility.Collapsed;
                    break;
                case "Пользователь":
                    MessageBox.Show("Здравствуйте, Пользователь!");
                    BtnEdit_Invisible.Visibility = Visibility.Collapsed;
                    BtnDelet.Visibility = Visibility.Collapsed;
                    break;
                default:
                    return;
            }
        }
        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            var selectedRequest = (sender as Button)?.DataContext as Requests;
            if (selectedRequest != null)
            {
                RefreshWindow addEditWindow = new RefreshWindow(selectedRequest);
                if (addEditWindow.ShowDialog() == true)
                {
                    RefreshNetoSkyDataBaseDataGrid();
                }
            }
        }
        
        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            AddEditWindow addEditWindow = new AddEditWindow();
            if(addEditWindow.ShowDialog() == true) 
            {
                RefreshNetoSkyDataBaseDataGrid();
            }
        }

        private void BtnDelet_Click(object sender, RoutedEventArgs e)
        {
            var servisForRemoving = NetoSky.SelectedItems.Cast<Requests>().ToList();
            if (servisForRemoving.Any() && MessageBox.Show($"Вы точно хотите удалить следующее количество {servisForRemoving.Count()} элементов?", "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                var context = NetoSkyDataBaseEntities.GetContext();
                context.Requests.RemoveRange(servisForRemoving);
                context.SaveChanges();
                MessageBox.Show("Данные успешно удалены!");
                RefreshNetoSkyDataBaseDataGrid();
            }
        }

        private void BtnUp_Click(object sender, RoutedEventArgs e) 
        {
            RefreshNetoSkyDataBaseDataGrid();
        }

        private void BtnOut_Click(object sender, RoutedEventArgs e)
        {
            if (ComboStatus.SelectedItem is RequestStatus selectedStatus)
            {
                int selectedStatusID = selectedStatus.status_id;
                var context = NetoSkyDataBaseEntities.GetContext();
                NetoSky.ItemsSource = context.Requests
                    .Include(r => r.Product)
                    .Include(r => r.ProductTypes)
                    .Include(r => r.Clients)
                    .Include(r => r.Workers)
                    .ToList();
            }
        }

        private void SearchBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            var searchText = SearchBox.Text.ToLower();
            var context = NetoSkyDataBaseEntities.GetContext();
            try
            {
                NetoSky.ItemsSource = context.Requests
                .Include(r => r.Product)
                .Include(r => r.ProductTypes)
                .Include(r => r.Clients)
                .Include(r => r.Workers)
                .Where(r =>
                r.application_number.ToString().Contains(searchText) ||
                r.Product.product_name.ToLower().Contains(searchText) ||
                r.ProductTypes.product_type_name.ToLower().Contains(searchText) ||
                r.product_description.ToLower().Contains(searchText) ||
                r.Clients.client_name.ToLower().Contains(searchText) ||
                r.RequestStatus.status_name.ToLower().Contains(searchText) ||
                r.Workers.worker_name.ToLower().Contains(searchText))
                .ToList();
            }

            catch (System.Data.Entity.Core.EntityCommandExecutionException ex)
            {
                // Логирование или отладка исключения
                Console.WriteLine(ex.InnerException?.Message);
            }
        }
        private void BtnAuthorization_Click(object sender, RoutedEventArgs e)
        {
            AuthorizationWindow authorizationWindow = new AuthorizationWindow();
            authorizationWindow.Show();
            this.Close();
        }
    }
}
