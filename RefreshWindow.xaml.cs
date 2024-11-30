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

namespace WpfApp1
{
    public partial class RefreshWindow : Window
    {
        private Requests _currentRequest;
        public RefreshWindow(Requests request)
        {
            InitializeComponent();
            this.Loaded += (s, e) =>
            {
                var screenWidth = SystemParameters.PrimaryScreenWidth;
                var screenHeight = SystemParameters.PrimaryScreenHeight;

                this.Left = (screenWidth - this.Width) / 2;
                this.Top = (screenHeight - this.Height) / 2;
            };
            _currentRequest = request;

            StatusComboBox.ItemsSource = NetoSkyDataBaseEntities.GetContext().RequestStatus.ToList();
            WorkerComboBox.ItemsSource = NetoSkyDataBaseEntities.GetContext().Workers.ToList();
            ProductTypeComboBox.ItemsSource = NetoSkyDataBaseEntities.GetContext().ProductTypes.ToList();
            ClientComboBox.ItemsSource = NetoSkyDataBaseEntities.GetContext().Clients.ToList();
            DescriptionTextBox.Text = request.product_description;
            StatusComboBox.SelectedItem = request.RequestStatus;
            WorkerComboBox.SelectedItem = request.Workers;
            ProductTypeComboBox.SelectedItem = request.ProductTypes;
            ClientComboBox.SelectedItem = request.Clients;
        }

        private void UpdateButtonClick(object sender, RoutedEventArgs e)
        {
           
            var context = NetoSkyDataBaseEntities.GetContext();

            _currentRequest.product_description = DescriptionTextBox.Text;
            _currentRequest.status_id = ((RequestStatus)StatusComboBox.SelectedItem).status_id;
            _currentRequest.worker_id = ((Workers)WorkerComboBox.SelectedItem).worker_id;
            _currentRequest.product_type_id = ((ProductTypes)ProductTypeComboBox.SelectedItem).product_type_id;
            _currentRequest.client_id = ((Clients)ClientComboBox.SelectedItem).client_id;

            context.SaveChanges();
            MessageBox.Show("Данные товара обновлены");
            this.Close();
        }

        private void ButtonClickOut(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
