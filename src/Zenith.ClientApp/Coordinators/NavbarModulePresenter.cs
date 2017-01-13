using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zenith.Client.Shared.Interfaces;
using Zenith.ClientApp.ViewModel;

namespace Zenith.ClientApp.Coordinators
{
    public class NavbarModulePresenter : IModulePresenter
    {
        public void Render(ModuleMetadata metadata, IShellCoordinator shellCoordinator)
        {
            object startPage = metadata.StartPage;
            NavbarTab workspace = new NavbarTab();
            workspace.Header.HeaderText = metadata.VisualElements.Caption;
            workspace.Header.ImageResource = metadata.VisualElements.Icon;
            workspace.Title = metadata.VisualElements.HelpText;
            workspace.TabContent = metadata.StartPage;

            shellCoordinator.Invoke<NavbarContainer>(NavbarContainer.AddTabAction, workspace);
        }
    }
}
