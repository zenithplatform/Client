using System;
using Zenith.Client.Shared;
using Zenith.Core.Models;
using Zenith.Core.Models.VirtualObservatory;

namespace Zenith.Client.ApplicationServices.Search
{
    public interface ISearchServiceProxy
    {
        VirtualObservatoryResponseBase Search(VirtualObservatoryRequestBase request);
        VirtualObservatoryResponseBase Search(VirtualObservatoryRequestBase request, SearchType searchType);
        event EventHandler OnSearchStarted;
        event EventHandler OnSearchFinished;
    }
}
