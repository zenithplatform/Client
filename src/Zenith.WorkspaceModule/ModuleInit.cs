using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zenith.Client.Shared.Interfaces;

namespace Zenith.WorkspaceModule
{
    public class ModuleInit : IModuleInitializer
    {
        WorkspaceModuleMetadata _metadata = null;

        public ModuleMetadata GetMetadata()
        {
            return _metadata;
        }

        public void InitModule()
        {
            _metadata = new WorkspaceModuleMetadata();
            _metadata.Initialize();
        }
    }
}
