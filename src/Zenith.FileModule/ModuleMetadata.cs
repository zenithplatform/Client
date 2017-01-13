using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using Zenith.Client.Shared.Interfaces;
using Zenith.FilesModule.Views;

namespace Zenith.FilesModule
{
    public class FilesModuleMetadata: ModuleMetadata
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
            _startPage = new FilesStartPage();
        }

        protected override void InitializeVisualElements()
        {
            _visualElements = new VisualElements("appbar_page_text", "Data Files", "View and manipulate data files");
        }
    }
}
