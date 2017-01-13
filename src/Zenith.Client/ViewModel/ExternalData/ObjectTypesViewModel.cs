using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zenith.Client.ApplicationServices.Storage;
using Zenith.Core.Models;

namespace Zenith.Client.ViewModel
{
    public class ObjectTypesViewModel
    {
        ObjectTypesContainer _container = null;

        public ObjectTypesViewModel()
        {
            
        }

        public void LoadObjectTypes()
        {
            StorageService storageSvc = new StorageService();
            _container = storageSvc.LoadObjectTypes();
        }

        public ObservableCollection<CelestialObjectType> ObjectTypes
        {
            get
            {
                if (_container == null)
                    return null;

                return _container.AllTypes;
            }
        }
    }
}
