using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zenith.Client.Shared.Interfaces;
using Zenith.Client.Shared.ViewsModels;

namespace Zenith.ClientApp.Interfaces
{
    public delegate void GlobalEventHandler(GlobalEventType eventType, object payload);

    public interface IAppCoordinator
    {
        event GlobalEventHandler OnGlobalEvent;

        AppUser LoggedUser { get; set; }
        void EmitGlobalEvent(GlobalEventType eventType, object payload);
        IModuleInitializer LoadModule(string path);

        bool SignInUser(string username, string password);
        bool SignUpUser(string emailAddress, string username, string password);
        bool SignOutUser(AppUser user);
    }

    public enum GlobalEventType
    {
        UserLoggedIn,
        UserLoggedOut
    }
}
