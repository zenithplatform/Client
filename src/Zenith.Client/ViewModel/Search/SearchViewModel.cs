using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;
using Zenith.Client.ApplicationServices.Search;
using Zenith.Client.Shared;
using Zenith.Client.ViewModel.Mock;
using Zenith.Client.ViewModel.Search.Helpers;
using Zenith.Client.Views;
using Zenith.Core.Models;
using Zenith.Core.Models.Interfaces;

namespace Zenith.Client.ViewModel
{
    public class SearchViewModel:INotifyPropertyChanged
    {
        SearchBarViewModel _searchBarViewModel = null;
        SearchType _searchType = SearchType.ObjectSearch;

        System.Windows.Visibility _progressVisible = System.Windows.Visibility.Hidden;
        System.Windows.Visibility _searchResultVisible = System.Windows.Visibility.Hidden;

        object _resultContent = null;
        ISearchServiceProxy _proxy = null;
        ISearchRequest _request = null;
        System.Threading.CancellationTokenSource cancelTokenSource = null;

        public event PropertyChangedEventHandler PropertyChanged;

        public SearchViewModel(ISearchServiceProxy proxy)
        {
            _proxy = proxy;
            //_proxy.OnSearchStarted += _proxy_OnSearchStarted;
            //_proxy.OnSearchFinished += _proxy_OnSearchFinished;
        }

        public SearchViewModel(ISearchServiceProxy proxy, SearchType searchType)
        {
            _searchType = searchType;
            _proxy = proxy;

            _searchBarViewModel = new SearchBarViewModel(searchType);

            _searchBarViewModel.IsSegmented = false;

            _searchBarViewModel.PropertyChanged += _searchBarViewModel_PropertyChanged;

            _searchBarViewModel.SearchStarted += _searchBarViewModel_SearchStarted;
            _searchBarViewModel.SearchCancelled += _searchBarViewModel_SearchCancelled;
        }

        private void _searchBarViewModel_SearchCancelled(object sender, EventArgs e)
        {
            if (cancelTokenSource != null)
                cancelTokenSource.Cancel();

            this.ProgressVisible = System.Windows.Visibility.Hidden;
            this.SearchResultVisible = System.Windows.Visibility.Visible;
        }

        private void _searchBarViewModel_SearchStarted(object sender, EventArgs e)
        {
            this.ProgressVisible = System.Windows.Visibility.Visible;
            this.SearchResultVisible = System.Windows.Visibility.Hidden;

            Application.Current.Dispatcher.BeginInvoke(
                        DispatcherPriority.Background, new Action(StartSearchInternal));
            
        }

        private void _proxy_OnSearchFinished(object sender, EventArgs e)
        {

        }

        private void _proxy_OnSearchStarted(object sender, EventArgs e)
        { 
             
        }

        private void _searchBarViewModel_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            
        }

        void StartSearchInternal()
        {
            ISearchResultBase result = null;
            _request = _searchBarViewModel.GetRequest();
            TaskScheduler scheduler = TaskScheduler.FromCurrentSynchronizationContext();
            cancelTokenSource = new System.Threading.CancellationTokenSource();
            System.Threading.CancellationToken cancelationToken = cancelTokenSource.Token;

            Task.Factory.StartNew(() =>
                {
                    if (cancelTokenSource.Token.IsCancellationRequested)
                        return;

                    result = _proxy.Search(_request, _searchBarViewModel.SearchType);
                }).
                ContinueWith(w =>
                {
                    this.ProgressVisible = System.Windows.Visibility.Hidden;
                    this.SearchResultVisible = System.Windows.Visibility.Visible;

                    this.ResultContent = SearchHelper.PrepareView(result, _request, _searchBarViewModel.SearchType);
                },
                cancelationToken,
                TaskContinuationOptions.None, scheduler);
        }

        public object ResultContent
        {
            get { return _resultContent; }
            set
            {
                _resultContent = value;
                NotifyPropertyChanged(this, new PropertyChangedEventArgs("ResultContent"));
            }
        }

        public SearchBarViewModel SearchBarModel
        {
            get { return _searchBarViewModel; }
        }

        public System.Windows.Visibility ProgressVisible
        {
            get { return _progressVisible; }
            set
            {
                _progressVisible = value;
                NotifyPropertyChanged(this, new PropertyChangedEventArgs("ProgressVisible"));
            }
        }

        public System.Windows.Visibility SearchResultVisible
        {
            get { return _searchResultVisible; }
            set
            {
                _searchResultVisible = value;
                NotifyPropertyChanged(this, new PropertyChangedEventArgs("SearchResultVisible"));
            }
        }

        protected void NotifyPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, e);
        }
    }
}
