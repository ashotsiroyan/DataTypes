namespace DataTypes
{
    public class PriorityQueueNode<T>
    {
        public PriorityQueueNode()
        {
        }

        public PriorityQueueNode(int priority)
        {
            Priority = priority;
        }

        public PriorityQueueNode(T data, int priority)
        {
            Data = data;
            Priority = priority;
        }

        public T Data { get; set; }
        public int Priority { get; set; }
        public PriorityQueueNode<T> Left;
        public PriorityQueueNode<T> Right;

        public void SetFromNode(PriorityQueueNode<T> node)
        {
            Data = node.Data;
            Priority = node.Priority;
        }
    }
}
