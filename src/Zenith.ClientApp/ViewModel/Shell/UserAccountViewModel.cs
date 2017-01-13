using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zenith.ClientApp.ViewModel
{
    public class RegisteredUserViewModel
    {
        //Button or dropdown for logged user
        public object LoggedUserPart { get; set; }
    }

    public class AnonymousUserViewModel
    {

    }

    public class UserAccountViewModel
    {
        public object CurrentView { get; set; }
    }

    public class LoggedUserDropdownPart
    {
        public List<string> Actions
        {
            get
            {
                return new List<string>() { "Profile", "Logout" };
            }
        }
    }
}
