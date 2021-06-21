using System;

namespace DataTypes
{
    public struct Pair<T>
        where T : IComparable
    {
        public BinaryTreeNode<T> parent;
        public BinaryTreeNode<T> child;
    }

    interface IBinaryTree<T>
        where T : IComparable
    {
        BinaryTreeNode<T> Root { get; }
        int Size { get; }
        void Insert(T data);
        void Insert(BinaryTreeNode<T> node);
        BinaryTreeNode<T> Find(T data);
        BinaryTreeNode<T> FindParent(BinaryTreeNode<T> node);
        Pair<T> FindPair(T data);
        bool Delete(T data);
        void Clear();
        LinkedList<T> TraverseInOrder();
        LinkedList<T> TraversePreOrder();
        LinkedList<T> TraversePostOrder();
    }
}
