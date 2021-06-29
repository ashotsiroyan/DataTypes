using System.Collections;
using System.Collections.Generic;

namespace DataTypes
{
    public class LinkedList<T>: IEnumerable<T>
    {
        private LinkedListNode<T> head;
        private LinkedListNode<T> tail;
        private int count;

        public void Add(T data)
        {
            LinkedListNode<T> node = new LinkedListNode<T>(data);

            if (head == null)
                head = node;
            else
                tail.Next = node;

            tail = node;

            count++;
        }

        public void AddFirst(T data)
        {
            LinkedListNode<T> node = new LinkedListNode<T>(data);

            node.Next = head;
            head = node;

            if (count == 0)
                tail = head;

            count++;
        }

        public bool AddAfter(LinkedListNode<T> node, T data)
        {
            if (node != null)
            {
                if (Find(node) != null)
                {
                    LinkedListNode<T> _node = new LinkedListNode<T>(data);

                    if (node.Next != null)
                        _node.Next = node.Next;

                    node.Next = _node;

                    count++;
                    return true;
                }
                else
                    return false;
            }
            else
            {
                AddFirst(data);
                return true;
            }
        }

        public bool Remove(T data)
        {
            LinkedListNode<T> current = head;
            LinkedListNode<T> previous = null;

            while (current != null)
            {
                if (current.Data.Equals(data))
                {
                    if (previous != null)
                    {
                        previous.Next = current.Next;

                        if (current.Next == null)
                            tail = previous;
                    }
                    else
                    {
                        head = head.Next;

                        if (head == null)
                            tail = null;
                    }

                    count--;

                    return true;
                }

                previous = current;
                current = current.Next;
            }

            return false;
        }

        public bool Remove(LinkedListNode<T> node)
        {
            LinkedListNode<T> current = head;
            LinkedListNode<T> previous = null;

            while (current != null)
            {
                if (current == node)
                {
                    if (previous != null)
                    {
                        previous.Next = current.Next;

                        if (current.Next == null)
                            head = previous;
                    }
                    else
                    {
                        head = head.Next;

                        if (head == null)
                            tail = null;
                    }

                    count--;

                    return true;
                }

                previous = current;
                current = current.Next;
            }

            return false;
        }

        public LinkedListNode<T> Find(T data)
        {
            LinkedListNode<T> current = head;

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
            LinkedListNode<T> current = head;

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

        public LinkedListNode<T> Head
        {
            get { return head; }
        }

        public LinkedListNode<T> Tail
        {
            get { return tail; }
        }

        public int Count
        {
            get { return count; }
        }

        public void Clear()
        {
            head = null;
            tail = null;
            count = 0;
        }

        public bool IsEmpty {
            get { return count == 0; }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)this).GetEnumerator();
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            LinkedListNode<T> current = head;
            while (current != null)
            {
                yield return current.Data;
                current = current.Next;
            }
        }
    }
}
