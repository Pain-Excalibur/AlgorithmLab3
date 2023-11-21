using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmLab3
{

    public class OurQueue<T> : OurLinkedList<T>
    {
        public void Enqueue(T data)
        {
            this.AddToBot(data);
        }
        public T Dequeue()
        {
            return this.RemoveFromTop().Data;
        }
        public T Peek()
        {
            return this.GetTop().Data;
        }
    }
}
