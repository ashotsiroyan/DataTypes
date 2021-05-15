namespace DataTypes
{
    public struct Pair<T>
    {
        public BinaryTreeNode<T> parent;
        public BinaryTreeNode<T> child;
    }

    public class BinaryTree<T>
    {
        private BinaryTreeNode<T> root;
        private int size;

        public void Add(T data)
        {
            BinaryTreeNode<T> node = new BinaryTreeNode<T>(data);

            if (root == null)
                root = node;
            else
                AddNode(node, root);

            ++size;
        }

        public BinaryTreeNode<T> Find(T data)
        {
            BinaryTreeNode<T> current = root;

            while (current != null)
            {
                int compare = string.Compare(data.ToString(), current.Data.ToString());

                if (compare < 0)
                    current = current.Left;
                else if (compare > 0)
                    current = current.Right;
                else
                    return current;
            }

            return null;
        }

        public BinaryTreeNode<T> FindParent(BinaryTreeNode<T> node)
        {
            BinaryTreeNode<T> current = root;
            BinaryTreeNode<T> parent = null;

            while (current != null)
            {
                if (current == node)
                    return parent;

                parent = current;

                int compare = string.Compare(node.Data.ToString(), current.Data.ToString());

                if (compare < 0)
                    current = current.Left;
                else if(compare > 0)
                    current = current.Right;
            }

            return null;
        }

        public Pair<T> FindPair(T data)
        {
            Pair<T> pair = new Pair<T>();
            pair.parent = null;
            pair.child = root;

            while (pair.child != null)
            {
                int compare = string.Compare(data.ToString(), pair.child.Data.ToString());

                if (compare < 0)
                {
                    pair.parent = pair.child;
                    pair.child = pair.child.Left;
                }
                else if (compare > 0)
                {
                    pair.parent = pair.child;
                    pair.child = pair.child.Right;
                }
                else
                    break;
            }

            return pair;
        }

        public bool Delete(T data)
        {
            Pair<T> pair = FindPair(data);

            if (pair.child == null)
                return false;

            if (pair.parent == null)
                DeleteNode(ref root);
            else if (pair.parent.Left == pair.child)
                DeleteNode(ref pair.parent.Left);
            else
                DeleteNode(ref pair.parent.Right);

            --size;

            return true;
        }

        public void Clear()
        {
            root = null;
            size = 0;
        }

        public BinaryTreeNode<T> Root { get { return root; } }

        public int Size { get { return size; } }

        private void DeleteNode(ref BinaryTreeNode<T> node)
        {
            BinaryTreeNode<T> current;

            if (node.Left == null)
            {
                current = node;
                node = node.Right;
                current = null;
            }
            else if (node.Right == null)
            {
                current = node;
                node = node.Left;
                current = null;
            }
            else
            {
                for (current = node.Left; current.Right != null; current = current.Right)
                    continue;

                current.Right = node.Right;
                current = node;
                node = node.Left;
                current = null;
            }
        }

        public LinkedList<T> Traverse()
        {
            LinkedList<T> list = new LinkedList<T>();
            TraverseInOrder(root, list);

            return list;
        }

        private void TraverseInOrder(BinaryTreeNode<T> node, LinkedList<T> list)
        {
            if (node != null)
            {
                TraverseInOrder(node.Left, list);
                list.Add(node.Data);
                TraverseInOrder(node.Right, list);
            }
        }

        private void AddNode(BinaryTreeNode<T> node, BinaryTreeNode<T> root)
        {
            int compare = string.Compare(node.Data.ToString(), root.Data.ToString());

            if (compare < 0)
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
            else if (compare > 0)
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
    }
}
