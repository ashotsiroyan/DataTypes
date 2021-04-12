using System;

namespace DataTypes
{
    public class LinkedListNode<T>
    {
        public LinkedListNode(T data)
        {
            Data = data;
        }

        public T Data { get; set; }
        public LinkedListNode<T> Next { get; set; }
    }
}
