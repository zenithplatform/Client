using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zenith.Client.Shared.ViewsModels;
using Zenith.Core.Models.Authentication;
using Zenith.Core.Service;

namespace Zenith.Client.ApplicationServices.Authentication
{
    public class AuthenticationServiceProxy : IAuthenticationServiceProxy
    {
        AuthService realService = null;

        public AuthenticationServiceProxy()
        {
            realService = new AuthService();
        }

        public AppUser SignInUser(string username, string password)
        {
            User realUser = realService.AuthenticateUser(username, password);

            if (realUser == null)
                return null;

            return new AppUser() { UserId = realUser.Id, EmailAddress = realUser.EmailAddress, Username = realUser.Username, AccessToken = realUser.AccessToken };
        }

        public AppUser SignUpUser(string emailAddress, string username, string password)
        {
            User realUser = realService.RegisterUser(emailAddress, username, password);

            if (realUser == null)
                return null;

            return new AppUser() { UserId = realUser.Id, EmailAddress = realUser.EmailAddress, Username = realUser.Username, AccessToken = realUser.AccessToken };
        }

        public bool SignOutUser(AppUser user)
        {
            return realService.SignOutUser(user.Username);
        }
    }
}
