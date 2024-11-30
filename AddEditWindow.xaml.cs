using System;
using System.Collections.Generic;
using System.Configuration;
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

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для AddEditWindow.xaml
    /// </summary>
    public partial class AddEditWindow : Window
    {
        private Requests request = new Requests();
        private Product product = new Product();
        private ProductTypes productType = new ProductTypes();
        private Clients client = new Clients();   
        public AddEditWindow()
        {
            InitializeComponent();
            this.Loaded += (s, e) =>
            {
                var screenWidth = SystemParameters.PrimaryScreenWidth;
                var screenHeight = SystemParameters.PrimaryScreenHeight;

                this.Left = (screenWidth - this.Width) / 2;
                this.Top = (screenHeight - this.Height) / 2;
            };
            DataContext = request;
            ComboWorker.ItemsSource = NetoSkyDataBaseEntities.GetContext().Workers.ToList();
        }
        private void BtnSave_Click(Object sender, RoutedEventArgs e)
        {
            StringBuilder error = new StringBuilder();

            if (request.application_number == null)
                error.AppendLine("Введите номер товара!");

            else if (!int.TryParse(request.application_number.ToString(), out int applicationNumber) || applicationNumber < 0)
                error.AppendLine("Номер товара должен иметь положительное или отрицательное значение!");

            else if (NetoSkyDataBaseEntities.GetContext().Requests.Any(row => row.application_number == request.application_number))
                error.AppendLine("Номер товара уже существует!");

            if (request.request_date == null || request.request_date == DateTime.MinValue)
                error.AppendLine("Укажите дату!");

            if (string.IsNullOrWhiteSpace(request.product_description))
                error.AppendLine("Укажите характиристики!");

            if (ComboWorker.SelectedItem != null && ComboWorker.SelectedItem is Workers selectedWorker)
                request.worker_id = selectedWorker.worker_id;
            else error.AppendLine("Выберите сотрудника прикрепленного к заказу!");

            if (string.IsNullOrWhiteSpace(ProductTextBox.Text))
                error.AppendLine("Укажите товар!");

            if (string.IsNullOrWhiteSpace(ClientTextBox.Text))
                error.AppendLine("Укажите имя клиента!");

            if (string.IsNullOrWhiteSpace(ProductTypeTextBox.Text))
                error.AppendLine("Укажите тип товара!");

            if (error.Length > 0)
            {
                MessageBox.Show(error.ToString(), "Предупреждение!", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }

            try
            {
                var context = NetoSkyDataBaseEntities.GetContext();
                product.product_name = ProductTextBox.Text;         
                productType.product_type_name = ProductTypeTextBox.Text;
                client.client_name = ClientTextBox.Text;

                context.Product.Add(product);             
                context.ProductTypes.Add(productType);
                context.Clients.Add(client);

                var productId = product.product_id;              
                var productTypeid = productType.product_type_id;
                var clientID = client.client_id;

                request.product_id = productId;
                request.product_type_id = productTypeid;
                request.client_id = clientID;
                request.status_id = 1;

                context.Requests.Add(request);
                context.SaveChanges();

                MessageBox.Show("Информация сохранена!");
                this.Close();

            }
             
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
        private void ButtonClickOut(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }
    }
}

