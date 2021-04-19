using System;

namespace DataTypes
{
    public class Vertex<T>
    {
        public T Data { get; set; }
        public LinkedList<Vertex<T>> Neighbors { get; private set; }

        public Vertex(T data)
        {
            Data = data;

            Neighbors = new LinkedList<Vertex<T>>();
        }

        public int NeighborsCount
        {
            get { return Neighbors.Count; }
        }

        public void AddEdge(Vertex<T> edge)
        {
            if (!Neighbors.Contains(edge))
            {
                Neighbors.Add(edge);
            }
        }

        public void RemoveEdge(Vertex<T> edge)
        {
            Neighbors.Remove(edge);
        }

        public void RemoveAllEdges()
        {
            Neighbors.Clear();
        }

        public override string ToString()
        {
            return Data.ToString();
        }
    }
}
