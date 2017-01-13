using MahApps.Metro.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zenith.Client.ViewModel
{
    public class FlyoutViewModel
    {
        public List<IFlyout> FlyoutsCollection { get; set; }
    }

    public interface IFlyout
    {
        string Header { get; set; }
        bool IsOpen { get; set; }
        Position Position { get; set; }
        string Name { get; set; }
        bool IsModal { get; set; }
    }
}
