using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zenith.Client.Shared.Interfaces;
using Zenith.Client.Shared.ViewsModels;
using Zenith.ClientApp.ViewModel.Shell;

namespace Zenith.ClientApp.ViewModel
{
    public class StatusBarViewModel : ExposableViewModelBase
    {
        string _currentStatus = "";
        string _currentLocation = "";
        public static readonly string SetCurrentStatusAction = "SetCurrentStatus";
        public static readonly string SetCurrentLocationAction = "SetCurrentLocation";

        public StatusBarViewModel(IShellCoordinator shellCoordinator)
            :base(shellCoordinator)
        {
            Action<object> setCurrentStatus = (object status) => CurrentStatus = status.ToString();
            Action<object> setCurrentLocation = (object location) => CurrentLocation = location.ToString();

            this.RegisterGlobalAction(SetCurrentStatusAction, setCurrentStatus);
            this.RegisterGlobalAction(SetCurrentLocationAction, setCurrentLocation);
        }

        public string CurrentStatus
        {
            get { return _currentStatus; }
            set
            {
                _currentStatus = value;
                NotifyPropertyChanged(this, new PropertyChangedEventArgs("CurrentStatus"));
            }
        }

        public string CurrentLocation
        {
            get { return _currentLocation; }
            set
            {
                _currentLocation = value;
                NotifyPropertyChanged(this, new PropertyChangedEventArgs("CurrentLocation"));
            }
        }
    }
}
