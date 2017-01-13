using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zenith.Client.Test
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public List<UserPermission> UserPermissions { get; set; }
    }

    public class UserPermission
    {
        public string ModuleName { get; set; }
        public string PermissionLevel { get; set; }
    }
}
