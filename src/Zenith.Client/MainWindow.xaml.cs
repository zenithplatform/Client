using Zenith.Client.ViewModel;
using Zenith.Client.ViewModel.Mock;
using Zenith.Client.Views;
using CefSharp.Wpf;
using MahApps.Metro.Controls;
using System;
using System.Collections.Generic;
using System.IO;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Zenith.Client
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        public BrowserViewModel BrowserModel { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
            BrowserModel = new BrowserViewModel();
            this.Loaded += MainWindow_Loaded;
        }

        private void LoadMap()
        {
            string curDir = Directory.GetCurrentDirectory().Replace('\\', '/');
            string targetFile = String.Format("file:///{0}/Views/WorldMapView/MapResources/html/WorldMap.html", curDir);

            WorldMapView mapView = new WorldMapView();

            BrowserModel.Address = targetFile;
            BrowserModel.WebBrowser = new ChromiumWebBrowser();
            mapView.DataContext = BrowserModel;

            //this.MainWindowContent.Content = mapView;
        }

        private void LoadSearchResults()
        {
            //SearchResultsView view = new SearchResultsView();
            //view.ObservationDataDetails.DataContext = new MockDataSource().GetData();
            //this.MainWindowContent.Content = view;
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            LoadSearchResults();
            //this.SearchResultsView.ObservationDataDetails.DataContext = new MockDataSource().GetData();
        }
    }
}
