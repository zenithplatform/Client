using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using Zenith.Client.Shared;
using Zenith.Client.Shared.Interfaces;
using Zenith.SearchModule.ViewModel;
using Zenith.SearchModule.Views;

namespace Zenith.SearchModule
{
    public class SearchModuleMetadata : ModuleMetadata
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
            SearchTileViewModel tileViewModel = new SearchTileViewModel();

            tileViewModel.AddTile("Search by name", "Search objects by exact identifier or name", SearchType.ObjectSearch);
            tileViewModel.AddTile("Search by approximate name", "Search objects by approximate identifier or name", SearchType.ObjectSearch);
            tileViewModel.AddTile("Search by position", "Search objects by its position on the sky", SearchType.ObjectSearch);
            tileViewModel.AddTile("Search objects around position", "Search objects around specified position on the sky", SearchType.ObjectSearch);
            tileViewModel.AddTile("Search catalogs", "Search catalogs by name", SearchType.CatalogSearch);

            _startPage = new SearchTileView();
            _startPage.DataContext = tileViewModel;
        }

        protected override void InitializeVisualElements()
        {
            _visualElements = new VisualElements("appbar_magnify", "Search", "Pick one of the search modes");
        }
    }
}
