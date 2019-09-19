using System;
using System.Collections.Generic;

namespace Grump.DataStructures
{
    public class Graph<T> : IEnumerable<GraphVertex<T>>
    {
        public IReadOnlyCollection<GraphVertex<T>> Vertices
        {
            get
            {
                return this.vertices as IReadOnlyCollection<GraphVertex<T>>;
            }
        }

        public IReadOnlyCollection<GraphEdge<T>> Edges
        {
            get { return this.edges; }
        }

        private List<GraphVertex<T>> vertices { get; set; }
        private List<GraphEdge<T>> edges { get; set; }

        public Graph()
        {
            vertices = new List<GraphVertex<T>>();
            edges = new List<GraphEdge<T>>();
        }

        public GraphVertex<T> CreateVertex(T value)
        {
            var newVertex = new GraphVertex<T>(this, value);
            vertices.Add(newVertex);
            return newVertex;
        }

        public GraphEdge<T> CreateEdge(GraphVertex<T> origin, GraphVertex<T> destination, double weight = 1d)
        {
            var newEdge = new GraphEdge<T>(origin, destination, weight);
            this.edges.Add(newEdge);
            return newEdge;
        }


        public IEnumerator<GraphVertex<T>> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
