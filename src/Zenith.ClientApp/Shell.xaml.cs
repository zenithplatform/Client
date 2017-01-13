using MahApps.Metro.Controls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Zenith.Client.Shared;
using Zenith.Client.Shared.Interfaces;
using Zenith.ClientApp.Views;
using Zenith.ClientApp.ViewModel;
using System.Windows.Threading;
using Zenith.ClientApp.Windows;
using Zenith.ClientApp.ViewModel.Shell;

namespace Zenith.ClientApp
{
    public partial class Shell
    {
        //ShellViewModel _shellViewModel = null;
        

        public Shell()
        {
            InitializeComponent();
            //this.Loaded += Shell_Loaded;
            //DataContext = this;

            //this._shellCoordinator = new ShellCoordinator();
            //_shellViewModel = new ShellViewModel(this._shellCoordinator);
        }

        private void Shell_Loaded(object sender, RoutedEventArgs e)
        {
            //Dispatcher.BeginInvoke(new Action(() =>
            //                           DelayLoad(1500, _shellViewModel.LoadNavbar)
            //                        ),
            //                        DispatcherPriority.ContextIdle,
            //                        null);

            //_shellViewModel.AddNavigationItem("Search", "", "appbar_magnify", "Pick one of the search modes", null);
            //_shellViewModel.AddNavigationItem("Data files", "", "appbar_page_text", "View and manipulate data files", null);

            //_shellViewModel.AddNavigationCommand("Sign in", "", "appbar_user_add", new Action<object>( delegate(object parameter) 
            //                                                                                           {
            //                                                                                               LoginDialog loginDialog = new LoginDialog(this);
            //                                                                                               loginDialog.ShowDialog();
            //                                                                                           }
            //                                                                                          ));
            //_shellViewModel.AddNavigationCommand("Settings", "", "appbar_cog", "Settings");

            //List<IFlyout> _flyouts = new List<IFlyout>();
            //_flyouts.Add(new SettingsFlyout());

            //_shellViewModel.Flyouts.FlyoutsCollection = _flyouts;
        }

        //private void LoadNavigation()
        //{
        //    _shellViewModel.LoadNavbar();
        //}

        //private void DelayLoad(int miliseconds, Action method)
        //{
        //    DispatcherTimer timer = new DispatcherTimer(DispatcherPriority.Background);
        //    timer.Interval = TimeSpan.FromMilliseconds(miliseconds);
        //    timer.Tick += ((d, e) =>
        //    {
        //        Application.Current.Dispatcher.BeginInvoke(DispatcherPriority.Background, method);
        //        timer.Stop();
        //        timer = null;
        //    });
        //    timer.Start();
        //}

        //public void NavigateTo(UserControl newView)
        //{
        //    NavbarTab currentTab = ShellView.NavbarStrip.CurrentTab;
        //    currentTab.TabContent = newView;
        //}

        //public void NavigateTo(UserControl newView, string newTitle)
        //{
        //    NavbarTab currentTab = ShellView.NavbarStrip.CurrentTab;
        //    currentTab.ContentTitle = newTitle;
        //    currentTab.TabContent = newView;
        //}

        //public ShellViewModel ShellView
        //{
        //    get
        //    {
        //        return _shellViewModel;
        //    }
        //}
    }
}
