using System;

namespace DataTypes
{
    public class AVLTree<T> : IBinaryTree<T>
        where T : IComparable
    {
        private BinaryTreeNode<T> root;
        private int size;

        public void Insert(T data)
        {
            BinaryTreeNode<T> node = new BinaryTreeNode<T>(data);

            Insert(node);
        }

        public void Insert(BinaryTreeNode<T> node)
        {
            if (root == null)
                root = node;
            else
                AddNode(node, ref root);

            ++size;
        }

        public BinaryTreeNode<T> Find(T data)
        {
            BinaryTreeNode<T> current = root;

            while (current != null)
            {
                int compare = data.CompareTo(current.Data);

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

                int compare = node.Data.CompareTo(current.Data);

                if (compare < 0)
                    current = current.Left;
                else if (compare > 0)
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
                int compare = data.CompareTo(pair.child.Data);

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

        public void Delete(T data)
        {
            root = Delete(root, data);
        }

        public void Clear()
        {
            root = null;
            size = 0;
        }

        public BinaryTreeNode<T> Root { get { return root; } }

        public int Size { get { return size; } }

        public LinkedList<T> TraverseInOrder()
        {
            LinkedList<T> list = new LinkedList<T>();
            TraverseInOrder(root, list);

            return list;
        }

        public LinkedList<T> TraversePreOrder()
        {
            LinkedList<T> list = new LinkedList<T>();
            TraversePreOrder(root, list);

            return list;
        }

        public LinkedList<T> TraversePostOrder()
        {
            LinkedList<T> list = new LinkedList<T>();
            TraversePostOrder(root, list);

            return list;
        }

        private void AddNode(BinaryTreeNode<T> node, ref BinaryTreeNode<T> root)
        {
            if (root == null)
            {
                root = node;
            }
            else
            {
                int compare = node.Data.CompareTo(root.Data);

                if (compare < 0)
                {
                    AddNode(node, ref root.Left);
                    balanceTree(ref root);
                }
                else if (compare > 0)
                {
                    AddNode(node, ref root.Right);
                    balanceTree(ref root);
                }
            }
        }

        private void balanceTree(ref BinaryTreeNode<T> node)
        {
            int b_factor = balanceFactor(node);

            if (b_factor > 1)
            {
                if (balanceFactor(node.Left) > 0)
                {
                    RotateLL(ref node);
                }
                else
                {
                    RotateLR(ref node);
                }
            }
            else if (b_factor < -1)
            {
                if (balanceFactor(node.Right) > 0)
                {
                    RotateRL(ref node);
                }
                else
                {
                    RotateRR(ref node);
                }
            }
        }

        private BinaryTreeNode<T> Delete(BinaryTreeNode<T> current, T data)
        {
            BinaryTreeNode<T> parent;

            if (current == null)
            { 
                return null;
            }
            else
            {
                int compare = data.CompareTo(current.Data);

                if (compare < 0)
                {
                    current.Left = Delete(current.Left, data);

                    if (balanceFactor(current) == -2)
                    {
                        if (balanceFactor(current.Right) <= 0)
                        {
                            RotateRR(ref current);
                        }
                        else
                        {
                            RotateRL(ref current);
                        }
                    }
                }
                else if (compare > 0)
                {
                    current.Right = Delete(current.Right, data);

                    if (balanceFactor(current) == 2)
                    {
                        if (balanceFactor(current.Left) >= 0)
                        {
                            RotateLL(ref current);
                        }
                        else
                        {
                            RotateLR(ref current);
                        }
                    }
                }
                else
                {
                    if (current.Right != null)
                    {
                        parent = current.Right;

                        while (parent.Left != null)
                        {
                            parent = parent.Left;
                        }

                        current.Data = parent.Data;
                        current.Right = Delete(current.Right, parent.Data);

                        if (balanceFactor(current) == 2)
                        {
                            if (balanceFactor(current.Left) >= 0)
                            {
                                RotateLL(ref current);
                            }
                            else { 
                                RotateLR(ref current); 
                            }
                        }
                    }
                    else
                    {
                        return current.Left;
                    }
                }
            }

            return current;
        }

        private int balanceFactor(BinaryTreeNode<T> current)
        {
            int l = getHeight(current.Left);
            int r = getHeight(current.Right);
            int b_factor = l - r;

            return b_factor;
        }

        private void RotateRR(ref BinaryTreeNode<T> parent)
        {
            BinaryTreeNode<T> pivot = parent.Right;
            parent.Right = pivot.Left;
            pivot.Left = parent;

            parent = pivot;
        }

        private void RotateLL(ref BinaryTreeNode<T> parent)
        {
            BinaryTreeNode<T> pivot = parent.Left;
            parent.Left = pivot.Right;
            pivot.Right = parent;

            parent = pivot;
        }

        private void RotateLR(ref BinaryTreeNode<T> parent)
        {
            BinaryTreeNode<T> pivot = parent.Left;
            RotateRR(ref pivot);
            RotateLL(ref parent);
        }

        private void RotateRL(ref BinaryTreeNode<T> parent)
        {
            BinaryTreeNode<T> pivot = parent.Right;
            RotateLL(ref pivot);
            RotateRR(ref parent);
        }

        private int getHeight(BinaryTreeNode<T> current)
        {
            int height = 0;

            if (current != null)
            {
                int l = getHeight(current.Left);
                int r = getHeight(current.Right);
                int m = l > r ? l : r;
                height = m + 1;
            }

            return height;
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

        private void TraversePreOrder(BinaryTreeNode<T> node, LinkedList<T> list)
        {
            if (node != null)
            {
                list.Add(node.Data);
                TraversePreOrder(node.Left, list);
                TraversePreOrder(node.Right, list);
            }
        }

        private void TraversePostOrder(BinaryTreeNode<T> node, LinkedList<T> list)
        {
            if (node != null)
            {
                TraversePostOrder(node.Left, list);
                TraversePostOrder(node.Right, list);
                list.Add(node.Data);
            }
        }
    }
}
