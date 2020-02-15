using System;
using System.Collections.Generic;
using System.Text;

namespace Grump.DataStructures
{
    public class GraphEdge<T>
    {
        public readonly GraphVertex<T> Origin;
        public readonly GraphVertex<T> Destination;
        public double Weight { get; set; }

        public GraphEdge()
        {
            this.Weight = 1d;
        }

        public GraphEdge(GraphVertex<T> origin, GraphVertex<T> destination, double weight)
        {
            if (origin == null)
                throw new ArgumentNullException("origin");

            if (destination == null)
                throw new ArgumentNullException("destination");

            if (!object.ReferenceEquals(origin.Graph, destination.Graph))
                throw new ArgumentException("Both Vertices should belong to the same graph.");

            this.Origin = origin;
            this.Destination = destination;
            this.Weight = weight;
        }

        public GraphEdge(GraphVertex<T> origin, GraphVertex<T> destination)
            : this(origin, destination, 1d)
        {

        }

    }
}
