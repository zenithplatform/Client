using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Threading;
using Zenith.Client.Shared;
using Zenith.Client.Shared.Commands;
using Zenith.Client.Shared.ViewModel;
using Zenith.Client.ViewModel.Search.Helpers;
using Zenith.Client.Views;
using Zenith.Core.Models;
using Zenith.Core.Models.Interfaces;

namespace Zenith.Client.ViewModel
{
    public class SearchBarViewModel:INotifyPropertyChanged
    {
        private ParameterizedRelayCommand<SettingsCommandParameters> _settingsCommand;
        private ParameterizedRelayCommand<SearchCommandParameters> _searchCommand;
        private SimpleRelayCommand _segmentDeleteCommand;
        private SearchBoxPulsatingState _pulsatingState;

        public event PropertyChangedEventHandler PropertyChanged;

        bool _isSearchActive = false;
        string _searchText = "";
        bool _isEnabled = true;
        string _watermarkText = "";
        bool _isSegmented = false;

        private ObservableCollection<TextBoxSegment> _segments = null;
        //private SearchOptionsViewModel _searchOptions = null;
        ISearchRequest _searchRequest = null;
        public SearchType _searchType = SearchType.ObjectSearch;

        public event EventHandler SearchStarted;
        public event EventHandler SearchCancelled;

        public SearchBarViewModel(SearchType searchType)
        {
            _searchType = searchType;

            if (_searchType == SearchType.ObjectSearch)
            {
                _searchRequest = new ObjectSearchRequest();
                _watermarkText = "Enter text to search for objects...";
            }
            else
            {
                _searchRequest = new CatalogSearchRequest();
                _watermarkText = "Enter text to search for catalogs...";
            }

            _segments = new ObservableCollection<TextBoxSegment>();
            //_searchOptions = new SearchOptionsViewModel();
            //_searchOptions.PropertyChanged += _searchOptions_PropertyChanged;
        }

        private void _searchOptions_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if(e.PropertyName == "AddedItem")
            {
                //SearchOptionsItem addedItem = _searchOptions.AddedItem;
                //AddSearchOptionSegment(addedItem);
            }
            else if (e.PropertyName == "UpdatedItem")
            {
                //SearchOptionsItem addedItem = _searchOptions.UpdatedItem;
                //UpdateSearchOptionSegment(addedItem);
            }
            else if(e.PropertyName == "ItemState")
            {
                SearchOptionsItem item = sender as SearchOptionsItem;

                if (item.CurrentSegment == null)
                    return;

                OnSegmentDelete(item.CurrentSegment); 
            }
        }

        private void AddSearchOptionSegment(SearchOptionsItem searchOption)
        {
            TextBoxSegment segment = SearchHelper.Create(searchOption);
            searchOption.CanModify = true;
            this._segments.Add(segment);
            NotifyPropertyChanged(this, new PropertyChangedEventArgs("Segments"));
        }

        private void UpdateSearchOptionSegment(SearchOptionsItem searchOption)
        {
            searchOption.CurrentView.UpdateSegmentValues();
            NotifyPropertyChanged(this, new PropertyChangedEventArgs("Segments"));
        }

        public string SearchText
        {
            get { return _searchText; }
            set
            {
                _searchText = value;
                NotifyPropertyChanged(this, new PropertyChangedEventArgs("SearchText"));
            }
        }

        public ISearchRequest GetRequest()
        {
            if(_searchType == SearchType.ObjectSearch)
            {
                _searchRequest = new ObjectSearchRequest();
            }
            else
            {
                _searchRequest = new CatalogSearchRequest();
            }

            _searchRequest.SearchTerm = _searchText;

            return _searchRequest;
        }

        public ICommand SettingsCommand
        {
            get
            {
                if (_settingsCommand == null)
                    _settingsCommand = new ParameterizedRelayCommand<SettingsCommandParameters>(OnSettingsClick);

                return _settingsCommand;
            }
        }

        public void OnSettingsClick(SettingsCommandParameters parameters)
        {

        }

        public ICommand SearchCommand
        {
            get
            {
                if (_searchCommand == null)
                    _searchCommand = new ParameterizedRelayCommand<SearchCommandParameters>(OnSearch);

                return _searchCommand;
            }
        }

        public bool IsSearchActive
        {
            get { return _isSearchActive; }
            set
            {
                _isSearchActive = value;
                NotifyPropertyChanged(this, new PropertyChangedEventArgs("IsSearchActive"));
            }
        }

        public bool IsEnabled
        {
            get { return _isEnabled; }
            set
            {
                _isEnabled = value;
                NotifyPropertyChanged(this, new PropertyChangedEventArgs("IsEnabled"));
            }
        }

        public SearchType SearchType
        {
            get { return _searchType; }
            set
            {
                _searchType = value;
                NotifyPropertyChanged(this, new PropertyChangedEventArgs("SearchType"));

                if(_searchType == SearchType.ObjectSearch)
                {
                    WatermarkText = "Enter text to search for objects...";
                }
                else
                {
                    WatermarkText = "Enter text to search for catalogs...";
                }
            }
        }

        public string WatermarkText
        {
            get
            {
                return _watermarkText;
            }
            set
            {
                _watermarkText = value;
                NotifyPropertyChanged(this, new PropertyChangedEventArgs("WatermarkText"));
            }
        }

        public void OnSearch(SearchCommandParameters parameters)
        {
            if(_isSearchActive)
            {
                if (SearchCancelled != null)
                    SearchCancelled(this, EventArgs.Empty);

                _isSearchActive = false;
            }
            else
            {
                if (SearchStarted != null)
                    SearchStarted(this, EventArgs.Empty);

                _isSearchActive = true;
            }
        }

        public ObservableCollection<TextBoxSegment> Segments
        {
            get { return _segments; }
            set
            {
                _segments = value;
                NotifyPropertyChanged(this, new PropertyChangedEventArgs("Segments"));
            }
        }

        //public SearchOptionsViewModel SearchOptions
        //{
        //    get { return _searchOptions; }
        //    set { _searchOptions = value; }
        //}

        public ICommand SegmentDeleteCommand
        {
            get
            {
                if (_segmentDeleteCommand == null)
                    _segmentDeleteCommand = new SimpleRelayCommand(OnSegmentDelete);

                return _segmentDeleteCommand;
            }
        }

        public void OnSegmentDelete(object arg)
        {
            TextBoxSegment segment = arg as TextBoxSegment;
            SearchOptionsItem searchOptionsItem = segment.Origin;

            if (searchOptionsItem != null)
            {
                searchOptionsItem.CanAdd = true;
                searchOptionsItem.CanModify = false;
                searchOptionsItem.CurrentView.DestroySegmentValues();
            }

            this.Segments.Remove(segment);
        }

        public bool IsSegmented
        {
            get { return _isSegmented; }
            set
            {
                _isSegmented = value;
                NotifyPropertyChanged(this, new PropertyChangedEventArgs("IsSegmented"));
            }
        }

        public SearchBoxPulsatingState PulsatingState
        {
            get { return _pulsatingState; }
            set
            {
                _pulsatingState = value;
                NotifyPropertyChanged(this, new PropertyChangedEventArgs("PulsatingState"));
            }
        }

        protected void NotifyPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, e);
        }
    }

    public class TextBoxSegment : Segment
    {
        public SearchOptionsItem Origin { get; set; }
    }

    public class SettingsCommandParameters : CommandParameters
    {

    }

    public class SearchCommandParameters : CommandParameters
    {

    }

    public enum SearchBoxPulsatingState
    {
        Pulsating,
        NonPulsating
    }
}
