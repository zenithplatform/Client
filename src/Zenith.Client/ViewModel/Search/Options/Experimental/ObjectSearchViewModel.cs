using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Zenith.Client.Shared.Commands;
using Zenith.Client.Shared.ViewModel;
using Zenith.Client.ViewModel.Search.Helpers;
using Zenith.Core.Models;
using Zenith.Core.Models.Interfaces;

namespace Zenith.Client.ViewModel
{
    public class IdentifierObjectSearch
    {

    }

    public class ConeObjectSearch: SearchOptionsViewModelBase
    {
        ObservableCollection<SearchOptionsItem> _items = null;

        ObservableCollection<SearchOptionSegment> _segments = null;
        bool _isSearchActive = false;
        SearchOptionsItem _addedItem = null;
        SearchOptionsItem _updatedItem = null;

        SimpleRelayCommand _addItemCommand;
        SimpleRelayCommand _updateItemCommand;
        SimpleRelayCommand _segmentDeleteCommand;

        ISearchRequest _searchRequest = null;

        public ConeObjectSearch()
        {
            _items = new ObservableCollection<SearchOptionsItem>();
            _segments = new ObservableCollection<SearchOptionSegment>();
            CreateSearchOptions();
        }

        private void CreateSearchOptions()
        {
            SearchOptionsItem coordinates = new SearchOptionsItem() { Caption = "Coordinates :", CurrentView = new CoordinatesViewModel(), CanAdd = true, CanModify = false };
            coordinates.PropertyChanged += SearchItem_PropertyChanged;

            SearchOptionsItem epoch = new SearchOptionsItem() { Caption = "Epoch :", CurrentView = new EpochViewModel(), CanAdd = true, CanModify = false, Kind = SearchOptionKind.Epoch };
            epoch.PropertyChanged += SearchItem_PropertyChanged;

            SearchOptionsItem equinox = new SearchOptionsItem() { Caption = "Equinox", CurrentView = new EquinoxViewModel(), CanAdd = true, CanModify = false, Kind = SearchOptionKind.Equinox };
            equinox.PropertyChanged += SearchItem_PropertyChanged;

            SearchOptionsItem radius = new SearchOptionsItem() { Caption = "Radius :", CurrentView = new RadiusViewModel(), CanAdd = true, CanModify = false, Kind = SearchOptionKind.Radius };
            radius.PropertyChanged += SearchItem_PropertyChanged;

            SearchOptionsItem objectName = new SearchOptionsItem() { Caption = "Object name :", CurrentView = new ObjectNameViewModel(), CanAdd = true, CanModify = false, Kind = SearchOptionKind.ObjectName };
            objectName.PropertyChanged += SearchItem_PropertyChanged;

            _items.Add(coordinates);
            _items.Add(epoch);
            _items.Add(equinox);
            _items.Add(radius);
            _items.Add(objectName);
        }

        private void AddSearchOptionSegment(SearchOptionsItem searchOption)
        {
            SearchOptionSegment segment = SearchHelper.CreateFromSearchOption(searchOption);
            searchOption.CanModify = true;
            this._segments.Add(segment);
            NotifyPropertyChanged(this, new PropertyChangedEventArgs("Segments"));
        }

        private void UpdateSearchOptionSegment(SearchOptionsItem searchOption)
        {
            searchOption.CurrentView.UpdateSegmentValues();
            NotifyPropertyChanged(this, new PropertyChangedEventArgs("Segments"));
        }

        private void SearchItem_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            //if (e.PropertyName.Equals("IsEnabled"))
            //{                
            //    if (base.PropertyChanged != null)
            //        PropertyChanged(sender, new PropertyChangedEventArgs("ItemState"));
            //}
        }

        public ICommand AddItemCommand
        {
            get
            {
                if (_addItemCommand == null)
                    _addItemCommand = new SimpleRelayCommand(OnAddItem);

                return _addItemCommand;
            }
        }

        public ICommand UpdateItemCommand
        {
            get
            {
                if (_updateItemCommand == null)
                    _updateItemCommand = new SimpleRelayCommand(OnUpdateItem);

                return _updateItemCommand;
            }
        }

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
            SearchOptionSegment segment = arg as SearchOptionSegment;
            SearchOptionsItem searchOptionsItem = segment.Origin;

            if (searchOptionsItem != null)
            {
                searchOptionsItem.CanAdd = true;
                searchOptionsItem.CanModify = false;
                searchOptionsItem.CurrentView.DestroySegmentValues();
            }

            this.Segments.Remove(segment);
        }

        public void OnAddItem(object arg)
        {
            this.AddedItem = arg as SearchOptionsItem;
            this.AddedItem.CanAdd = false;

            AddSearchOptionSegment(this.AddedItem);
        }

        public void OnUpdateItem(object arg)
        {
            this.UpdatedItem = arg as SearchOptionsItem;

            UpdateSearchOptionSegment(this.UpdatedItem);
        }

        public ObservableCollection<SearchOptionsItem> SearchOptionsItems
        {
            get { return _items; }
            set { _items = value; }
        }

        public SearchOptionsItem AddedItem
        {
            get { return _addedItem; }
            set
            {
                _addedItem = value;
                NotifyPropertyChanged(this, new PropertyChangedEventArgs("AddedItem"));
            }
        }

        public SearchOptionsItem UpdatedItem
        {
            get { return _updatedItem; }
            set
            {
                _updatedItem = value;
                NotifyPropertyChanged(this, new PropertyChangedEventArgs("UpdatedItem"));
            }
        }

        public ObservableCollection<SearchOptionSegment> Segments
        {
            get { return _segments; }
            set
            {
                _segments = value;
                NotifyPropertyChanged(this, new PropertyChangedEventArgs("Segments"));
            }
        }

        //public bool IsSearchActive
        //{
        //    get { return _isSearchActive; }
        //    set
        //    {
        //        _isSearchActive = value;
        //        NotifyPropertyChanged(this, new PropertyChangedEventArgs("IsSearchActive"));
        //    }
        //}

        //public void OnSearch(SearchCommandParameters parameters)
        //{
        //    if (_isSearchActive)
        //    {
        //        if (SearchCancelled != null)
        //            SearchCancelled(this, EventArgs.Empty);

        //        _isSearchActive = false;
        //    }
        //    else
        //    {
        //        if (SearchStarted != null)
        //            SearchStarted(this, EventArgs.Empty);

        //        _isSearchActive = true;
        //    }
        //}

        public ISearchRequest GetRequest()
        {
            _searchRequest = new ObjectSearchRequest();
            //_searchRequest.SearchTerm = _searchText;

            return _searchRequest;
        }

        //protected void NotifyPropertyChanged(object sender, PropertyChangedEventArgs e)
        //{
        //    if (PropertyChanged != null)
        //        PropertyChanged(this, e);
        //}
    }

    public class SearchOptionSegment : Segment
    {
        public SearchOptionsItem Origin { get; set; }
    }
}
