using System;
using System.Collections;
using System.Collections.Generic;

namespace Queue
{
    public class Queue<T>: IEnumerable<T>
    {
        private T[] items;
        private int head;
        private int tail;
        private int count;

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
            if (count == items.Length)
                throw new InvalidOperationException("Queue is full");

            if(tail == items.Length)
                tail = 0;

            items[tail++] = item;

            ++count;
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

            --count;

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

            count = 0;
        }

        public int Count
        {
            get { return count; }
        }

        public bool IsEmpty()
        {
            return count == 0;
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
