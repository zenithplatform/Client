using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zenith.SearchModule.ViewModel
{
    public class ObjectCategoryViewModel
    {
        public IdentifierObjectSearch IdentifierSearchOptions
        {
            get;
            set;
        }

        //public SearchOptionsViewModel ConeSearchOptions
        public ConeObjectSearch ConeSearchOptions
        {
            get;
            set;
        }
    }
}
