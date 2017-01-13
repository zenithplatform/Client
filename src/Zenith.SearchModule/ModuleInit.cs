using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zenith.Client.Shared;
using Zenith.Client.Shared.Interfaces;
using Zenith.SearchModule.ViewModel;
using Zenith.SearchModule.Views;

namespace Zenith.SearchModule
{
    public class ModuleInit : IModuleInitializer
    {
        SearchModuleMetadata _metadata = null;

        public ModuleMetadata GetMetadata()
        {
            return _metadata;
        }

        public void InitModule()
        {
            _metadata = new SearchModuleMetadata();
            _metadata.Initialize();
        }
    }
}
