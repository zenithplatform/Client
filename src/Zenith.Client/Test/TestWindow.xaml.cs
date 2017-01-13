using Zenith.Client.ViewModel.Mock;
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
using Zenith.Client.ViewModel;
using Zenith.Core.Models;
using System.Collections.ObjectModel;
using Zenith.Client.Views;

namespace Zenith.Client.Test
{
    /// <summary>
    /// Interaction logic for TestWindow.xaml
    /// </summary>
    public partial class TestWindow : Window
    {
        SearchCategoryViewModel _categoryViewModel = null;
        SearchOptionsPaneViewModel _paneViewModel = null;
        //SearchBarViewModel _searchBar = null;

        public TestWindow()
        {
            InitializeComponent();

            _paneViewModel = new SearchOptionsPaneViewModel();
            
            _categoryViewModel = new SearchCategoryViewModel();

            ObjectSearchOptions objSearchCategory = new ObjectSearchOptions();
            objSearchCategory.DataContext = new ObjectCategoryViewModel() { ConeSearchOptions = new ConeObjectSearch() };
            //double actualWidth = objSearchCategory.ActualWidth;

            _categoryViewModel.Categories.Add(new SearchCategory() { Title = "Objects", CurrentView = objSearchCategory });
            _categoryViewModel.Categories.Add(new SearchCategory() { Title = "Catalogs", CurrentView = objSearchCategory });
            _categoryViewModel.SelectedCategory = _categoryViewModel.Categories[0];

            _paneViewModel.CategoriesContainer = _categoryViewModel;
            //SearchOptions options = new SearchOptions();
            //options.DataContext = new SearchOptionsViewModel();

            //_categoryViewModel.Categories.Add(new SearchCategory() { Title = "Objects", CurrentView = options });
            //_categoryViewModel.Categories.Add(new SearchCategory() { Title = "Catalogs", CurrentView = options});

            //_searchBar = new SearchBarViewModel(SearchType.ObjectSearch);
            //_searchBar.IsSegmented = true;
            //_searchBar.SearchOptions = new SearchOptionsViewModel();

            this.DataContext = this;
            //CatalogSearchResult result = MockSearchService.SearchCatalogs();
            //CatalogsResultViewModel catalogsModel = new CatalogsResultViewModel(result, null);
            //this.DataContext = catalogsModel;
        }

        public SearchOptionsPaneViewModel SearchPane
        {
            get { return _paneViewModel; }
            set { _paneViewModel = value; }
        }

        //public SearchCategoryViewModel SearchCategories
        //{
        //    get { return _categoryViewModel; }
        //    set { _categoryViewModel = value; }
        //}

        //public SearchBarViewModel SearchBar
        //{
        //    get { return _searchBar; }
        //    set { _searchBar = value; }
        //}
    }
}
