using System.Collections.Generic;

namespace DataTypes
{
    public class PriorityQueue<T>
    {
        private List<PriorityQueueNode<T>> heap;

        public PriorityQueue()
        {
            heap = new List<PriorityQueueNode<T>>();
        }

        public void Insert(T data, int priority)
        {
            Insert(new PriorityQueueNode<T>(data, priority));
        }

        public void Insert(PriorityQueueNode<T> node)
        {
            heap.Add(node);

            int current = Size - 1;

            while (current != 0 && heap[current].Priority < heap[FindParent(current)].Priority)
            {
                int parent = FindParent(current);
                Exchange(current, parent);
                current = parent;
            }
        }

        public PriorityQueueNode<T> ExtractMin()
        {
            if (!IsEmpty)
            {
                PriorityQueueNode<T> node = heap[0];

                heap[0] = heap[Size - 1];
                heap.RemoveAt(Size - 1);

                int current = 0;

                while (HasChildren(current))
                {
                    int min = MinChild(current);

                    if (heap[current].Priority < heap[min].Priority)
                        return node;

                    Exchange(current, min);
                    current = min;
                }

                return node;
            }
            else
                return null;
        }

        public int FindParent(T data)
        {
            int i = 0;

            foreach (PriorityQueueNode<T> current in heap)
            {
                if (data.Equals(current.Data))
                    return (i - 1) / 2;
            }

            return -1;
        }

        public int FindParent(int index)
        {
            if (Size > index)
                return (index - 1) / 2;

            return -1;
        }

        public bool HasChildren(int index)
        {
            if (Size > 2 * index + 1 || Size > 2 * index + 2)
                return true;

            return false;
        }

        public int MinChild(int index)
        {
            if (!HasChildren(index))
                return -1;
            else if (Size <= 2 * index + 2)
                return index * 2 + 1;
            else
            {
                if (heap[index * 2 + 1].Priority < heap[index * 2 + 2].Priority)
                    return index * 2 + 1;
                else
                    return index * 2 + 2;
            }
        }

        public int Size
        {
            get
            {
                return heap.Count;
            }
        }

        public bool IsEmpty
        {
            get { return Size == 0; }
        }

        private void Exchange(int x, int y)
        {
            PriorityQueueNode<T> t = heap[x];
            heap[x] = heap[y];
            heap[y] = t;
        }
    }
}