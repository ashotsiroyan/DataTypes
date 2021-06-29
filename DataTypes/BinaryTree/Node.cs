using System;

namespace DataTypes
{
    public class BinaryTreeNode<T>
        where T : IComparable
    {
        public BinaryTreeNode()
        {
        }

        public BinaryTreeNode(T data)
        {
            Data = data;
        }

        public BinaryTreeNode(BinaryTreeNode<T> left, BinaryTreeNode<T> right)
        {
            Left = left;
            Right = right;
        }

        public T Data { get; set; }
        public BinaryTreeNode<T> Left;
        public BinaryTreeNode<T> Right;
    }
}
