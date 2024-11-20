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
    /// Логика взаимодействия для GreetingWindow4.xaml
    /// </summary>
    public partial class GreetingWindow4 : Window
    {
        public GreetingWindow4()
        {
            InitializeComponent();
        }
        private void GreetingWindow4_ClickNext(object sender, RoutedEventArgs e)
        {
            GreetingWindow5 greetingwindow5 = new GreetingWindow5();
            greetingwindow5.Show();
            this.Close();
        }
        private void GreetingWindow4_ClickClose(object sender, RoutedEventArgs e)
        {
            GreetingWindow3 greetingwindow3 = new GreetingWindow3();
            greetingwindow3.Show();
            this.Close();
        }
    }
}
