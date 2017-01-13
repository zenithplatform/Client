using MahApps.Metro.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zenith.Client.Shared.Interfaces;
using Zenith.ClientApp.Interfaces;
using System.Windows.Controls;
using System.Reflection;
using Zenith.ClientApp.Windows;
using Zenith.Client.Shared.ViewsModels;
using Zenith.ClientApp.ViewModel.Shell;
using Zenith.ClientApp.Coordinators;

namespace Zenith.ClientApp.ViewModel
{
    public class ShellViewModel : ViewModelBase
    {
        FlyoutViewModel _flyouts = null;
        NavbarContainer _navbarStrip = null;
        UpperStripViewModel _upperStrip = null;
        StatusBarViewModel _statusBar = null;
        IModulePresenter _navbarPresenter = null;

        IShellCoordinator _shellCoordinator = null;

        public ShellViewModel(IShellCoordinator shellCoordinator)
        {
            _flyouts = new FlyoutViewModel(shellCoordinator);
            _upperStrip = new UpperStripViewModel(shellCoordinator);
            _navbarStrip = new NavbarContainer(shellCoordinator);
            _statusBar = new StatusBarViewModel(shellCoordinator);
            
            this._shellCoordinator = shellCoordinator;
            _navbarPresenter = new NavbarModulePresenter();

            Setup();
        }

        #region Mock

        private void Setup()
        {
            //NavbarTab search = new NavbarTab();
            //search.Header.HeaderText = "Search";
            //search.Header.ImageResource = "appbar_magnify";
            //search.Title = "Pick one of the search modes";
            //search.TabContent = null;

            //_shellCoordinator.Invoke<NavbarContainer>(NavbarContainer.AddTabAction, search);

            NavbarCommand signIn = new NavbarCommand();
            signIn.HeaderText = "Sign in";
            signIn.ImageResource = "appbar_user";
            signIn.ClickHandler = new Action<object>(delegate (object parameter)
                                        {
                                            AuthDialogViewModel loginModel = new AuthDialogViewModel();
                                            loginModel.AuthenticationForm = new AuthFormViewModel();
                                            _shellCoordinator.ShowDialog<LoginDialog>(this._shellCoordinator.MainWindow, loginModel);
                                        });

            _shellCoordinator.Invoke<NavbarContainer>(NavbarContainer.AddCommandAction, signIn);

            NavbarCommand settings = new NavbarCommand();
            settings.HeaderText = "Settings";
            settings.ImageResource = "appbar_cog";
            settings.ClickHandler = new Action<object>(delegate (object parameter)
            {
                //LoginDialog loginDialog = new LoginDialog(this);
                //loginDialog.ShowDialog();
            });

            _shellCoordinator.Invoke<NavbarContainer>(NavbarContainer.AddCommandAction, settings);

            this._shellCoordinator.Invoke<UpperStripViewModel>(UpperStripViewModel.SetCurrentTitleAction, "Test title");
            this._shellCoordinator.Invoke<StatusBarViewModel>(StatusBarViewModel.SetCurrentStatusAction, "Ready.");
            this._shellCoordinator.Invoke<StatusBarViewModel>(StatusBarViewModel.SetCurrentLocationAction, "Belgrade, Serbia");

            IModuleInitializer searchModule = AppCoordinator.Instance.LoadModule(@"D:\Programming\Astronomy\Dev\Zenith\src\Client\Zenith.SearchModule\bin\Debug\Zenith.SearchModule.dll");
            _navbarPresenter.Render(searchModule.GetMetadata(), _shellCoordinator);

            IModuleInitializer workspaceModule = AppCoordinator.Instance.LoadModule(@"D:\Programming\Astronomy\Dev\Zenith\src\Client\Zenith.WorkspaceModule\bin\Debug\Zenith.WorkspaceModule.dll");
            _navbarPresenter.Render(workspaceModule.GetMetadata(), _shellCoordinator);

            IModuleInitializer filesModule = AppCoordinator.Instance.LoadModule(@"D:\Programming\Astronomy\Dev\Zenith\src\Client\Zenith.FileModule\bin\Debug\Zenith.FilesModule.dll");
            _navbarPresenter.Render(filesModule.GetMetadata(), _shellCoordinator);
        }

        #endregion

        #region Flyouts

        //public void ToggleFlyout(string name)
        //{
        //    this.ApplyToggleFlyout(name);
        //}

        //public void ToggleFlyout(string name, Position position)
        //{
        //    this.ApplyToggleFlyout(name, position);
        //}

        //public void ToggleFlyout(string name, bool isModal)
        //{
        //    this.ApplyToggleFlyout(name, null, isModal);
        //}

        //public void ToggleFlyout(string name, Position position, bool isModal)
        //{
        //    this.ApplyToggleFlyout(name, position, isModal);
        //}

        //protected void ApplyToggleFlyout(string name, Position? position = null, bool? isModal = null, bool? show = null)
        //{
        //    foreach (var f in this._flyouts.FlyoutsCollection.Where(x => name.Equals(x.Name)))
        //    {
        //        if (position.HasValue)
        //        {
        //            f.Position = position.Value;
        //        }

        //        if (isModal.HasValue)
        //        {
        //            f.IsModal = isModal.Value;
        //        }

        //        if (show.HasValue)
        //        {
        //            f.IsOpen = show.Value;
        //        }
        //        else
        //        {
        //            f.IsOpen = !f.IsOpen;
        //        }
        //    }
        //}

        public FlyoutViewModel Flyouts
        {
            get { return _flyouts; }
        }

        #endregion

        #region Layout

        //public void LoadNavbar()
        //{
        //    _navbarStrip.IsVisible = true;
        //}

        public NavbarContainer NavbarStrip
        {
            get
            {
                return _navbarStrip;
            }
        }

        public UpperStripViewModel UpperStrip
        {
            get
            {
                return _upperStrip;
            }
        }

        public StatusBarViewModel StatusBar
        {
            get { return _statusBar; }
        }

        #endregion
    }

    public class UpperStripViewModel: ExposableViewModelBase
    {
        public static readonly string SetCurrentTitleAction = "SetCurrentTitle";
        string _currentTitle = "";

        public UpperStripViewModel(IShellCoordinator shellCoordinator)
            :base(shellCoordinator)
        {
            Action<object> setCurrentTitle = (object title) => CurrentTitle = title.ToString();
            this.RegisterGlobalAction(SetCurrentTitleAction, setCurrentTitle);
        }

        public UserAccountViewModel Account
        {
            get
            {
                UserAccountViewModel viewModel = new UserAccountViewModel();

                RegisteredUserViewModel registeredUserAccountView = new RegisteredUserViewModel();
                registeredUserAccountView.LoggedUserPart = new LoggedUserDropdownPart();

                viewModel.CurrentView = registeredUserAccountView;
                //viewModel.CurrentView = new AnonymousUserViewModel();
                return viewModel;
            }
        }

        public string CurrentTitle
        {
            get { return _currentTitle; }
            set
            {
                _currentTitle = value;
                NotifyPropertyChanged(this, new PropertyChangedEventArgs("CurrentTitle"));
            }
        }
    }
}
