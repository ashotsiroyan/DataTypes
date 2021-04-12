using System;
using System.Collections;
using System.Collections.Generic;

namespace Stack
{
    public class Stack<T>: IEnumerable<T>
    {
        private T[] items;
        private int count;

        private const int n = 10;


        public Stack()
        {
            items = new T[n];
        }

        public Stack(int length)
        {
            items = new T[length];
        }

        public bool IsEmpty()
        {
            return count == 0;
        }

        public int Count
        {
            get { return count; }
        }

        public void Push(T item)
        {
            if (count == items.Length)
                throw new InvalidOperationException("Stack is full");

            items[count++] = item;
        }

        public T Pop()
        {
            if (IsEmpty())
                throw new InvalidOperationException("Stack is empty");

            T item = items[--count];

            items[count] = default(T);

            return item;
        }

        public T Top()
        {
            return items[count - 1];
        }

        public void Clear()
        {
            for (int i = count - 1; i >= 0; --i)
            {
                items[i] = default(T);
            }

            count = 0;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)this).GetEnumerator();
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            for (int i = count - 1; i >= 0; --i)
            {
                yield return items[i];
            }
        }
    }
}
