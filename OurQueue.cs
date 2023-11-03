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
        public static QueueNode first;
        public static QueueNode last;

        public static void Enqueue(string data)
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
        public static string Dequeue()
        {
            string peek = null;
            if (first != null)
            {
                peek = first.data;
                first = first.next;
            }
            return peek;
        }
        public static string Peek()
        {
            if (first == null)
                return null;
            return first.data;
        }

        public static bool IsEmpty()
        {
            return first == null;
        }
        public static void Print()
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
