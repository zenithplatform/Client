using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Zenith.Client.Views
{
    public interface IShellViewCoordinator
    {
        void NavigateTo(UserControl newView);
        void NavigateTo(UserControl newView, string newTitle);
    }
}
