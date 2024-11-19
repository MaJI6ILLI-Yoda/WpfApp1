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
        private Subject subject = new Subject();
        private FaultTypes faultType = new FaultTypes();
        private Childs child = new Childs();   
        public AddEditWindow()
        {
            InitializeComponent();
            DataContext = request;
            ComboStatus.ItemsSource = LogiClikeEntities.GetContext().RequestStatus.ToList();
        }
        private void BtnSave_Click(Object sender, RoutedEventArgs e)
        {
            StringBuilder error = new StringBuilder();

            if (request.application_number == null)
                error.AppendLine("Введите номер заявки!");

            else if (!int.TryParse(request.application_number.ToString(), out int applicationNumber) || applicationNumber < 0)
                error.AppendLine("Номер заявки должен иметь положительное или отрицательное значение!");

            else if (LogiClikeEntities.GetContext().Requests.Any(row => row.application_number == request.application_number))
                error.AppendLine("Номер заявки уже существует!");

            if (request.request_date == null || request.request_date == DateTime.MinValue)
                error.AppendLine("Укажите дату!");

            if (string.IsNullOrWhiteSpace(request.problem_description))
                error.AppendLine("Укажите описание проблемы!");

            if (ComboStatus.SelectedItem != null && ComboStatus.SelectedItem is RequestStatus selectedStatus)
                request.status_id = selectedStatus.status_id;
            else error.AppendLine("Выберите статус заявки!");

            if (string.IsNullOrWhiteSpace(SubjectTextBox.Text))
                error.AppendLine("Укажите предмет!");

            if (string.IsNullOrWhiteSpace(ChildTextBox.Text))
                error.AppendLine("Укажите имя ребенка!");

            if (string.IsNullOrWhiteSpace(FaultTypeTextBox.Text))
                error.AppendLine("Укажите тип неисправности!");

            if (error.Length > 0)
            {
                MessageBox.Show(error.ToString(), "Предупреждение!", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }

            try
            {
                var context = LogiClikeEntities.GetContext();
                subject.subject_name = SubjectTextBox.Text;         
                faultType.fault_type_name = FaultTypeTextBox.Text;
                child.child_name = ChildTextBox.Text;

                context.Subject.Add(subject);             
                context.FaultTypes.Add(faultType);
                context.Childs.Add(child);
                context.SaveChanges();

                var equipmentId = subject.subject_id;              
                var faultTypeid = faultType.fault_type_id;
                var childID = child.child_id;

                request.subject_id = equipmentId;
                request.fault_type_id = faultTypeid;
                request.child_id = childID;

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

