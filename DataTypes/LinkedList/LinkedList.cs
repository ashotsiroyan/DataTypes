using System.Collections;
using System.Collections.Generic;

namespace DataTypes
{
    public class LinkedList<T>: IEnumerable<T>
    {
        private LinkedListNode<T> head;
        private LinkedListNode<T> tail;
        private int count;

        public LinkedListNode<T> Add(T data)
        {
            LinkedListNode<T> node = new LinkedListNode<T>(data);

            Add(node);

            return node;
        }

        public void Add(LinkedListNode<T> node)
        {
            if (head == null)
                head = node;
            else
                tail.Next = node;

            tail = node;

            count++;
        }

        public LinkedListNode<T> AddFirst(T data)
        {
            LinkedListNode<T> node = new LinkedListNode<T>(data);

            AddFirst(node);

            return node;
        }

        public void AddFirst(LinkedListNode<T> node)
        {
            node.Next = head;
            head = node;

            if (count == 0)
                tail = head;

            count++;
        }

        public LinkedListNode<T> AddAfter(LinkedListNode<T> previous, T data)
        {
            LinkedListNode<T> node = new LinkedListNode<T>(data);

            AddAfter(previous, node);

            return node;
        }

        public void AddAfter(LinkedListNode<T> previous, LinkedListNode<T> node)
        {
            if (previous != null)
            {
                node.Next = previous.Next;
                previous.Next = node;

                if (node.Next == null)
                    tail = node;

                count++;
            }
            else
            {
                AddFirst(node);
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

        public bool Remove(LinkedListNode<T> previous, LinkedListNode<T> node)
        {
            if (previous.Next == node)
            {
                if (previous != null)
                {
                    previous.Next = node.Next;

                    if (node.Next == null)
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

        public LinkedListNode<T> MoveToFrontFind(T data)
        {
            LinkedListNode<T> previous = null;
            LinkedListNode<T> current = head;

            while (current != null)
            {
                if (current.Data.Equals(data))
                {
                    if (previous != null)
                    {
                        LinkedListNode<T> temp = current;
                        Remove(previous, current);
                        AddAfter(null, temp);

                        return temp;
                    }

                    return current;
                }

                previous = current;
                current = current.Next;
            }

            return null;
        }

        public LinkedListNode<T> TranspositionFind(T data)
        {
            LinkedListNode<T> p = null;
            LinkedListNode<T> q = null;
            LinkedListNode<T> current = head;

            while (current != null)
            {
                if (current.Data.Equals(data))
                {
                    if (p != null)
                    {
                        LinkedListNode<T> temp = current;
                        Remove(p, current);
                        AddAfter(q, temp);

                        return temp;
                    }

                    return current;
                }

                q = p;
                p = current;
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

        public bool Contains (LinkedListNode<T> node)
        {
            LinkedListNode<T> current = head;

            while (current != null)
            {
                if (current == node)
                    return true;

                current = current.Next;
            }

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
