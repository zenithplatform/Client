using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zenith.Client.ViewModel
{
    public class SearchHistoryViewModel
    {
        public List<SearchHistoryItem> SearchHistory
        {
            get
            {
                return new List<SearchHistoryItem> {    new SearchHistoryItem() { DateTime = DateTime.Now, SearchTerm = "Betelgeuse" },
                                                        new SearchHistoryItem() { DateTime = DateTime.Now, SearchTerm = "Vega" },
                                                        new SearchHistoryItem() { DateTime = DateTime.Now, SearchTerm = "Alfa centauri" },
                                                        new SearchHistoryItem() { DateTime = DateTime.Now, SearchTerm = "Zeta2 Reticuli" },
                                                        new SearchHistoryItem() { DateTime = DateTime.Now, SearchTerm = "HD 4240" }
                };
                //return new List<SearchHistoryItem>();
            }
        }

        public int RecordCount
        {
            get { return this.SearchHistory.Count; }
        }

        public string EmptyGridMessage
        {
            get { return "No search history yet."; }
        }
    }

    public class SearchHistoryItem
    {
        public DateTime DateTime { get; set; }
        public string SearchTerm { get; set; }
    }
}
