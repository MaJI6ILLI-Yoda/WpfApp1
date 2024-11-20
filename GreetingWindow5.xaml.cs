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
    /// <summary>
    /// Логика взаимодействия для GreetingWindow5.xaml
    /// </summary>
    public partial class GreetingWindow5 : Window
    {
        public GreetingWindow5()
        {
            InitializeComponent();
        }

        private void GreetingWindow5_ClickNext(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }
        private void GreetingWindow5_ClickClose(object sender, RoutedEventArgs e)
        {
            GreetingWindow4 greetingwindow4 = new GreetingWindow4();
            greetingwindow4.Show();
            this.Close();
        }
    }
}
