using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zenith.Core.Models;
using Zenith.Core.Models.Interfaces;

namespace Zenith.Client.ViewModel
{
    public class CatalogsResultViewModel
    {
        private CatalogSearchRequest _request = null;
        private List<Catalog> _catalogs = null;

        public CatalogsResultViewModel()
        {
            _catalogs = new List<Catalog>();
        }

        public CatalogsResultViewModel(ISearchResultBase result, ISearchRequest request)
            :this()
        {
            _request = request as CatalogSearchRequest;
            CatalogSearchResult catalogsResult = result as CatalogSearchResult;
            _catalogs = catalogsResult.Catalogs;
        }

        public List<Catalog> Catalogs
        {
            get { return _catalogs; }
        }
    }
}
