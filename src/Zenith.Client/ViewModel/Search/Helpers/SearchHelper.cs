using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using Zenith.Client.Shared;
using Zenith.Client.Shared.ViewModel;
using Zenith.Client.Views;
using Zenith.Core.Models;
using Zenith.Core.Models.Interfaces;

namespace Zenith.Client.ViewModel.Search.Helpers
{
    internal static class SearchHelper
    {
        internal static UserControl PrepareView(ISearchResultBase result, ISearchRequest request, SearchType searchType)
        {
            UserControl ret = null;

            if(searchType == SearchType.ObjectSearch)
            {
                IObjectSearchResult<CelestialObject> _objectsResult = result as IObjectSearchResult<CelestialObject>;

                if(_objectsResult == null)
                {
                    ret = new ObjectsDetailsView();
                    ObjectsDetailsViewModel exactModel = new ObjectsDetailsViewModel(null, request);
                    ret.DataContext = exactModel;

                    return ret;
                }
                else if(_objectsResult.Objects != null && _objectsResult.Objects.Count > 0)
                {
                    if(_objectsResult.Objects.Count == 1)
                    {
                        ret = new ObjectsDetailsView();
                        ObjectsDetailsViewModel exactModel = new ObjectsDetailsViewModel(_objectsResult.Objects.First(), request);
                        ret.DataContext = exactModel;
                    }
                    else
                    {
                        ret = new ObjectListView();
                        ObjectSearchResult res = _objectsResult as ObjectSearchResult;
                        ObjectListViewModel listViewModel = new ObjectListViewModel(res, request);
                        ret.DataContext = listViewModel;
                    }
                }
            }
            else if (searchType == SearchType.CatalogSearch)
            {
                ret = new CatalogSearchResultsView();
                CatalogsResultViewModel catalogsModel = new CatalogsResultViewModel(result, request);
                ret.DataContext = catalogsModel;
            }

            return ret;
        }

        internal static TextBoxSegment Create(SearchOptionsItem item)
        {
            ISegmentPresenter<TextBoxSegment> presenter = item as ISegmentPresenter<TextBoxSegment>;

            if(presenter != null)
            {
                TextBoxSegment segment = presenter.CreateSegment();
                ObservableCollection<SegmentPart> parts = item.CurrentView.CreateSegmentValues();

                segment.Parts = parts;
                return segment;
            }

            return null;
        }

        internal static SearchOptionSegment CreateFromSearchOption(SearchOptionsItem item)
        {
            ISegmentPresenter<SearchOptionSegment> presenter = item as ISegmentPresenter<SearchOptionSegment>;

            if (presenter != null)
            {
                SearchOptionSegment segment = presenter.CreateSegment();
                ObservableCollection<SegmentPart> parts = item.CurrentView.CreateSegmentValues();

                segment.Parts = parts;
                return segment;
            }

            return null;
        }

        //internal static ISearchResult<T> CreateSearchResult<T>(SearchType searchType) where T :class
        //{
        //    if (searchType == SearchType.ObjectSearch)
        //        return new ObjectSearchResult();
        //    else if (searchType == SearchType.CatalogSearch)
        //        return new CatalogSearchResult();
        //}
    }
}
