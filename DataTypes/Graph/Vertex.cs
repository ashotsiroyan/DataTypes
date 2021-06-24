namespace DataTypes
{
    public class Vertex<T>
    {
        public T Data { get; set; }
        public LinkedList<int> Neighbors { get; private set; }

        public Vertex(T data)
        {
            Data = data;

            Neighbors = new LinkedList<int>();
        }

        public int NeighborsCount
        {
            get { return Neighbors.Count; }
        }

        public void AddEdge(int index)
        {
            if (!Neighbors.Contains(index))
            {
                Neighbors.Add(index);
            }
        }

        public void RemoveEdge(int index)
        {
            Neighbors.Remove(index);
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
