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
    /// Логика взаимодействия для _8WallpaperWindow.xaml
    /// </summary>
    public partial class _8WallpaperWindow : Window
    {
        public _8WallpaperWindow()
        {
            InitializeComponent();
        }

        private void Wallpaper_ClickClose(object sender, RoutedEventArgs e)
        {
            CatalogWindow catalogwindow = new CatalogWindow();
            catalogwindow.Show();
        }
    }
}
