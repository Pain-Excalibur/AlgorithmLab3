using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace AlgorithmLab3
{
    public class OurStack<T> : OurLinkedList<T>
    {
        public void Push(T data)
        {
            this.AddToTop(data);
        }

        public T Pop() 
        {
            return this.RemoveFromTop();
        }

        public T Top() 
        {
            return this.GetTop().Data;
        }
    }
}
