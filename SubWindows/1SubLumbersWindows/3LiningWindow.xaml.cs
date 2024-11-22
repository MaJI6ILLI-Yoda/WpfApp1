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

namespace WpfApp1.SubWindows._1SubLumbersWindows
{
    /// <summary>
    /// Логика взаимодействия для _3LiningWindow.xaml
    /// </summary>
    public partial class _3LiningWindow : Window
    {
        public _3LiningWindow()
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

        private void Board_ClickClose(object sender, RoutedEventArgs e)
        {
            _1LumbersWindow lumbersWindow = new _1LumbersWindow();
            lumbersWindow.Show();
            this.Close();
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Данные заявки обновлены");
        }
    }
}
