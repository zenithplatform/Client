using QuickGraph;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zenith.Client.ViewModel
{
    public class ObjectTypeEdge:Edge<ObjectTypeVertex>
    {
        public ObjectTypeEdge(ObjectTypeVertex source, ObjectTypeVertex target)
            :base(source, target)
        {

        }
    }
}
