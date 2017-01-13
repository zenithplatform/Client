using QuickGraph;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zenith.VisualizationModule.ViewModel
{
    public class ObjectTypesGraph : BidirectionalGraph<ObjectTypeVertex, ObjectTypeEdge>
    {
        public ObjectTypesGraph() { }

        public ObjectTypesGraph(bool allowParallelEdges)
            : base(allowParallelEdges)
        { }

        public ObjectTypesGraph(bool allowParallelEdges, int vertexCapacity)
            : base(allowParallelEdges, vertexCapacity)
        { }
    }
}
