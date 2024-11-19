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
            this.Loaded += MainWindow_Loaded;
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            RefreshTechnoServiceDataGrid();
            ComboStatus.ItemsSource = LogiClickeEntities.GetContext().RequestStatus.ToList();
            Box.Text = LogiClickeEntities.GetContext().Requests.Count(r => r.status_id == 2).ToString();
            Vis();
        }

        private void RefreshTechnoServiceDataGrid()
        {
            var context = LogiClickeEntities.GetContext();
            var requestWithRelations = context.Requests
                .Include(r => r.Subject)
                .Include(r => r.FaultTypes)
                .Include(r => r.Childs)
                .Include(r => r.Teachers)
                .ToList();

            TechnoService.ItemsSource = requestWithRelations;
        }
        private void Vis()
        {
            switch (Authorization.authorizationRole)
            {
                case "Администратор":
                    break;
                case "Модератор":
                    BtnAdd.Visibility = Visibility.Collapsed;
                    BtnDelet.Visibility = Visibility.Collapsed;
                    break;
                case "Пользователь":
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
                    RefreshTechnoServiceDataGrid();
                }
            }
        }
        
        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            AddEditWindow addEditWindow = new AddEditWindow();
            if(addEditWindow.ShowDialog() == true) 
            {
                RefreshTechnoServiceDataGrid();
            }
        }

        private void BtnDelet_Click(object sender, RoutedEventArgs e)
        {
            var servisForRemoving = TechnoService.SelectedItems.Cast<Requests>().ToList();
            if (servisForRemoving.Any() && MessageBox.Show($"Вы точно хотите удалить следующее количество {servisForRemoving.Count()} элементов?", "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                var context = LogiClickeEntities.GetContext();
                context.Requests.RemoveRange(servisForRemoving);
                context.SaveChanges();
                MessageBox.Show("Данные успешно удалены!");
                RefreshTechnoServiceDataGrid();
            }
        }

        private void BtnUp_Click(object sender, RoutedEventArgs e) 
        {
            RefreshTechnoServiceDataGrid();
        }

        private void BtnOut_Click(object sender, RoutedEventArgs e)
        {
            if (ComboStatus.SelectedItem is RequestStatus selectedStatus)
            {
                int selectedStatusID = selectedStatus.status_id;
                var context = LogiClickeEntities.GetContext();
                TechnoService.ItemsSource = context.Requests
                    .Include(r => r.Subject)
                    .Include(r => r.FaultTypes)
                    .Include(r => r.Childs)
                    .Include(r => r.Teachers)
                    .ToList();
            }
        }

        private void SearchBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            var searchText = SearchBox.Text.ToLower();
            var context = LogiClickeEntities.GetContext();
            try
            {
                TechnoService.ItemsSource = context.Requests
                .Include(r => r.Subject)
                .Include(r => r.FaultTypes)
                .Include(r => r.Childs)
                .Include(r => r.Teachers)
                .Where(r =>
                r.application_number.ToString().Contains(searchText) ||
                r.Subject.subject_name.ToLower().Contains(searchText) ||
                r.FaultTypes.fault_type_name.ToLower().Contains(searchText) ||
                r.problem_description.ToLower().Contains(searchText) ||
                r.Childs.child_name.ToLower().Contains(searchText) ||
                r.RequestStatus.status_name.ToLower().Contains(searchText) ||
                r.Teachers.teacher_name.ToLower().Contains(searchText))
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
