using Newtonsoft.Json;
using System.IO;
using Zenith.Core.Models;

namespace Zenith.Client.ApplicationServices.Storage
{
    public class StorageService
    {
        public ObjectTypesContainer LoadObjectTypes()
        {
            string file_content = File.ReadAllText(@"ViewModel\Mock\object_types.txt");
            return JsonConvert.DeserializeObject<ObjectTypesContainer>(file_content);
        }
    }
}
