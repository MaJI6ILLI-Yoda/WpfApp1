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
using WpfApp1.SubWindows;

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для CatalogWindow.xaml
    /// </summary>
    public partial class CatalogWindow : Window
    {
        public CatalogWindow()
        {
            InitializeComponent();
        }

        private void CatalogIconNetoSky_Click (object sender, RoutedEventArgs e)
        {
            CatalogWindow catalogWindow = new CatalogWindow();
            catalogWindow.Show();
            this.Close();
        }

        private void CatalogIconShoppingCart_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainwindow = new MainWindow();
            mainwindow.Show();
        }

        private void CatalogIconProfile_Click(object sender, RoutedEventArgs e)
        {
            AuthorizationWindow authorizationwindow = new AuthorizationWindow();
            authorizationwindow.Show();
        }

        private void Lumbers_Click(object sender, RoutedEventArgs e)
        {
            _1LumbersWindow lumberswindow = new _1LumbersWindow();
            lumberswindow.Show();
            this.Close();
        }

        private void FinishingMaterials_Click(object sender, RoutedEventArgs e)
        {
            _2FinishingMaterialsWindow finishingmaterialswindow = new _2FinishingMaterialsWindow();
            finishingmaterialswindow.Show();
            this.Close();
        }

        private void InsulationMaterials_Click(object sender, RoutedEventArgs e)
        {
            _3InsulationMaterialsWindow insulationmaterialswindow = new _3InsulationMaterialsWindow();
            insulationmaterialswindow.Show();
            this.Close();
        }

        private void Fences_Click(object sender, RoutedEventArgs e)
        {
            _4FencesWindow fenceswindow = new _4FencesWindow();
            fenceswindow.Show();
            this.Close();
        }

        private void RoofingMaterials_Click(object sender, RoutedEventArgs e)
        {
            _5RoofingMaterialsWindow roofingmaterialswindow = new _5RoofingMaterialsWindow();
            roofingmaterialswindow.Show();
            this.Close();
        }

        private void RoadSurfaces_Click(object sender, RoutedEventArgs e)
        {
            _6RoadSurfacesWindow roadSurfaceswindow = new _6RoadSurfacesWindow();
            roadSurfaceswindow.Show();
            this.Close();
        }

        private void RolledMetal_Click(object sender, RoutedEventArgs e)
        {
            _7RolledMetalWindow rolledmetalwindow = new _7RolledMetalWindow();
            rolledmetalwindow.Show();
            this.Close();
        }

        private void Wallpaper_Click(object sender, RoutedEventArgs e)
        {
            _8WallpaperWindow wallpaperwindow = new _8WallpaperWindow();
            wallpaperwindow.Show();
            this.Close();
        }
    }
}
