using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zenith.Client.Shared;
using Zenith.Core.Models.Interfaces;

namespace Zenith.Client.ViewModel
{
    public class SearchOptionsViewModelBase : INotifyPropertyChanged
    {
        bool _isSearchActive = false;
        SearchType _searchType = SearchType.ObjectSearch;
        ISearchRequest _searchRequest = null;

        public event PropertyChangedEventHandler PropertyChanged;
        public event EventHandler SearchStarted;
        public event EventHandler SearchCancelled;

        public SearchOptionsViewModelBase()
        {
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

        public void OnSearch(SearchCommandParameters parameters)
        {
            if (_isSearchActive)
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

        //public ISearchRequest GetRequest()
        //{
        //    _searchRequest = new ObjectSearchRequest();
        //    //_searchRequest.SearchTerm = _searchText;

        //    return _searchRequest;
        //}

        public void NotifyPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, e);
        }
    }
}
