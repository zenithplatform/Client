using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zenith.SearchModule.ViewModel
{
    public class SearchOptionsPaneViewModel:INotifyPropertyChanged
    {
        private SearchOptionsPaneState _state = SearchOptionsPaneState.Unknown;
        private SearchCategoryViewModel _categories = null;

        public SearchOptionsPaneState State
        {
            get { return _state; }
            set
            {
                _state = value;
                NotifyPropertyChanged(this, new PropertyChangedEventArgs("State"));
            }
        }

        public SearchCategoryViewModel CategoriesContainer
        {
            get { return _categories; }
            set
            {
                _categories = value;
                NotifyPropertyChanged(this, new PropertyChangedEventArgs("CategoriesContainer"));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void NotifyPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, e);
        }
    }

    public enum SearchOptionsPaneState
    {
        Expanded,
        Collapsed,
        Unknown
    }
}
