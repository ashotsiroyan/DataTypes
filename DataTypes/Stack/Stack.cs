using System;
using System.Collections;
using System.Collections.Generic;

namespace DataTypes
{
    public class Stack<T>: IEnumerable<T>
    {
        private T[] items;
        public int Count { get; private set; }

        private const int n = 10;


        public Stack()
        {
            items = new T[n];
        }

        public Stack(int length)
        {
            items = new T[length];
        }

        public bool IsEmpty
        {
            get { return Count == 0; }
        }

        public void Push(T item)
        {
            if (Count == items.Length)
                throw new InvalidOperationException("Stack is full");

            items[Count++] = item;
        }

        public T Pop()
        {
            if (IsEmpty)
                throw new InvalidOperationException("Stack is empty");

            T item = items[--Count];

            items[Count] = default(T);

            return item;
        }

        public T Top()
        {
            return items[Count - 1];
        }

        public void Clear()
        {
            for (int i = Count - 1; i >= 0; --i)
            {
                items[i] = default(T);
            }

            Count = 0;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)this).GetEnumerator();
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            for (int i = Count - 1; i >= 0; --i)
            {
                yield return items[i];
            }
        }
    }
}
