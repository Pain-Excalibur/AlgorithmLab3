using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

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

        protected T RemoveFromBottom()
        {
            if (this.IsEmpty())
                throw new NullReferenceException();
            Node<T> nodeToDelete = this.bottom;
            if (this.Size() != 1)
            {
                this.bottom.Next.Previous = null;
                this.bottom = bottom.Next;
            }
            else
            {
                this.top = this.bottom = null;
            }
            size--;
            return nodeToDelete.Data;
        }

        protected T RemoveFromTop()
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
            return nodeToDelete.Data;
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

        public bool IsElem(T data)
        {
            Node<T> current = this.top;
            while(current != null)
            {
                if (EqualityComparer<T>.Default.Equals(data, current.Data))
                    return true;
                current = current.Previous;
            }
            return false;
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

        public void TopToBot()//2.1
        {
            this.AddToBottom(this.RemoveFromTop());
        }

        public void BotToTop()//2.2
        {
            this.AddToTop(this.RemoveFromBottom());
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
            int previousSize = size;

            Node<T> current = this.top;
            for (int i = 0; i < previousSize; i++)
            {
                if (!uniqueElems.Contains(current.Data))
                    this.AddToTop(current.Data);
                uniqueElems.Add(current.Data);
                current = current.Previous;
            }

            for (int i = 0; i < previousSize; i++)
            {
                this.RemoveFromBottom();
            }
            this.Reverse();
        }

        public void SelfInsert(T data)//5
        {
            OurLinkedList<T> self = new OurLinkedList<T>();
            OurLinkedList<T> temp = new OurLinkedList<T>();

            Node<T> current = this.top;
            while (current!=null)
            {
                self.AddToBottom(current.Data);
                current = current.Previous;
            }
            
            do
            {
                temp.AddToTop(this.RemoveFromBottom());
            } while (!this.IsEmpty() && !EqualityComparer<T>.Default.Equals(data, temp.top.Data));

            while (self.size > 0)
            {
                this.AddToBottom(self.RemoveFromTop());
            }

            while (temp.size > 0)
            {
                this.AddToBottom(temp.RemoveFromTop());
            }
        }

        public void Insert(T place, T elem)
        {
            OurLinkedList<T> temp = new OurLinkedList<T>();

            do
            {
                temp.AddToTop(this.RemoveFromBottom());
            } while (!this.IsEmpty() && !EqualityComparer<T>.Default.Equals(place, temp.top.Data));

            this.AddToBottom(elem);

            while (temp.size > 0)
            {
                this.AddToBottom(temp.RemoveFromTop());
            }
        }

        public void OrderedInsert(T data)//6
        {
            this.Insert(data, data);
        }

        public void DeleteAll(T data)//7
        {
            if (!this.IsElem(data))
                return;

            OurLinkedList<T> temp = new OurLinkedList<T>();

            while (!EqualityComparer<T>.Default.Equals(data, this.bottom.Data))
            {
                temp.AddToTop(this.RemoveFromBottom());
            }

            this.RemoveFromBottom();

            while (temp.size > 0)
            {
                this.AddToBottom(temp.RemoveFromTop());
            }
            this.DeleteAll(data);
        }

        public void IfElemInsert(T place, T elem)//8
        {
            if (this.IsElem(place))
            {
                this.Insert(place, elem);
            }
                
        }

        public void Append(OurLinkedList<T> newList)//9 оформить ввод считывание из файла
        {
            newList.Reverse();
            Node<T> current = newList.top;

            while (current != null)
            {
                this.AddToTop(current.Data);
                current = current.Previous;
            }
        }

        public OurLinkedList<T> Split(T divider)//10
        {
            if (!this.IsElem(divider))
                return null;

            OurLinkedList<T> top = new OurLinkedList<T>();

            while (this.top != null && !EqualityComparer<T>.Default.Equals(this.top.Data, divider))
            {
                top.AddToTop(this.RemoveFromTop());
            }
            top.Reverse();
            return top;
        }

        public void Double()//11
        {
            OurLinkedList<T> self = new OurLinkedList<T>();
            OurLinkedList<T> temp = new OurLinkedList<T>();

            Node<T> current = this.top;
            while (current != null)
            {
                self.AddToBottom(current.Data);
                current = current.Previous;
            }

            while (self.size > 0)
            {
                this.AddToBottom(self.RemoveFromTop());
            }
        }

        public void Swap(T first, T second)//12
        {
            Node<T> current = this.top;
            while (current != null)
            {
                if(EqualityComparer<T>.Default.Equals(current.Data, first))
                {
                    current.Data = second;
                }
                else if (EqualityComparer<T>.Default.Equals(current.Data, second))
                {
                    current.Data = first;
                }
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
