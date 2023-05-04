using System;
using System.Collections;

namespace OOP3
{
    public class Container<T> : IEnumerable<T>
    {
        Node<T> head;
        Node<T> tail;
        int count;
        public int Count { get { return count; } }
        public bool IsEmpty { get { return count == 0; } }
        public void Add(T data)
        {
            //Console.WriteLine($"Вызван метод Add({data})");
            Node<T> node = new Node<T>(data);

            if (head != null)
            {
                node.index = tail.index + 1;
                tail!.Next = node;
            }
            else
            {
                node.index = 0;
                head = node;
            }
            tail = node;
            count++;
        }
        public void AddFirst(T data)
        {
            //Console.WriteLine($"Вызван метод AddFirst({data})");
            Node<T> node = new Node<T>(data);
            node.Next = head;
            head = node;
            if (count == 0)
                tail = head;
            count++;
            Node<T> temp = head.Next; //Сдвиг индексов
            while (temp != null)
            {
                temp.index++;
                temp = temp.Next;
            }
        }
        public void Insert(T data, int _index)
        {
            //Console.WriteLine($"Вызван метод Insert({data}, {_index})");
            if (_index < 0 || _index > count)
            {
                throw new IndexOutOfRangeException("Insert: в метод подан некорректный индекс");
            }
            else
            {
                if (head == null)
                {
                    Node<T> node = new Node<T>(data);
                    head = node;
                    tail = node;
                }
                else if (_index == count)
                {
                    Node<T> node = new Node<T>(data);
                    node.index = _index;
                    tail!.Next = node;
                    tail = node;
                }
                else if (_index == 0)
                {
                    Node<T> node = new Node<T>(data);
                    node.index = 0;
                    node.Next = head;
                    head = node;
                    while (node.Next != null)
                    {
                        node.Next.index++;
                        node = node.Next;
                    }
                }
                else
                {
                    Node<T> node = head;
                    while (node.index != _index - 1)
                    {
                        node = node.Next;
                    }
                    Node<T> newNode = new Node<T>(data);
                    newNode.index = node.index;
                    newNode.Next = node.Next;
                    node.Next = newNode;
                    while (newNode != null)
                    {
                        newNode.index++;
                        newNode = newNode.Next;
                    }
                }
                count++;
            }
        }
        public bool Remove(T data)
        {
            //Console.WriteLine($"Вызван метод Remove({data})");
            Node<T>? current = head;
            Node<T>? previous = null;

            while (current != null && current.Data != null) 
            {
                if (current.Data.Equals(data))
                {
                    if (previous != null)
                    {
                        previous.Next = current.Next;
                        if (current.Next == null) 
                        {
                            tail = previous;
                        }
                        Node<T>? temp = previous.Next; //Сдвиг индексов
                        while (temp != null)
                        {
                            temp.index--;
                            temp = temp.Next;
                        }
                    }
                    else
                    {
                        head = head?.Next;
                        Node<T>? temp = head; //Сдвиг индексов
                        while (temp != null)
                        {
                            temp.index--;
                            temp = temp.Next;
                        }
                        if (head == null)
                        {
                            tail = null;
                        }
                    }
                    count--;
                    return true;
                }
                previous = current;
                current = current.Next;
            }
            return false;
        }
        public bool RemoveByIndex(int _index)
        {
            //Console.WriteLine($"Вызван метод RemoveByIndex({_index})");
            Node<T>? current = head;
            Node<T>? previous = null;

            while (current != null && current.Data != null)
            {
                if (current.index == _index)
                {
                    if (previous != null)
                    {
                        previous.Next = current.Next;
                        if (current.Next == null)
                        {
                            tail = previous;
                        }
                        Node<T>? temp = previous.Next; //Сдвиг индексов
                        while (temp != null)
                        {
                            temp.index--;
                            temp = temp.Next;
                        }
                    }
                    else
                    {
                        head = head?.Next;
                        Node<T>? temp = head; //Сдвиг индексов
                        while (temp != null)
                        {
                            temp.index--;
                            temp = temp.Next;
                        }
                        if (head == null)
                        {
                            tail = null;
                        }
                    }
                    count--;
                    return true;
                }
                previous = current;
                current = current.Next;
            }
            return false;
        }
        public void Clear()
        {
            Console.WriteLine("Вызван метод Clear()");
            head = null;
            tail = null;
            count = 0;
        }
        public bool Contains(T data)
        {
            //Console.WriteLine($"Вызван метод Contains({data})");
            if (count == 0)
                return false;
            Node<T> current = head;
            while (current != null)
            {
                if (current.Data.Equals(data))
                    return true;
                current = current.Next;
            }
            return false;
        }
        public T GetByIndex(int _index)
        {
            //Console.WriteLine($"Вызван метод GetByIndex({_index})");
            if (_index < 0 || _index >= count)
            {
                throw new IndexOutOfRangeException("GetByIndex: в метод подан некорректный индекс");
            }
            else
            {
                Node<T> node = head;
                while (node.index != _index)
                {
                    node = node.Next;
                }
                return node.Data;
            }
        }
        public int GetIndex(T data)
        {
            if (count == 0)
            {
                throw new NullReferenceException("GetIndex: метод вызван для пустого контейнера");
            }
            //Console.WriteLine($"Вызван метод GetIndex({data})");
            Node<T> current = head;
            while (current != null)
            {
                if (current.Data.Equals(data))
                    return current.index;
                current = current.Next;
            }
            return -1;
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            Node<T>? current = head;
            while (current != null)
            {
                yield return current.Data;
                current = current.Next;
            }
        }

        // реализация интерфейса IEnumerable
        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable<T>)this).GetEnumerator();
        }
    }
}
