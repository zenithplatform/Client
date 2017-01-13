using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zenith.Core.Models;

namespace Zenith.Client.ViewModel.Mock
{
    internal static class MockSearchService
    {
        internal static CatalogSearchResult SearchCatalogs()
        {
            string content = File.ReadAllText(@"ViewModel\Mock\catalogs.txt");
            return JsonConvert.DeserializeObject<CatalogSearchResult>(content);
        }
    }
}
