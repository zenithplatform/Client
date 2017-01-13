using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace Zenith.Client.ViewModel
{
    public class NavbarViewModel:INotifyPropertyChanged
    {
        ObservableCollection<NavbarTab> _tabs = null;
        bool _isExpanded = false;
        NavbarTab _selectedTab = null;
        

        public event PropertyChangedEventHandler PropertyChanged;

        public ObservableCollection<NavbarTab> Tabs
        {
            get { return _tabs; }
        }

        public NavbarViewModel()
        {
            _tabs = new ObservableCollection<NavbarTab>();
        }

        public void AddTab(NavbarTab tab)
        {
            _tabs.Add(tab);

            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs("Tabs"));
        }

        public void AddTab(string text, string imageSource, string imageResourceKey, string contentTitle, object content)
        {
            NavbarTab tab = new NavbarTab();
            tab.Header.HeaderText = text;
            tab.Header.ImageResourceKey = imageResourceKey;
            tab.Header.ImageSource = imageSource;
            tab.ContentTitle = contentTitle;
            tab.TabContent = content;

            _tabs.Add(tab);

            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs("Tabs"));
        }

        public bool IsExpanded
        {
            get { return _isExpanded; }
            set
            {
                _isExpanded = value;

                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("IsExpanded"));

                foreach (NavbarTab tab in Tabs)
                {
                    if (_isExpanded)
                    {
                        tab.Header.TextVisible = Visibility.Visible;
                        tab.Header.CurrentWidth = Double.NaN;
                    }
                    else
                    {
                        tab.Header.TextVisible = Visibility.Hidden;
                        tab.Header.CurrentWidth = 30;
                    }
                }
            }
        }

        public NavbarTab CurrentTab
        {
            get { return _selectedTab; }
            set
            {
                _selectedTab = value;
                NotifyPropertyChanged(this, new PropertyChangedEventArgs("CurrentTab"));
            }
        }

        protected void NotifyPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, e);
        }
    }

    public class NavbarTab:INotifyPropertyChanged
    {
        private NavbarTabHeader _header = null;
        private object _tabContent = null;
        public event PropertyChangedEventHandler PropertyChanged;
        string _contentTitle = "";

        public NavbarTab()
        {
            _header = new NavbarTabHeader();
        }

        public NavbarTabHeader Header
        {
            get { return _header; }
        }

        public object TabContent
        {
            get { return _tabContent; }
            set
            {
                _tabContent = value;
                NotifyPropertyChanged(this, new PropertyChangedEventArgs("TabContent"));
            }
        }

        public string ContentTitle
        {
            get { return _contentTitle; }
            set
            {
                _contentTitle = value;
                NotifyPropertyChanged(this, new PropertyChangedEventArgs("ContentTitle"));
            }
        }

        public bool IsSelected { get; set; }

        protected void NotifyPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, e);
        }
    }

    public class NavbarTabHeader:INotifyPropertyChanged
    {
        Visibility _textVisible = Visibility.Hidden;
        double _currentWidth = 30;

        public string HeaderText { get; set; }
        public string ImageSource { get; set; }
        public string ImageResourceKey { get; set; }

        public Visibility TextVisible
        {
            get { return _textVisible; }
            set
            {
                _textVisible = value;

                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("TextVisible"));
            }
        }

        public double CurrentWidth
        {
            get { return _currentWidth; }
            set
            {
                _currentWidth = value;

                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("CurrentWidth"));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
