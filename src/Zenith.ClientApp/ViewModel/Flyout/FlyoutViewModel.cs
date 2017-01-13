using MahApps.Metro.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zenith.Client.Shared.Interfaces;

namespace Zenith.ClientApp.ViewModel
{
    public class FlyoutViewModel
    {
        IShellCoordinator _coordinator = null;

        public FlyoutViewModel(IShellCoordinator coordinator)
        {
            _coordinator = coordinator;
        }

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
