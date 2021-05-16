namespace DataTypes
{
    public class PriorityQueue<T>
    {
        private PriorityQueueNode<T> root;
        private int size;

        public void Insert(PriorityQueueNode<T> node)
        {
            if (root == null)
                root = node;
            else
                Add(node, ref root);

            ++size;

            while (node != root && node.Priority < FindParent(node).Priority)
            {
                PriorityQueueNode<T> parent = FindParent(node);
                Exchange(ref node, ref parent);
                node = parent;
            }
        }

        public PriorityQueueNode<T> ExtractMin()
        {
            PriorityQueueNode<T> node = new PriorityQueueNode<T>(root.Data, root.Priority);
            PriorityQueueNode<T> lastNode = ExtractLast();
            PriorityQueueNode<T> current;

            if (!IsEmpty)
            {
                root.Data = lastNode.Data;
                root.Priority = lastNode.Priority;
                current = root;
            }
            else
                current = lastNode;

            while (HasChildren(current))
            {
                PriorityQueueNode<T> min = MinChild(current);

                if (current.Priority < min.Priority)
                    return node;

                Exchange(ref current, ref min);
                current = min;
            }

            return node;
        }

        public PriorityQueueNode<T> FindParent(PriorityQueueNode<T> node)
        {
            PriorityQueueNode<T> current = root;
            PriorityQueueNode<T> parent = null;

            while (current != null)
            {
                if (current == node)
                    return parent;

                parent = current;

                if (node.Priority < current.Priority)
                    current = current.Left;
                else
                    current = current.Right;
            }

            return null;
        }

        public bool HasChildren(PriorityQueueNode<T> node)
        {
            if (node.Left != null || node.Right != null)
                return true;

            return false;
        }

        public PriorityQueueNode<T> MinChild(PriorityQueueNode<T> node)
        {
            if (node.Left == null && node.Right == null)
                return null;
            else if (node.Left == null)
                return node.Right;
            else if (node.Right == null)
                return node.Left;
            else
            {
                if (node.Left.Priority < node.Right.Priority)
                    return node.Left;
                else
                    return node.Right;
            }
        }

        public PriorityQueueNode<T> Root
        {
            get { return root; }
        }

        public int Size
        {
            get { return size; }
        }

        public bool IsEmpty
        {
            get { return size == 0; }
        }

        public PriorityQueueNode<T> ExtractLast()
        {
            PriorityQueueNode<T> current = root;
            PriorityQueueNode<T> parent = null;

            while (HasChildren(current))
            {
                parent = current;
                current = MinChild(current);
            }

            if (current != root)
            {
                if (current == parent.Left)
                    parent.Left = null;
                else if (current == parent.Right)
                    parent.Right = null;
            }
            else
                root = null;

            --size;

            return current;
        }

        private void Add(PriorityQueueNode<T> node, ref PriorityQueueNode<T> tree)
        {
            if (tree == null)
            {
                tree = node;
            }
            else
            {
                if (node.Priority < tree.Priority)
                {
                    Add(node, ref tree.Left);
                }
                else
                {
                    Add(node, ref tree.Right);
                }
            }
        }

        private void Exchange(ref PriorityQueueNode<T> node1, ref PriorityQueueNode<T> node2)
        {
            T data = node1.Data;
            int priority = node1.Priority;

            node1.Data = node2.Data;
            node1.Priority = node2.Priority;

            node2.Data = data;
            node2.Priority = priority;
        }
    }
}
