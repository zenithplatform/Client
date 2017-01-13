using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Zenith.Client.ApplicationServices.Search;
using Zenith.Client.Shared;
using Zenith.Client.Shared.Commands;
using Zenith.Client.Shared.Interfaces;
using Zenith.Client.Shared.ViewsModels;
using Zenith.SearchModule.Views;

namespace Zenith.SearchModule.ViewModel
{
    public class SearchTileViewModel:INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private SearchType _currentSearchType = SearchType.ObjectSearch;
        private ParameterizedRelayCommand<TileClickCommandParameters> _tileClickCommand;
        IShellCoordinator _shellViewCoordinator = null;
        ObservableCollection<SearchTileElement> _tiles = null;

        public SearchTileViewModel(IShellCoordinator shellViewCoordinator)
            :this()
        {
            this._shellViewCoordinator = shellViewCoordinator;
        }

        public SearchTileViewModel()
        {
            this._tiles = new ObservableCollection<SearchTileElement>();
        }

        public void AddTile(string title, string text, SearchType searchType)
        {
            SearchTileElement element = new SearchTileElement();
            element.Title = title;
            element.Text = text;
            element.SearchType = searchType;
            element.SearchContext = "";

            this._tiles.Add(element);

            NotifyPropertyChanged(this, new PropertyChangedEventArgs("Tiles"));
        }

        public SearchType SearchType
        {
            get { return _currentSearchType; }
            set
            {
                _currentSearchType = value;
                NotifyPropertyChanged(this, new PropertyChangedEventArgs("SearchType"));
            }
        }

        public ICommand TileClickCommand
        {
            get
            {
                if (_tileClickCommand == null)
                    _tileClickCommand = new ParameterizedRelayCommand<TileClickCommandParameters>(OnTileClick);

                return _tileClickCommand;
            }
        }

        public ObservableCollection<SearchTileElement> Tiles
        {
            get { return this._tiles; }
        }

        public void OnTileClick(TileClickCommandParameters parameters)
        {
            SearchType type = parameters.SearchType;

            //SearchView searchView = new SearchView();
            SearchStartPage startPage = new SearchStartPage();
            SearchViewModel searchModel = new SearchViewModel(new SearchServiceProxy(), type);
            //searchView.DataContext = searchModel;
            startPage.DataContext = searchModel;

            string newTitle = "";

            if (type == SearchType.ObjectSearch)
                newTitle = "Search objects by identifier or name";
            else
                newTitle = "Search catalogs by name";

            //_shellViewCoordinator.NavigateTo(searchView, newTitle);
            //_shellViewCoordinator.NavigateTo(startPage, newTitle);
        }

        protected void NotifyPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, e);
        }
    }

    public class SearchTileElement:TileElement
    {
        public SearchType SearchType { get; set; }
        //TODO : Replace this with more generic property like Enum
        public string SearchContext { get; set; }
    }

    public class TileClickCommandParameters : CommandParameters
    {
        public SearchType SearchType { get; set; }
        //TODO : Replace this with more generic property like Enum
        public string SearchContext { get; set; }
    }
}
