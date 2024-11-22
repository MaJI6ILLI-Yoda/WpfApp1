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
using WpfApp1.SubWindows._1SubLumbersWindows;

namespace WpfApp1.SubWindows
{
    /// <summary>
    /// Логика взаимодействия для _1LumbersWindow.xaml
    /// </summary>
    public partial class _1LumbersWindow : Window
    {
        public _1LumbersWindow()
        {
            InitializeComponent();
            this.Loaded += (s, e) =>
            {
                var screenWidth = SystemParameters.PrimaryScreenWidth;
                var screenHeight = SystemParameters.PrimaryScreenHeight;

                this.Left = (screenWidth - this.Width) / 2;
                this.Top = (screenHeight - this.Height) / 2;
            };
        }

        private void Lumbers_ClickClose (object sender, RoutedEventArgs e)
        {
            CatalogWindow catalogwindow = new CatalogWindow();
            catalogwindow.Show();
        }

        private void Board_Click(object sender, RoutedEventArgs e)
        {
            _1BoardWindow boardWindow = new _1BoardWindow();
            boardWindow.Show();
        }

        private void Balk_Click(object sender, RoutedEventArgs e)
        {
            _2BalkWindow balkWindow = new _2BalkWindow();
            balkWindow.Show();
        }

        private void Lining_Click(object sender, RoutedEventArgs e)
        {
            _3LiningWindow liningWindow = new _3LiningWindow();
            liningWindow.Show();
        }

        private void BlockHouse_Click(object sender, RoutedEventArgs e)
        {
            _4BlockHouseWindow blockHouseWindow = new _4BlockHouseWindow();
            blockHouseWindow.Show();
        }
    }
}
