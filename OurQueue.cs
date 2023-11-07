using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static AlgorithmLab3.OurStack;

namespace AlgorithmLab3
{

    public class OurQueue
    {
        public QueueNode first;
        public QueueNode last;

        public void Enqueue(string data)
        {
            QueueNode newElement = new QueueNode(data);
            if (first == null) 
            {
                first = last = newElement;
            }
            else
            {
                last.next = newElement;
                last = newElement;
            }
        }
        public string Dequeue()
        {
            string peek = null;
            if (first != null)
            {
                peek = first.data;
                first = first.next;
            }
            return peek;
        }
        public string Peek()
        {
            if (first == null)
                return null;
            return first.data;
        }

        public bool IsEmpty()
        {
            return first == null;
        }
        public void Print()
        {
            QueueNode current = first;

            while (current != null)
            {
                Console.Write(current.data + " ");
                current = current.next;
            }
        }
    }

    public class QueueNode
    {
        public string data;
        public QueueNode next;

        public QueueNode(string data) 
        {
            this.data = data;
            this.next = null;
        }
    }

}
