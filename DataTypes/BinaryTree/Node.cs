namespace DataTypes
{
    public class BinaryTreeNode<T>
    {
        public BinaryTreeNode(T data)
        {
            Data = data;
        }

        public T Data { get; set; }
        public BinaryTreeNode<T> Left { get; set; }
        public BinaryTreeNode<T> Right { get; set; }
    }
}
