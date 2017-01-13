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
using System.Windows.Media.Animation;
using Zenith.Client.Shared.Commands;
using Zenith.Client.Shared.Interfaces;
using Zenith.Client.Shared.ViewsModels;

namespace Zenith.ClientApp.ViewModel
{
    public class NavbarContainer: ExposableViewModelBase
    {
        private const double NAVBAR_COLLAPSED_WIDTH = 55;
        private const double NAVBAR_EXPANDED_WIDTH = 200;

        ObservableCollection<NavbarTab> _tabs = null;
        ObservableCollection<NavbarCommand> _commands = null;
        bool _isExpanded = false;
        NavbarTab _selectedTab = null;
        //bool _isVisible = true;
        double _headerWidth = NAVBAR_COLLAPSED_WIDTH;
        public static readonly string AddTabAction = "AddTab";
        public static readonly string AddCommandAction = "AddCommand";
        public static readonly string ExpandCollapseAction = "ExpandCollapse";

        public NavbarContainer(IShellCoordinator coordinator)
            :base(coordinator)
        {
            _tabs = new ObservableCollection<NavbarTab>();
            _commands = new ObservableCollection<NavbarCommand>();

            Action<object> addTab = (object tab) => AddTab((NavbarTab)tab);
            Action<object> addCommand = (object command) => AddCommand((NavbarCommand)command);
            Action<object> expandCollapseTabs = (object expanded) => IsExpanded = (bool)expanded;

            this.RegisterGlobalAction(AddTabAction, addTab);
            this.RegisterGlobalAction(AddCommandAction, addCommand);
            this.RegisterGlobalAction(ExpandCollapseAction, expandCollapseTabs);
        }

        public double HeaderWidth
        {
            get { return _headerWidth; }
        }

        public ObservableCollection<NavbarTab> Tabs
        {
            get { return _tabs; }
        }

        public ObservableCollection<NavbarCommand> Commands
        {
            get { return _commands; }
        }

        public Visibility SeparatorVisible
        {
            get { return (_commands.Count > 0) ? Visibility.Visible : Visibility.Collapsed ; }
        }

        public void AddTab(NavbarTab tab)
        {
            _tabs.Add(tab);
            NotifyPropertyChanged(this, new PropertyChangedEventArgs("Tabs"));
        }

        public void RemoveTab(NavbarTab tab)
        {
            _tabs.Remove(tab);
            NotifyPropertyChanged(this, new PropertyChangedEventArgs("Tabs"));
        }

        public void AddCommand(NavbarCommand command)
        {
            _commands.Add(command);
            NotifyPropertyChanged(this, new PropertyChangedEventArgs("Commands"));
        }

        public void RemoveCommand(NavbarCommand command)
        {
            _commands.Remove(command);
            NotifyPropertyChanged(this, new PropertyChangedEventArgs("Commands"));
        }

        public bool IsExpanded
        {
            get { return _isExpanded; }
            set
            {
                _isExpanded = value;

                NotifyPropertyChanged(this, new PropertyChangedEventArgs("IsExpanded"));

                ToggleTabHeaderText(_isExpanded);
            }
        }

        private void ToggleTabHeaderText(bool visible)
        {
            foreach (NavbarTab tab in Tabs)
            {
                if (visible)
                    tab.Header.TextVisible = Visibility.Visible;
                else
                    tab.Header.TextVisible = Visibility.Hidden;
            }

            foreach (NavbarCommand cmd in Commands)
            {
                if (visible)
                    cmd.TextVisible = Visibility.Visible;
                else
                    cmd.TextVisible = Visibility.Hidden;
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

        //public bool IsVisible
        //{
        //    get { return _isVisible; }
        //    set
        //    {
        //        _isVisible = value;
        //        NotifyPropertyChanged(this, new PropertyChangedEventArgs("IsVisible"));
        //    }
        //}
    }

    public class NavbarTab: ViewModelBase
    {
        private NavbarTabHeader _header = null;
        private object _tabContent = null;
        string _title = "";

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

        public string Title
        {
            get { return _title; }
            set
            {
                _title = value;
                NotifyPropertyChanged(this, new PropertyChangedEventArgs("Title"));
            }
        }

        public bool IsSelected { get; set; }
    }

    public class NavbarTabHeader: ViewModelBase
    {
        Visibility _textVisible = Visibility.Hidden;

        public string HeaderText { get; set; }
        public string ImageResource { get; set; }

        public Visibility TextVisible
        {
            get { return _textVisible; }
            set
            {
                _textVisible = value;
                NotifyPropertyChanged(this, new PropertyChangedEventArgs("TextVisible"));
            }
        }
    }

    public class NavbarCommand : ViewModelBase
    {
        Visibility _textVisible = Visibility.Hidden;
        ShellViewModel _parent = null;
        private RelayCommand<object> _clickCommand;

        public string HeaderText { get; set; }
        public string ImageResource { get; set; }

        public NavbarCommand()
        {

        }

        public NavbarCommand(ShellViewModel parent)
        {
            _parent = parent;
        }

        public Visibility TextVisible
        {
            get { return _textVisible; }
            set
            {
                _textVisible = value;
                NotifyPropertyChanged(this, new PropertyChangedEventArgs("TextVisible"));
            }
        }

        public ICommand ClickCommand
        {
            get
            {
                if (_clickCommand == null)
                    _clickCommand = new RelayCommand<object>(OnCommandClick);

                return _clickCommand;
            }
        }

        public void OnCommandClick(object parameters)
        {
            if (string.IsNullOrEmpty(AttachedFlyoutName))
            {
                if (ClickHandler != null)
                    ClickHandler(parameters);
            }
            //else
            //{
            //    _parent.ToggleFlyout(AttachedFlyoutName, MahApps.Metro.Controls.Position.Left);
            //}
        }

        public Action<object> ClickHandler
        {
            get;
            set;
        }

        public string AttachedFlyoutName
        {
            get;
            set;
        }
    }
}
