using System.Collections.Generic;

namespace DataTypes
{
    public class Graph<T>
    {
        private List<Vertex<T>> vertices;

        public Graph()
        {
            vertices = new List<Vertex<T>>();
        }

        public Graph(T[] vertices)
        {
            this.vertices = new List<Vertex<T>>();

            for (int i = 0; i < vertices.Length; ++i)
                this.vertices.Add(new Vertex<T>(vertices[i]));
        }

        public bool AddNode(T data)
        {
            if (FindNode(data) == null)
            {
                vertices.Add(new Vertex<T>(data));
                return true;
            }
            else
                return false;
        }

        public bool RemoveNode(T data)
        {
            Vertex<T> node = FindNode(data);

            if (node != null)
            {
                RemoveEdge(data);

                vertices.Remove(node);

                return true;
            }
            else
                return false;
        }

        public bool AddEdge(T from, T to)
        {
            Vertex<T> nodeFrom = FindNode(from);
            Vertex<T> nodeTo = FindNode(to);

            if (nodeFrom == null || nodeTo == null)
                return false;
            else
            {
                nodeFrom.AddEdge(nodeTo);
                return true;
            }
        }

        public bool RemoveEdge(T to)
        {
            Vertex<T> nodeTo = FindNode(to);

            if (nodeTo == null)
                return false;
            else
            {
                foreach (Vertex<T> node in vertices)
                {
                    if (node.Edges.Contains(nodeTo))
                        node.RemoveEdge(nodeTo);
                }
            }

            return true;
        }

        public bool RemoveEdge(T from, T to)
        {
            Vertex<T> nodeFrom = FindNode(from);
            Vertex<T> nodeTo = FindNode(to);

            if (nodeFrom == null || nodeTo == null)
                return false;
            else if (!nodeFrom.Edges.Contains(nodeTo))
                return false;
            else
            {
                nodeFrom.RemoveEdge(nodeTo);
                return true;
            }
        }

        public IList<Vertex<T>> Vertices
        {
            get { return vertices.AsReadOnly(); }
        }

        public int Size
        {
            get { return vertices.Count; }
        }

        public bool[] DFS(T node)
        {
            bool[] visited = new bool[vertices.Count];

            int index = FindNodeIndex(node);

            if (index != -1)
                RecursionDFS(visited, index);

            return visited;
        }

        private void RecursionDFS(bool[] visited, int node)
        {
            visited[node] = true;

            foreach (Vertex<T> vertex in vertices[node].Edges)
            {
                int index = FindNodeIndex(vertex);

                if (!visited[index])
                    RecursionDFS(visited, index);
            }
        }

        public bool[] StackDFS(T node)
        {
            Stack<int> stack = new Stack<int>(vertices.Count);
            bool[] visited = new bool[vertices.Count];

            for (int i = 0; i < vertices.Count; ++i)
                visited[i] = false;

            int index = FindNodeIndex(node);

            if (index != -1)
            {
                stack.Push(index);

                while (!stack.IsEmpty)
                {
                    int c = stack.Pop();

                    visited[c] = true;

                    foreach (Vertex<T> vertex in vertices[c].Edges)
                    {
                        index = FindNodeIndex(vertex);

                        if (!visited[index])
                            stack.Push(index);
                    }
                }
            }

            return visited;
        }

        public bool[] NoDupStackDFS(T node)
        {
            Stack<int> stack = new Stack<int>(vertices.Count);
            bool[] instack = new bool[vertices.Count];
            bool[] visited = new bool[vertices.Count];

            for (int i = 0; i < vertices.Count; ++i)
            {
                instack[i] = false;
                visited[i] = false;
            }

            int index = FindNodeIndex(node);

            if (index != -1)
            {
                stack.Push(index);
                instack[index] = true;

                while (!stack.IsEmpty)
                {
                    int c = stack.Pop();

                    instack[c] = false;
                    visited[c] = true;

                    foreach (Vertex<T> vertex in vertices[c].Edges)
                    {
                        index = FindNodeIndex(node);

                        if (!visited[index] && !instack[index])
                        {
                            stack.Push(index);
                            instack[index] = true;
                        }
                    }
                }
            }

            return visited;
        }

        public bool[] BFS(T node)
        {
            Queue<int> queue = new Queue<int>(vertices.Count);
            bool[] inqueue = new bool[vertices.Count];
            bool[] visited = new bool[vertices.Count];

            for (int i = 0; i < vertices.Count; ++i)
            {
                inqueue[i] = false;
                visited[i] = false;
            }

            int index = FindNodeIndex(node);

            if (index != -1)
            {
                queue.Enqueue(index);
                inqueue[index] = true;

                while (!queue.IsEmpty)
                {
                    int c = queue.Dequeue();

                    inqueue[c] = false;
                    visited[c] = true;

                    foreach (Vertex<T> vertex in vertices[c].Edges)
                    {
                        index = FindNodeIndex(node);

                        if (!visited[index] && !inqueue[index])
                        {
                            queue.Enqueue(index);
                            inqueue[index] = true;
                        }
                    }
                }
            }

            return visited;
        }

        public bool[,] toMatrix()
        {
            bool[,] matrix = new bool[vertices.Count, vertices.Count];

            for (int i = 0; i < vertices.Count; ++i)
            {
                foreach (Vertex<T> vertex in vertices[i].Edges)
                {
                    int j = FindNodeIndex(vertex);

                    matrix[i, j] = true;
                }
            }

            return matrix;
        }

        public LinkedList<T> TopologiclSort()
        {
            bool[] visited = new bool[vertices.Count];
            LinkedList<T> sorted = new LinkedList<T>();

            for (int i = 0; i < vertices.Count; ++i)
            {
                if (!visited[i])
                    DFSTopologiclSort(visited, sorted, i);
            }

            return sorted;
        }

        private void DFSTopologiclSort(bool[] visited, LinkedList<T> sorted, int index)
        {
            visited[index] = true;

            foreach (Vertex<T> vertex in vertices[index].Edges)
            {
                int vertexIndex = FindNodeIndex(vertex);

                if (!visited[vertexIndex])
                {
                    DFSTopologiclSort(visited, sorted, vertexIndex);
                }
            }

            sorted.AddFirst(vertices[index].Data);
        }

        private Vertex<T> FindNode(T node)
        {
            foreach (Vertex<T> vertex in vertices)
            {
                if (vertex.Data.Equals(node))
                {
                    return vertex;
                }
            }

            return null;
        }

        private int FindNodeIndex(Vertex<T> node)
        {
            int i = 0;

            foreach (Vertex<T> vertex in vertices)
            {
                if (vertex == node)
                {
                    return i;
                }

                ++i;
            }

            return -1;
        }

        private int FindNodeIndex(T node)
        {
            int i = 0;

            foreach (Vertex<T> vertex in vertices)
            {
                if (vertex.Data.Equals(node))
                {
                    return i;
                }

                ++i;
            }

            return -1;
        }

        public override string ToString()
        {
            bool[,] matrix = toMatrix();
            string graphString = "    ";

            for (int i = 0; i < vertices.Count; ++i)
            {
                graphString += " " + vertices[i].Data + " ";
            }

            graphString += "\n\n";

            for (int i = 0; i < vertices.Count; ++i)
            {
                graphString += vertices[i].Data + " | ";

                for (int j = 0; j < vertices.Count; ++j)
                {
                    graphString += " " + (matrix[i,j]?"1":"0") + " ";
                }

                graphString += "\n";
            }

            return graphString;
        }
    }
}