﻿using System;
using System.Collections.Generic;

namespace DataTypes
{
    public class Graph<T>
    {
        private List<Vertex<T>> Vertices;

        public Graph()
        {
            Vertices = new List<Vertex<T>>();
        }

        public Graph(T[] Nodes)
        {
            Vertices = new List<Vertex<T>>();

            for (int i = 0; i < Nodes.Length; ++i)
                Vertices.Add(new Vertex<T>(Nodes[i]));
        }

        public bool AddNode(T data)
        {
            if (FindNode(data) == null)
            {
                Vertices.Add(new Vertex<T>(data));
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

                Vertices.Remove(node);

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
                foreach (Vertex<T> node in Vertices)
                {
                    if (node.Neighbors.Contains(nodeTo))
                        node.Neighbors.Remove(nodeTo);
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
            else if (!nodeFrom.Neighbors.Contains(nodeTo))
                return false;
            else
            {
                nodeFrom.Neighbors.Remove(nodeTo);
                return true;
            }
        }

        public List<Vertex<T>> Nodes
        {
            get { return Vertices; }
        }

        public int Size
        {
            get { return Vertices.Count; }
        }

        public void DFS(T node, bool[] visited)
        {
            int index = FindNodeIndex(node);

            if (index != -1)
            {
                visited[index] = true;

                foreach (Vertex<T> vertex in Vertices[index].Neighbors)
                {
                    if (!visited[FindNodeIndex(vertex.Data)])
                        DFS(vertex.Data, visited);
                }
            }
        }

        public bool[] StackDFS(T node)
        {
            Stack<int> stack = new Stack<int>(Vertices.Count);
            bool[] visited = new bool[Vertices.Count];

            for (int i = 0; i < Vertices.Count; ++i)
                visited[i] = false;

            int index = FindNodeIndex(node);

            if (index != -1)
            {
                stack.Push(index);

                while (!stack.IsEmpty())
                {
                    int c = stack.Pop();

                    visited[c] = true;

                    foreach (Vertex<T> vertex in Vertices[c].Neighbors)
                    {
                        index = FindNodeIndex(vertex.Data);

                        if (!visited[index])
                            stack.Push(index);
                    }
                }
            }

            return visited;
        }

        public bool[] NoDupStackDFS(T node)
        {
            Stack<int> stack = new Stack<int>(Vertices.Count);
            bool[] instack = new bool[Vertices.Count];
            bool[] visited = new bool[Vertices.Count];

            for (int i = 0; i < Vertices.Count; ++i)
            {
                instack[i] = false;
                visited[i] = false;
            }

            int index = FindNodeIndex(node);

            if (index != -1)
            {
                stack.Push(index);
                instack[index] = true;

                while (!stack.IsEmpty())
                {
                    int c = stack.Pop();

                    instack[c] = false;
                    visited[c] = true;

                    foreach (Vertex<T> vertex in Vertices[c].Neighbors)
                    {
                        index = FindNodeIndex(vertex.Data);

                        if (!visited[index] && !instack[index])
                        {
                            stack.Push(index);
                            instack[c] = true;
                        }
                    }
                }
            }

            return visited;
        }

        public bool[] BFS(T node)
        {
            Queue<int> queue = new Queue<int>(Vertices.Count);
            bool[] inqueue = new bool[Vertices.Count];
            bool[] visited = new bool[Vertices.Count];

            for (int i = 0; i < Vertices.Count; ++i)
            {
                inqueue[i] = false;
                visited[i] = false;
            }

            int index = FindNodeIndex(node);

            if (index != -1)
            {
                queue.Enqueue(index);
                inqueue[index] = true;

                while (!queue.IsEmpty())
                {
                    int c = queue.Dequeue();

                    inqueue[c] = false;
                    visited[c] = true;

                    foreach (Vertex<T> vertex in Vertices[c].Neighbors)
                    {
                        index = FindNodeIndex(vertex.Data);

                        if (!visited[index] && !inqueue[index])
                        {
                            queue.Enqueue(index);
                            inqueue[c] = true;
                        }
                    }
                }
            }

            return visited;
        }

        private Vertex<T> FindNode(T node)
        {
            foreach (Vertex<T> vertex in Vertices)
            {
                if (vertex.Data.Equals(node))
                {
                    return vertex;
                }
            }

            return null;
        }

        private int FindNodeIndex(T node)
        {
            int i = 0;

            foreach (Vertex<T> vertex in Vertices)
            {
                if (vertex.Data.Equals(node))
                {
                    return i;
                }

                ++i;
            }

            return -1;
        }
    }
}