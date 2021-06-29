namespace DataTypes
{
    public class Vertex<T>
    {
        private T data;
        private LinkedList<Vertex<T>> edges;

        public Vertex(T data)
        {
            this.data = data;

            this.edges = new LinkedList<Vertex<T>>();
        }

        public void AddEdge(Vertex<T> vertex)
        {
            if (!edges.Contains(vertex))
            {
                edges.Add(vertex);
            }
        }

        public void RemoveEdge(Vertex<T> vertex)
        {
            edges.Remove(vertex);
        }

        public void RemoveAllEdges()
        {
            edges.Clear();
        }

        public T Data {
            get { return data; }
        }

        public LinkedList<Vertex<T>> Edges
        {
            get { return edges; }
        }

        public int EdgesCount
        {
            get { return edges.Count; }
        }

        public override string ToString()
        {
            return data.ToString();
        }
    }
}
