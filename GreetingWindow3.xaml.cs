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
    /// Логика взаимодействия для GreetingWindow3.xaml
    /// </summary>
    public partial class GreetingWindow3 : Window
    {
        public GreetingWindow3()
        {
            InitializeComponent();
        }
        private void GreetingWindow3_ClickNext(object sender, RoutedEventArgs e)
        {
            GreetingWindow4 greetingwindow4 = new GreetingWindow4();
            greetingwindow4.Show();
            this.Close();
        }
        private void GreetingWindow3_ClickClose(object sender, RoutedEventArgs e)
        {
            GreetingWindow2 greetingwindow2 = new GreetingWindow2();
            greetingwindow2.Show();
            this.Close();
        }
    }
}
