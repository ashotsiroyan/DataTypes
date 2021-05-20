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
                AddNode(node, root);

            ++size;
        }

        public void Insert(T data, int priority)
        {
            Insert(new PriorityQueueNode<T>(data, priority));
        }

        public PriorityQueueNode<T> ExtractMin()
        {
            PriorityQueueNode<T> current = root;
            PriorityQueueNode<T> parent = null;

            while (current.Left != null)
            {
                parent = current;
                current = current.Left;
            }

            if (parent == null)
                DeleteNode(ref root);
            else if (parent.Left == current)
                DeleteNode(ref parent.Left);
            else
                DeleteNode(ref parent.Right);

            --size;

            return current;
        }

        public PriorityQueueNode<T> ExtractMax()
        {
            PriorityQueueNode<T> current = root;
            PriorityQueueNode<T> parent = null;

            while (current.Right != null)
            {
                parent = current;
                current = current.Right;
            }

            if (parent == null)
                DeleteNode(ref root);
            else if (parent.Left == current)
                DeleteNode(ref parent.Left);
            else
                DeleteNode(ref parent.Right);

            --size;

            return current;
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


        public bool Delete(PriorityQueueNode<T> node)
        {
            PriorityQueueNode<T> parent = FindParent(node);

            if (node == null)
                return false;

            if (parent == null)
                DeleteNode(ref root);
            else if (parent.Left == node)
                DeleteNode(ref parent.Left);
            else
                DeleteNode(ref parent.Right);

            --size;

            return true;
        }

        public void Clear()
        {
            root = null;
            size = 0;
        }

        public bool isEmpty
        {
            get { return size == 0; }
        }

        public PriorityQueueNode<T> Root { get { return root; } }

        public int Size { get { return size; } }

        public PriorityQueueNode<T> Min
        {
            get
            {
                PriorityQueueNode<T> current = root;

                while (current.Left != null)
                {
                    current = current.Left;
                }

                return current;
            }
        }

        public PriorityQueueNode<T> Max
        {
            get
            {
                PriorityQueueNode<T> current = root;

                while (current.Right != null)
                {
                    current = current.Right;
                }

                return current;
            }
        }

        private void DeleteNode(ref PriorityQueueNode<T> node)
        {
            if (node.Left == null)
            {
                node = node.Right;
            }
            else if (node.Right == null)
            {
                node = node.Left;
            }
            else
            {
                PriorityQueueNode<T> current;

                for (current = node.Left; current.Right != null; current = current.Right)
                    continue;

                current.Right = node.Right;
                node = node.Left;
            }
        }

        public LinkedList<T> TraverseMin()
        {
            LinkedList<T> list = new LinkedList<T>();
            TraverseInOrder(root, list, true);

            return list;
        }

        public LinkedList<T> TraverseMax()
        {
            LinkedList<T> list = new LinkedList<T>();
            TraverseInOrder(root, list, false);

            return list;
        }

        private void TraverseInOrder(PriorityQueueNode<T> node, LinkedList<T> list, bool min)
        {
            if (node != null)
            {
                TraverseInOrder(min ? node.Left : node.Right, list, min);
                list.Add(node.Data);
                TraverseInOrder(min ? node.Right : node.Left, list, min);
            }
        }

        private void AddNode(PriorityQueueNode<T> node, PriorityQueueNode<T> root)
        {
            if (node.Priority < root.Priority)
            {
                if (root.Left == null)
                {
                    root.Left = node;
                }
                else
                {
                    AddNode(node, root.Left);
                }
            }
            else
            {
                if (root.Right == null)
                {
                    root.Right = node;
                }
                else
                {
                    AddNode(node, root.Right);
                }
            }
        }

        public override string ToString()
        {
            LinkedList<T> list = TraverseMin();
            string treeString = "";

            foreach (T data in list)
            {
                treeString += data + " ";
            }

            return treeString;
        }
    }
}