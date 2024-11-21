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

namespace WpfApp1.SubWindows
{
    /// <summary>
    /// Логика взаимодействия для _4FencesWindow.xaml
    /// </summary>
    public partial class _4FencesWindow : Window
    {
        public _4FencesWindow()
        {
            InitializeComponent();
        }

        private void Fences_ClickClose(object sender, RoutedEventArgs e)
        {
            CatalogWindow catalogwindow = new CatalogWindow();
            catalogwindow.Show();
        }
    }
}
