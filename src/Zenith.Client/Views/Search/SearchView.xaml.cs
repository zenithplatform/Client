using Zenith.Client.Test;
using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Zenith.Client.Views
{
    public partial class SearchView : UserControl
    {
        public SearchView()
        {
            InitializeComponent();
            this.Loaded += SearchResultsView_Loaded;
        }

        private void BSave_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void SearchResultsView_Loaded(object sender, RoutedEventArgs e)
        {
            //this.DataContext = new DataObject();
        }

        //public ObservationDataList ObservationDataDetails
        //{
        //    get { return this.ObsData; }
        //}

        //public ObservationData ObservationDataList
        //{
        //    get { return this.ObsData; }
        //}

        //public ListBox ResultList
        //{
        //    get { return this.ObsData; }
        //}
    }

    //public class DataObject
    //{
    //    private List<User> _allUsers = new List<User>();

    //    public DataObject()
    //    {
    //        User user = new User();
    //        user.Id = 1;
    //        user.Username = "Test1";
    //        user.UserPermissions = new List<UserPermission>();
    //        user.UserPermissions.Add(new UserPermission() { ModuleName = "Module1", PermissionLevel = "All" });
    //        user.UserPermissions.Add(new UserPermission() { ModuleName = "Module2", PermissionLevel = "All" });
    //        user.UserPermissions.Add(new UserPermission() { ModuleName = "Module3", PermissionLevel = "All" });

    //        User user2 = new User();
    //        user2.Id = 1;
    //        user2.Username = "Test2";
    //        user2.UserPermissions = new List<UserPermission>();
    //        user2.UserPermissions.Add(new UserPermission() { ModuleName = "Module1", PermissionLevel = "All" });
    //        user2.UserPermissions.Add(new UserPermission() { ModuleName = "Module2", PermissionLevel = "All" });
    //        user2.UserPermissions.Add(new UserPermission() { ModuleName = "Module3", PermissionLevel = "All" });

    //        _allUsers.Add(user);
    //        _allUsers.Add(user2);
    //    }

    //    public List<User> AllUsers
    //    {
    //        get { return _allUsers; }
    //    }
    //}
}
