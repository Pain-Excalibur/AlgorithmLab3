using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmLab3
{
    public class OurLinkedList<T>
    {
        private Node<T>? top;
        private Node<T>? bottom;
        private int size = 0;

        public Node<T> GetTop()
        {
            return top;
        }

        public Node<T> GetBottom()
        {
            return bottom;
        }

        public int Size()
        {
            return size;
        }

        protected void AddToTop(T data)
        {
            Node<T> newNode = new Node<T>(data);

            if (this.top == null)
            {
                this.top = newNode;
                this.bottom = newNode;
                this.top.Previous = this.bottom;
                this.bottom.Next = this.top;
            }
            else
            {
                this.top.Next = newNode;
                newNode.Previous = this.top;
                this.top = newNode;
            }

            size++;
        }

        protected void AddToBot(T data)
        {
            Node<T> newNode = new Node<T>(data);

            if (this.top == null)
            {
                this.top = newNode;
                this.bottom = newNode;
                this.top.Previous = this.bottom;
                this.bottom.Next = this.top;
            }
            else
            {
                this.bottom.Previous = newNode;
                newNode.Next = this.bottom;
                this.bottom = newNode;
            }

            size++;
        }

        protected Node<T> RemoveFromTop()
        {
            if (this.IsEmpty())
                throw new NullReferenceException();
            Node<T> nodeToDelete = this.bottom;
            this.bottom = bottom.Next;
            size--;
            return nodeToDelete;
        }

        protected Node<T> RemoveFromBot()
        {
            if (this.IsEmpty())
                throw new NullReferenceException();
            Node<T> nodeToDelete = this.top;
            this.top = top.Previous;
            size--;
            return nodeToDelete;
        }

        public bool IsEmpty()
        {
            return this.top == null;
        }

        public T[] Print()
        {
            T[] array = new T[size];

            Node<T> current = this.top;
            if(!this.IsEmpty())
            for(int i = 0;i<size;i++)
            {
                array[i] = current.Data;
                Console.Write(array[i]+" ");
            }
            return array;
        }

    }
    public class Node<T>
    {
        public Node(T data)
        {
            Data = data;
        }
        public T Data { get; set; }
        public Node<T> Previous { get; set; }
        public Node<T> Next { get; set; }
    }
}
