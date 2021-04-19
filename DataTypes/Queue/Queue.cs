using System;
using System.Collections;
using System.Collections.Generic;

namespace DataTypes
{
    public class Queue<T>: IEnumerable<T>
    {
        private T[] items;
        private int head;
        private int tail;
        public int Count { get; private set; }

        private const int n = 10;

        public Queue()
        {
            items = new T[n];
        }

        public Queue(int length)
        {
            items = new T[length];
        }

        public void Enqueue(T item)
        {
            if (Count == items.Length)
                throw new InvalidOperationException("Queue is full");

            if(tail == items.Length)
                tail = 0;

            items[tail++] = item;

            ++Count;
        }

        public T Dequeue()
        {
            if (IsEmpty())
                throw new InvalidOperationException("Queue is empty");

            T item = items[head];
            items[head] = default(T);

            if (head == items.Length - 1)
                head = 0;
            else
                ++head;

            --Count;

            return item;
        }

        public T Peek()
        {
            return items[tail - 1];
        }

        public void Clear()
        {
            for (int i = 0; i < items.Length; ++i)
            {
                items[i] = default(T);
            }

            Count = 0;
        }

        public bool IsEmpty()
        {
            return Count == 0;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)this).GetEnumerator();
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            if (!IsEmpty())
            {
                int index = head;

                while (index != tail - 1)
                {
                    yield return items[index];

                    if (index++ == items.Length - 1)
                        index = 0;
                }

                if (index == tail - 1)
                    yield return items[index];
            }
        }
    }
}
