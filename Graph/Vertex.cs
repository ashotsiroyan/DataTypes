using System;

namespace DataTypes
{
    public class Vertex<T>
    {
        private T data;
        private LinkedList<Vertex<T>> neighbors;

        public Vertex(T data)
        {
            this.data = data;

            this.neighbors = new LinkedList<Vertex<T>>();
        }

        public T Data
        {
            get { return data; }
        }

        public LinkedList<Vertex<T>> Neighbors
        {
            get { return neighbors; }
        }

        public int NeighborsCount
        {
            get { return neighbors.Count; }
        }

        public void AddEdge(Vertex<T> edge)
        {
            if (!neighbors.Contains(edge))
            {
                neighbors.Add(edge);
            }
        }

        public void RemoveEdge(Vertex<T> edge)
        {
            neighbors.Remove(edge);
        }

        public void RemoveAllEdges()
        {
            neighbors.Clear();
        }

        public override string ToString()
        {
            return data.ToString();
        }
    }
}
