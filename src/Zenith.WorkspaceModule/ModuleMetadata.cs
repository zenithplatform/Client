using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using Zenith.Client.Shared.Interfaces;
using Zenith.WorkspaceModule.Views;

namespace Zenith.WorkspaceModule
{
    public class WorkspaceModuleMetadata : ModuleMetadata
    {
        private UserControl _startPage = null;
        private VisualElements _visualElements;
        
        public override UserControl StartPage
        {
            get
            {
                return _startPage;
            }
        }

        public override VisualElements VisualElements
        {
            get
            {
                return _visualElements;
            }
        }

        protected override void InitializeStartPage()
        {
            _startPage = new Workspace();
        }

        protected override void InitializeVisualElements()
        {
            _visualElements = new VisualElements("appbar_layer", "Workspace", "View and manipulate data files");
        }
    }
}
