using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Zenith.Client.Shared.ControlHelpers;
using Zenith.Core.Models;
using Zenith.Core.Models.VirtualObservatory;
using Zenith.Core.Models.VirtualObservatory.Catalogs;

namespace Zenith.SearchModule.ViewModel
{
    public class PageableCatalogResultViewModel:INotifyPropertyChanged
    {
        private CatalogSearchRequest _request = null;
        private PageableCollection<Catalog> _catalogs;

        public PageableCatalogResultViewModel(VirtualObservatoryResponseBase result, VirtualObservatorySearchRequest request)
        {
            _request = request as CatalogSearchRequest;
            CatalogSearchResult catalogsResult = result as CatalogSearchResult;
            _catalogs = new PageableCollection<Catalog>(catalogsResult.Catalogs);
        }

        public PageableCollection<Catalog> Catalogs
        {
            get
            {
                return _catalogs;
            }
            set
            {
                if (_catalogs != value)
                {
                    _catalogs = value;
                    NotifyPropertyChanged(this, new PropertyChangedEventArgs("Catalogs"));
                }
            }
        }

        public ICommand GoToNextPageCommand { get; private set; }
        public ICommand GoToPreviousPageCommand { get; private set; }

        public List<int> EntriesPerPageList
        {
            get
            {
                return new List<int>() { 5, 10, 15 };
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void NotifyPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, e);
        }
    }
}
