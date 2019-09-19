using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace Grump.DataStructures
{
    [DebuggerDisplay("value = {Value}")]
    public class GraphVertex<T>
    {
        internal GraphVertex(Graph<T> graph, T value)
        {
            this.Graph = graph;
            this.Value = value;
        }

        public Graph<T> Graph { get; set; }
        public T Value { get; protected set; }

        public IReadOnlyCollection<GraphEdge<T>> AdjacencyList
        {
            get
            {
                var edges = (from e in this.Graph.Edges
                             where e.Origin == this
                             select e);

                return new ReadOnlyCollection<GraphEdge<T>>(edges.ToList());

            }
        }
    }
}
