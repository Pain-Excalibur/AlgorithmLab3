using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmLab3
{
    public class OurStack
    {
        //top node
        public StackNode topElem;

        //Push element to stack
        public void Push(string data)
        {
            StackNode nodeToAdd = new StackNode()
            {
                data = data,
                prevElem = topElem
            };
            topElem = nodeToAdd;
        }

        //Pop element from stack
        public string Pop() 
        {
            if (topElem == null)
            {
                return null;
            }
            StackNode elemToPop = topElem;
            topElem = topElem.prevElem;
            return elemToPop.data;
        }

        //Return top element
        public string Top() 
        {
            if (topElem == null)
            {
                return null;
            }
            return topElem.data;
        }

        //Returns 1 if stack is empty
        public bool IsEmpty()
        {
            return topElem == null;
        }

        
        public void Print()
        {
            StackNode current = topElem;

            while (current != null)
            {
                Console.Write(current.data + " ");
                current = current.prevElem;
            }
        }

        public void Clear()
        {
            topElem = null;
        }
        
    }

    //node
    public class StackNode
    {
        //previous node
        public StackNode? prevElem;

        //current node data
        public string? data;
    }
}
