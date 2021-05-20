namespace DataTypes
{
    interface BinaryTree<T>
    {
        BinaryTreeNode<T> Root { get; }
        int Size { get; }
        void Insert(T data);
        void Insert(BinaryTreeNode<T> node);
        BinaryTreeNode<T> Find(T data);
        BinaryTreeNode<T> FindParent(BinaryTreeNode<T> node);
        bool Delete(T data);
        void Clear();
    }
}
