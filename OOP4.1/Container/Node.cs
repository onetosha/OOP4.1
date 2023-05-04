namespace OOP3
{
    public class Node<T>
    {
        public T Data { get; set; }
        public Node<T>? Next { get; set; }
        public int index;
        public Node(T data)
        {
            Data = data;
        }
    }
}
