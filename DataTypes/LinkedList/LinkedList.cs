using System.Collections;
using System.Collections.Generic;

namespace DataTypes
{
    public class LinkedList<T>: IEnumerable<T>
    {
        public LinkedListNode<T> Head { get; private set; }
        public LinkedListNode<T> Tail { get; private set; }
        public int Count { get; private set; }

        public void Add(T data)
        {
            LinkedListNode<T> node = new LinkedListNode<T>(data);

            if (Head == null)
                Head = node;
            else
                Tail.Next = node;

            Tail = node;

            Count++;
        }

        public void AddFirst(T data)
        {
            LinkedListNode<T> node = new LinkedListNode<T>(data);

            node.Next = Head;
            Head = node;

            if (Count == 0)
                Tail = Head;

            Count++;
        }

        public void AddAfter(LinkedListNode<T> node, T data)
        {
            if (node != null)
            {
                LinkedListNode<T> _node = new LinkedListNode<T>(data);

                if (node.Next != null)
                    _node.Next = node.Next;

                node.Next = _node;

                Count++;
            }
            else
                AddFirst(data);
        }

        public bool Remove(T data)
        {
            LinkedListNode<T> current = Head;
            LinkedListNode<T> previous = null;

            while (current != null)
            {
                if (current.Data.Equals(data))
                {
                    if (previous != null)
                    {
                        previous.Next = current.Next;

                        if (current.Next == null)
                            Tail = previous;
                    }
                    else
                    {
                        Head = Head.Next;

                        if (Head == null)
                            Tail = null;
                    }

                    Count--;

                    return true;
                }

                previous = current;
                current = current.Next;
            }

            return false;
        }

        public bool Remove(LinkedListNode<T> node)
        {
            LinkedListNode<T> current = Head;
            LinkedListNode<T> previous = null;

            while (current != null)
            {
                if (current == node)
                {
                    if (previous != null)
                    {
                        previous.Next = current.Next;

                        if (current.Next == null)
                            Tail = previous;
                    }
                    else
                    {
                        Head = Head.Next;

                        if (Head == null)
                            Tail = null;
                    }

                    Count--;

                    return true;
                }

                previous = current;
                current = current.Next;
            }

            return false;
        }

        public LinkedListNode<T> Find(T data)
        {
            LinkedListNode<T> current = Head;

            while (current != null)
            {
                if (current.Data.Equals(data))
                    return current;

                current = current.Next;
            }

            return null;
        }

        public LinkedListNode<T> Find(LinkedListNode<T> node)
        {
            LinkedListNode<T> current = Head;

            while (current != null)
            {
                if (current == node)
                    return current;

                current = current.Next;
            }

            return null;
        }

        public bool Contains(T data)
        {
            if (Find(data) != null)
                return true;

            return false;
        }

        public void Clear()
        {
            Head = null;
            Tail = null;
            Count = 0;
        }

        public bool IsEmpty {
            get { return Count == 0; }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)this).GetEnumerator();
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            LinkedListNode<T> current = Head;
            while (current != null)
            {
                yield return current.Data;
                current = current.Next;
            }
        }
    }
}
