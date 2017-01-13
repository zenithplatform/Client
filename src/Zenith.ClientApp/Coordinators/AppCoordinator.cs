using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Zenith.Client.ApplicationServices.Authentication;
using Zenith.Client.Shared.Interfaces;
using Zenith.Client.Shared.ViewsModels;
using Zenith.ClientApp.Interfaces;
using Zenith.Client.Shared.Util;
using System.IO;

namespace Zenith.ClientApp.Coordinators
{
    public class AppCoordinator:IAppCoordinator
    {
        private static volatile IAppCoordinator _appCoordinator;
        private IAuthenticationServiceProxy _authService = null;
        private static readonly object _syncObject = new object();
        AppUser _loggedUser = null;

        public event GlobalEventHandler OnGlobalEvent;

        private AppCoordinator()
        {
            _authService = new AuthenticationServiceProxy();
        }

        public static IAppCoordinator Instance
        {
            get
            {
                if (null == _appCoordinator)
                {
                    lock (_syncObject)
                    {
                        if (null == _appCoordinator)
                        {
                            _appCoordinator = new AppCoordinator();
                        }
                    }
                }

                return _appCoordinator;
            }
        }

        public AppUser LoggedUser
        {
            get
            {
                return _loggedUser;
            }

            set
            {
                _loggedUser = value;
            }
        }

        public IModuleInitializer LoadModule(string path)
        {
            return ModuleLoader.Instance.LoadModule(path);
        }

        public void EmitGlobalEvent(GlobalEventType eventType, object payload)
        {
            if (OnGlobalEvent != null)
                OnGlobalEvent(eventType, payload);
        }

        public bool SignInUser(string username, string password)
        {
            _loggedUser = _authService.SignInUser(username, password);

            if (_loggedUser != null)
            {
                EmitGlobalEvent(GlobalEventType.UserLoggedIn, _loggedUser);
                return true;
            }

            return false;
        }

        public bool SignUpUser(string emailAddress, string username, string password)
        {
            _loggedUser = _authService.SignUpUser(emailAddress, username, password);

            if (_loggedUser != null)
            {
                EmitGlobalEvent(GlobalEventType.UserLoggedIn, _loggedUser);
                return true;
            }

            return false;
        }

        public bool SignOutUser(AppUser user)
        {
            bool result = _authService.SignOutUser(user);

            return result;
        }
    }
}
