using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Zenith.Client.Commands;

namespace Zenith.Client.ViewModel
{
    public class SearchOptionsViewModel:INotifyPropertyChanged
    {
        ObservableCollection<SearchOptionsItem> _items = null;

        private SearchOptionsItem _addedItem = null;
        private SearchOptionsItem _updatedItem = null;

        private SimpleRelayCommand _addItemCommand;
        private SimpleRelayCommand _updateItemCommand;

        public event PropertyChangedEventHandler PropertyChanged;

        public SearchOptionsViewModel()
        {
            _items = new ObservableCollection<SearchOptionsItem>();
            PopulateItems();
        }

        private void PopulateItems()
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

        private void SearchItem_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if(e.PropertyName.Equals("IsEnabled"))
            {
                if (PropertyChanged != null)
                    PropertyChanged(sender, new PropertyChangedEventArgs("ItemState"));
            }
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

        public void OnAddItem(object arg)
        {
            this.AddedItem = arg as SearchOptionsItem;
            this.AddedItem.CanAdd = false;
        }

        public void OnUpdateItem(object arg)
        {
            this.UpdatedItem = arg as SearchOptionsItem;
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

        protected void NotifyPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, e);
        }
    }

    public class AddItemCommandParameters:CommandParameters
    {

    }

    public class UpdateItemCommandParameters:CommandParameters
    {

    }
}
