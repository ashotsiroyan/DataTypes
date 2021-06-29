using System;
using System.Collections.Generic;

namespace DataTypes
{
    public class BinaryHeap<T>
        where T : IComparable
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
            int parent = FindParentIndex(current);

            while (current != 0 && heap[current].CompareTo(heap[parent]) > 0)
            {
                Swap(current, parent);
                current = parent;
                parent = FindParentIndex(current);
            }
        }

        public T Extract()
        {
            if (!IsEmpty)
            {
                T node = heap[0];

                heap[0] = heap[Size - 1];
                heap.RemoveAt(Size - 1);

                int current = 0;

                while (HasChildren(current))
                {
                    int max = MaxChildIndex(current);

                    if (heap[current].CompareTo(heap[max]) > 0)
                        return node;

                    Swap(current, max);
                    current = max;
                }

                return node;
            }
            else
                return default(T);
        }

        public T FindParent(T node)
        {
            int i = 0;

            foreach (T current in heap)
            {
                if (node.Equals(current))
                {
                    if (i != 0)
                        return heap[FindParentIndex(i)];
                    else
                        break;
                }

                i++;
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

        public int MaxChildIndex(int index)
        {
            if (!HasChildren(index))
                return -1;
            else if (Size <= 2 * index + 2)
                return index * 2 + 1;
            else
            {
                int compare = heap[index * 2 + 1].CompareTo(heap[index * 2 + 2]);
                if (compare > 0)
                    return index * 2 + 1;
                else
                    return index * 2 + 2;
            }
        }

        public T Root
        {
            get
            {
                if (!IsEmpty)
                    return heap[0];
                else
                    return default(T);
            }
        }

        public int Size
        {
            get { return heap.Count; }
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