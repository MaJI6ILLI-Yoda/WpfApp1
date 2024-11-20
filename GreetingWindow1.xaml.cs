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
    /// Логика взаимодействия для GreetingWindow1.xaml
    /// </summary>
    public partial class GreetingWindow1 : Window
    {
        public GreetingWindow1()
        {
            InitializeComponent();
        }

        private void GreetingWindow1_ClickNext(object sender, RoutedEventArgs e)
        {
            GreetingWindow2 greetingwindow2 = new GreetingWindow2();
            greetingwindow2.Show();
            this.Close();
        }
        private void GreetingWindow1_ClickClose(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
