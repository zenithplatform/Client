using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zenith.SearchModule.ViewModel
{
    public class SearchCategoryViewModel:INotifyPropertyChanged
    {
        private ObservableCollection<SearchCategory> _categories = null;
        private SearchCategory _selectedCategory = null;

        public SearchCategoryViewModel()
        {
            _categories = new ObservableCollection<SearchCategory>();
        }

        public ObservableCollection<SearchCategory> Categories
        {
            get { return _categories; }
            set
            {
                _categories = value;
                NotifyPropertyChanged(this, new PropertyChangedEventArgs("Categories"));
            }
        }

        public SearchCategory SelectedCategory
        {
            get { return _selectedCategory; }
            set
            {
                _selectedCategory = value;
                NotifyPropertyChanged(this, new PropertyChangedEventArgs("SelectedCategory"));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void NotifyPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, e);
        }
    }

    public class SearchCategory
    {
        public string Title { get; set; }
        public object CurrentView { get; set; }
    }

    //public class NavigableSearchCategory:SearchCategory
    //{
    //    public ObservableCollection<SearchCategoryOption> Options { get; set; }
    //}

    //public class SearchCategoryOption
    //{
    //    public string Title { get; set; }
    //    public object CurrentView { get; set; }
    //}
}
