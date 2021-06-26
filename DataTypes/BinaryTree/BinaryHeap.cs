using System;
using System.Collections.Generic;

namespace DataTypes
{
    public class BinaryHeap<T>
        where T: IComparable
    {
        private List<T> heap;

        public BinaryHeap()
        {
            heap = new List<T>();
        }

        public void Insert(T node)
        {
            heap.Add(node);

            int current = Size - 1;

            while (current != 0 && heap[current].CompareTo(heap[FindParentIndex(current)]) < 0)
            {
                int parent = FindParentIndex(current);
                Swap(current, parent);
                current = parent;
            }
        }

        public T ExtractMin()
        {
            if (!IsEmpty)
            {
                T node = heap[0];

                heap[0] = heap[Size - 1];
                heap.RemoveAt(Size - 1);

                int current = 0;

                while (HasChildren(current))
                {
                    int min = MinChildIndex(current);

                    if (heap[current].CompareTo(heap[min]) < 0)
                        return node;

                    Swap(current, min);
                    current = min;
                }

                return node;
            }
            else
                return default(T);
        }

        public T Peek()
        {
            if (!IsEmpty)
                return heap[0];
            else
                return default(T);
        }

        public T FindParent(T node)
        {
            int i = 0;

            foreach (T current in heap)
            {
                if (node.Equals(current))
                    return heap[FindParentIndex(i)];
            }

            return default(T);
        }

        public int FindParentIndex(int index)
        {
            if(Size > index)
                return (index - 1) / 2;

            return -1;
        }

        public bool HasChildren(int index)
        {
            if (Size > 2 * index + 1 || Size > 2 * index + 2)
                return true;

            return false;
        }

        public int MinChildIndex(int index)
        {
            if (!HasChildren(index))
                return -1;
            else if (Size <= 2 * index + 2)
                return index * 2 + 1;
            else
            {
                int compare = heap[index * 2 + 1].CompareTo(heap[index * 2 + 2]);
                if (compare < 0)
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

        private void Swap(int x, int y)
        {
            T t = heap[x];
            heap[x] = heap[y];
            heap[y] = t;
        }
    }
}