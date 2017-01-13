using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zenith.Client.Shared.Interfaces;

namespace Zenith.FilesModule
{
    public class ModuleInit : IModuleInitializer
    {
        FilesModuleMetadata _metadata = null;

        public ModuleMetadata GetMetadata()
        {
            return _metadata;
        }

        public void InitModule()
        {
            _metadata = new FilesModuleMetadata();
            _metadata.Initialize();
        }
    }
}
