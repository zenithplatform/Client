using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zenith.Client.Shared.ViewsModels;

namespace Zenith.Client.ApplicationServices.Authentication
{
    public interface IAuthenticationServiceProxy
    {
        AppUser SignInUser(string username, string password);
        AppUser SignUpUser(string emailAddress, string username, string password);
        bool SignOutUser(AppUser user);
    }
}
