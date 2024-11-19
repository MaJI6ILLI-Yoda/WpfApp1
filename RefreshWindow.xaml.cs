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
            _currentRequest = request;

            StatusComboBox.ItemsSource = LogiClikeEntities.GetContext().RequestStatus.ToList();
            TeacherComboBox.ItemsSource = LogiClikeEntities.GetContext().Teachers.ToList();
            FaultTypeComboBox.ItemsSource = LogiClikeEntities.GetContext().FaultTypes.ToList();
            ChildComboBox.ItemsSource = LogiClikeEntities.GetContext().Childs.ToList();
            DescriptionTextBox.Text = request.problem_description;
            StatusComboBox.SelectedItem = request.RequestStatus;
            TeacherComboBox.SelectedItem = request.Teachers;
            FaultTypeComboBox.SelectedItem = request.FaultTypes;
            ChildComboBox.SelectedItem = request.Childs;
        }

        private void UpdateButtonClick(object sender, RoutedEventArgs e)
        {
           
            var context = LogiClikeEntities.GetContext();

            _currentRequest.problem_description = DescriptionTextBox.Text;
            _currentRequest.status_id = ((RequestStatus)StatusComboBox.SelectedItem).status_id;
            _currentRequest.teacher_id = ((Teachers)TeacherComboBox.SelectedItem).teacher_id;
            _currentRequest.fault_type_id = ((FaultTypes)FaultTypeComboBox.SelectedItem).fault_type_id;
            _currentRequest.child_id = ((Childs)ChildComboBox.SelectedItem).child_id;

            context.SaveChanges();
            MessageBox.Show("Данные заявки обновлены");
            this.Close();
        }

        private void ButtonClickOut(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
