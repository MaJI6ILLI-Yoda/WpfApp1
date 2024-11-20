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
    /// Логика взаимодействия для GreetingWindow2.xaml
    /// </summary>
    public partial class GreetingWindow2 : Window
    {
        public GreetingWindow2()
        {
            InitializeComponent();
        }
        private void GreetingWindow2_ClickNext(object sender, RoutedEventArgs e)
        {
            GreetingWindow3 greetingwindow3 = new GreetingWindow3();
            greetingwindow3.Show();
            this.Close();
        }
        private void GreetingWindow2_ClickClose(object sender, RoutedEventArgs e)
        {
            GreetingWindow1 greetingwindow1 = new GreetingWindow1();
            greetingwindow1.Show();
            this.Close();
        }
    }
}
