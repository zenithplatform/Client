using CefSharp.Wpf;
using MahApps.Metro.Controls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Shapes;
using Zenith.Client.Shared;
using Zenith.Client.Shared.Interfaces;
using Zenith.Client.ViewModel;
using Zenith.Client.ViewModel.Mock;
using Zenith.Client.Views;

namespace Zenith.Client
{
    public partial class Shell : MetroWindow
    {
        NavbarViewModel _navbarModel = null;

        public Shell()
        {
            InitializeComponent();
            this.Loaded += Shell_Loaded;
            DataContext = this;

            _navbarModel = new NavbarViewModel();
            _navbarModel.PropertyChanged += _navbarModel_PropertyChanged;
        }

        private void _navbarModel_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if(e.PropertyName == "CurrentTab")
            {
                NavbarTab tab = _navbarModel.CurrentTab;
            }
        }

        private void CreateNavbarTabs()
        {
            CreateSearchNavbar();
            CreateMapNavbarTab();
        }

        private void CreateSearchNavbar()
        {
            //SearchView searchView = new SearchView();
            //SearchViewModel searchModel = new SearchViewModel(new SearchServiceProxy());
            //searchView.DataContext = searchModel;
            SearchTileViewModel tileViewModel = new SearchTileViewModel(this);
            SearchTileView tiles = new SearchTileView();

            tileViewModel.AddTile("Search by name", "Search objects by exact identifier or name", SearchType.ObjectSearch);
            tileViewModel.AddTile("Search by approximate name", "Search objects by approximate identifier or name", SearchType.ObjectSearch);
            tileViewModel.AddTile("Search by position", "Search objects by its position on the sky", SearchType.ObjectSearch);
            tileViewModel.AddTile("Search objects around position", "Search objects around specified position on the sky", SearchType.ObjectSearch);
            tileViewModel.AddTile("Search catalogs", "Search catalogs by name", SearchType.CatalogSearch);

            tiles.DataContext = tileViewModel;

            _navbarModel.AddTab("Search", "", "appbar_magnify", "Pick one of the search modes", tiles);
            _navbarModel.AddTab("Data files", "", "appbar_page_text", "View and manipulate data files", new FilesStartPage());
            
        }

        private void CreateMapNavbarTab()
        {
            string curDir = Directory.GetCurrentDirectory().Replace('\\', '/');
            string targetFile = String.Format("file:///{0}/Views/WorldMapView/MapResources/html/WorldMap.html", curDir);

            WorldMapView mapView = new WorldMapView();
            BrowserViewModel BrowserModel = new BrowserViewModel();

            BrowserModel.Address = targetFile;
            BrowserModel.WebBrowser = new ChromiumWebBrowser();
            mapView.DataContext = BrowserModel;

            _navbarModel.AddTab("Observatories", "", "appbar_location_round", "View observatories around the world", mapView);
        }

        private void Shell_Loaded(object sender, RoutedEventArgs e)
        {
            CreateNavbarTabs();
        }

        public void NavigateTo(UserControl newView)
        {
            NavbarTab currentTab = _navbarModel.CurrentTab;
            currentTab.TabContent = newView;
        }

        public void NavigateTo(UserControl newView, string newTitle)
        {
            NavbarTab currentTab = _navbarModel.CurrentTab;
            currentTab.ContentTitle = newTitle;
            currentTab.TabContent = newView;
        }

        public NavbarViewModel NavbarModel
        {
            get
            {
                return _navbarModel;
            }
        }
    }
}
