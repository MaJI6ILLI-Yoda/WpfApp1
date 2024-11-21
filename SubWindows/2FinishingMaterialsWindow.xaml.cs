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
    /// Логика взаимодействия для _2FinishingMaterialsWindow.xaml
    /// </summary>
    public partial class _2FinishingMaterialsWindow : Window
    {
        public _2FinishingMaterialsWindow()
        {
            InitializeComponent();
        }

        private void FinishingMaterials_ClickClose(object sender, RoutedEventArgs e)
        {
            CatalogWindow catalogwindow = new CatalogWindow();
            catalogwindow.Show();
        }
    }
}
