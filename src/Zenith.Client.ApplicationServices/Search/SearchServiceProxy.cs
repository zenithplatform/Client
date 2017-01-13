using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zenith.Client.Shared;
using Zenith.Core.Models;
using Zenith.Core.Models.VirtualObservatory;
using Zenith.Core.Models.VirtualObservatory.Catalogs;
using Zenith.Core.Models.VirtualObservatory.Objects;
using Zenith.Core.Service;

namespace Zenith.Client.ApplicationServices.Search
{
    public class SearchServiceProxy : ISearchServiceProxy
    {
        SearchService realService = null;

        public SearchServiceProxy()
        {
            realService = new SearchService();
        }

        public event EventHandler OnSearchFinished;
        public event EventHandler OnSearchStarted;

        public VirtualObservatoryResponseBase Search(VirtualObservatoryRequestBase request)
        {
            throw new NotImplementedException();
        }

        private ObjectSearchResult SearchObjects(ObjectSearchRequest request)
        {
            ObjectSearchResult result = null;

            if (OnSearchStarted != null)
                OnSearchStarted(this, EventArgs.Empty);

            result = realService.SearchObjectExact(request.SearchTerm);

            if (OnSearchFinished != null)
                OnSearchFinished(this, EventArgs.Empty);

            return result;
        }

        private CatalogSearchResult SearchCatalogs(CatalogSearchRequest request)
        {
            CatalogSearchResult result = null;

            if (OnSearchStarted != null)
                OnSearchStarted(this, EventArgs.Empty);

            result = realService.SearchCatalog(request.SearchTerm);

            if (OnSearchFinished != null)
                OnSearchFinished(this, EventArgs.Empty);

            return result;
        }

        public VirtualObservatoryResponseBase Search(VirtualObservatoryRequestBase request, SearchType searchType)
        {
            if (searchType == SearchType.ObjectSearch)
            {
                ObjectSearchRequest objectReequest = request as ObjectSearchRequest;
                return SearchObjects(objectReequest);
            }
            else
            {
                CatalogSearchRequest catalogReequest = request as CatalogSearchRequest;
                return SearchCatalogs(catalogReequest);
            }
        }
    }
}
