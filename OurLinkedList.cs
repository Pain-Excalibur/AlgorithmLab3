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
            }
            else
            {
                this.top.Next = newNode;
                newNode.Previous = this.top;
                this.top = newNode;
            }

            size++;
        }

        protected void AddToBottom(T data)
        {
            Node<T> newNode = new Node<T>(data);

            if (this.top == null)
            {
                this.top = newNode;
                this.bottom = newNode;
            }
            else
            {
                this.bottom.Previous = newNode;
                newNode.Next = this.bottom;
                this.bottom = newNode;
            }

            size++;
        }

        protected Node<T> RemoveFromBottom()
        {
            if (this.IsEmpty())
                throw new NullReferenceException();
            Node<T> nodeToDelete = this.bottom;
            this.bottom = bottom.Next;
            this.bottom.Previous = null;
            size--;
            return nodeToDelete;
        }

        protected Node<T> RemoveFromTop()
        {
            if (this.IsEmpty())
                throw new NullReferenceException();

            Node<T> nodeToDelete = this.top;
            if (this.Size() != 1)
            {
                this.top.Previous.Next = null;
                this.top = top.Previous;
            }
            else
            {
                this.top = this.bottom = null;
            }
            size--;
            return nodeToDelete;
        }

        public bool IsEmpty()
        {
            return size == 0;
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
                    current = current.Previous;
            }
            return array;
        }

        //task4

        public void Reverse()//1 
        {
            if (this.IsEmpty())
                throw new NullReferenceException();

            Node<T> current = this.top;
            for(int i = 0; i<size;i++)
            {
                (current.Next, current.Previous) = (current.Previous, current.Next);
                current = current.Next;
            }
            (this.top, this.bottom) = (this.bottom, this.top);
        }

        public void SwapEnds()//2
        {
            (this.top.Data, this.bottom.Data) = (this.bottom.Data, this.top.Data);
        }

        public int CountDifElems()//3
        {
            HashSet<T> uniqueElems = new HashSet<T>();
            Node<T> current = this.top;

            for (int i = 0; i < size; i++)
            {
                uniqueElems.Add(current.Data);
                current = current.Previous;
            }
            return uniqueElems.Count;
        }

        public void MakeUnique()//4
        {
            HashSet<T> uniqueElems = new HashSet<T>();

            Node<T> current = this.top;
            for (int i = 0; i < size; i++)
            {
                uniqueElems.Add(current.Data);
                current = current.Previous;
            }

            current = this.top;
            bool doubleChecker = false;
            for (int i = 0; i < size; i++)
            {
                if(doubleChecker)
                    //TODO
                if(uniqueElems.Contains(current.Data))
                    doubleChecker = true;
                current = current.Previous;
            }
        }

    }
    public class Node<T>
    {
        public Node(T data)
        {
            Data = data;
        }
        public T Data { get; set; }
        public Node<T>? Previous { get; set; }
        public Node<T>? Next { get; set; }
    }
}
