using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;
using Zenith.Client.Shared.Commands;
using Zenith.Client.Shared.Interfaces;
using Zenith.Client.Shared.ViewsModels;
using Zenith.ClientApp.Coordinators;
using Zenith.ClientApp.Windows;
using Zenith.Core.Shared;

namespace Zenith.ClientApp.ViewModel
{
    public enum State
    {
        Working,
        Ready,
        Validating,
        Idle
    }

    public enum FormView
    {
        Login = 0,
        Signup = 1
    }

    public class AuthFormViewModel:ViewModelBase
    {
        State _state = State.Idle;
        ICommand _loginCommand, _signupCommand = null;
        AuthFormFooter _footer = null;
        FormView _currentView = FormView.Login;
        string _username, _email = "";
        bool _canAuthenticate = false;

        public AuthFormViewModel()
        {
            _footer = new AuthFormFooter();
            _currentView = (int)FormView.Login;
            this.PropertyChanged += EntryFormViewModel_PropertyChanged;
            NotifyPropertyChanged(this, new PropertyChangedEventArgs("CurrentView"));
        }

        private void EntryFormViewModel_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if(e.PropertyName == "CurrentView")
            {
                if (_currentView == FormView.Signup)
                    _footer.ResetLinkVisible = Visibility.Hidden;
                else
                    _footer.ResetLinkVisible = Visibility.Visible;
            }
        }

        public ICommand LoginCommand
        {
            get
            {
                if (_loginCommand == null)
                    _loginCommand = new RelayCommand<object>(OnLoginCommandClick);

                return _loginCommand;
            }
        }

        public ICommand SignupCommand
        {
            get
            {
                if (_signupCommand == null)
                    _signupCommand = new RelayCommand<object>(OnSignupCommandClick);

                return _signupCommand;
            }
        }

        public string EmailAddress
        {
            get { return _email; }
            set
            {
                _email = value;
                NotifyPropertyChanged(this, new PropertyChangedEventArgs("EmailAddress"));
                NotifyPropertyChanged(this, new PropertyChangedEventArgs("CanAuthenticate"));
            }
        }

        public string Username
        {
            get { return _username; }
            set
            {
                _username = value;
                NotifyPropertyChanged(this, new PropertyChangedEventArgs("Username"));
                NotifyPropertyChanged(this, new PropertyChangedEventArgs("CanAuthenticate"));
            }
        }

        public bool CanAuthenticate
        {
            get
            {
                if(this.CurrentView == (int)FormView.Login)
                {
                    _canAuthenticate = !string.IsNullOrEmpty(_username);
                }
                else
                {
                    _canAuthenticate = !string.IsNullOrEmpty(_username) && 
                                       !string.IsNullOrEmpty(_email);
                }

                return _canAuthenticate;
            }
        }

        public void OnLoginCommandClick(object parameters)
        {
            if (Validate())
            {
                SecureString secPassword = ((IPasswordSource)parameters).GetPassword();
                State = State.Working;
                Task.Factory.StartNew(() =>
                {
                    Thread.Sleep(5000);
                    AppCoordinator.Instance.SignInUser(Username, Utils.ConvertToUnsecureString(secPassword));
                    State = State.Idle;
                //ShellCoordinator.Instance.CloseDialog<LoginDialog>();
                MessageBox.Show(Utils.ConvertToUnsecureString(secPassword));
                });
            }
        }

        public void OnSignupCommandClick(object parameters)
        {
            if (Validate())
            {
                SecureString secPassword = ((IPasswordSource)parameters).GetPassword();

                State = State.Working;
                Task.Factory.StartNew(() =>
                {
                    Thread.Sleep(5000);
                    AppCoordinator.Instance.SignUpUser(EmailAddress, Username, Utils.ConvertToUnsecureString(secPassword));
                    State = State.Idle;
                //ShellCoordinator.Instance.CloseDialog<LoginDialog>();
                MessageBox.Show(Utils.ConvertToUnsecureString(secPassword));
                });
            }
        }

        private bool Validate()
        {
            return true;
            //if (_currentView == FormView.Signup)
                //....
            //else
                //...
        }

        public State State
        {
            get { return _state; }
            set
            {
                _state = value;
                NotifyPropertyChanged(this, new PropertyChangedEventArgs("State"));

                if(_state == State.Working)
                {
                    _footer.ProgressVisible = Visibility.Visible;
                    _footer.IsIndeterminate = true;
                    _footer.InitialValue = 0;
                }
                else
                {
                    _footer.ProgressVisible = Visibility.Hidden;
                    _footer.IsIndeterminate = false;
                    _footer.InitialValue = 0;
                }
            }
        }

        public AuthFormFooter Footer
        {
            get
            {
                return _footer;
            }
        }

        public int CurrentView
        {
            get { return (int)_currentView; }
            set
            {
                _currentView = (FormView)value;
                NotifyPropertyChanged(this, new PropertyChangedEventArgs("CurrentView"));
            }
        }
    }

    public class AuthFormFooter : ViewModelBase
    {
        Visibility _progressVisible = Visibility.Hidden;
        Visibility _resetLinkVisible = Visibility.Hidden;
        double _initialProgressValue = 0.0;
        bool _progressIsIndeterminate = true;

        public Visibility ProgressVisible
        {
            get
            {
                return _progressVisible;
            }
            set
            {
                _progressVisible = value;
                NotifyPropertyChanged(this, new PropertyChangedEventArgs("ProgressVisible"));
            }
        }

        public double InitialValue
        {
            get { return _initialProgressValue; }
            set
            {
                _initialProgressValue = value;
                NotifyPropertyChanged(this, new PropertyChangedEventArgs("InitialValue"));
            }
        }

        public bool IsIndeterminate
        {
            get { return _progressIsIndeterminate; }
            set
            {
                _progressIsIndeterminate = value;
                NotifyPropertyChanged(this, new PropertyChangedEventArgs("IsIndeterminate"));
            }
        }

        public Visibility ResetLinkVisible
        {
            get { return _resetLinkVisible; }
            set
            {
                _resetLinkVisible = value;
                NotifyPropertyChanged(this, new PropertyChangedEventArgs("ResetLinkVisible"));
            }
        }
    }
}
