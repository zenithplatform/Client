using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zenith.Client.ViewModel.Helpers;
using Zenith.Core.Models;
using Zenith.Core.Models.Interfaces;

namespace Zenith.Client.ViewModel
{
    public class ObjectListViewModel : INotifyPropertyChanged
    {
        ObjectSearchRequest _request = null;
        public event PropertyChangedEventHandler PropertyChanged;

        public ObjectListViewModel()
        {
        }

        public ObjectListViewModel(ObjectSearchResult searchResult, ISearchRequest request)
        {
            _request = request as ObjectSearchRequest;

            this.Objects = ModelHelpers.ObjectListFromResult(searchResult);
        }

        public List<ObjectListViewItem> Objects
        {
            get;
            set;
        }
    }

    public class ObjectListViewItem
    {
        public string Name { get; set; }
        public string Constellation { get; set; }
        public string Coordinates { get; set; }
    }
}
