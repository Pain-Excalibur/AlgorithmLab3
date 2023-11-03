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
        public static StackNode topElem;

        //Push element to stack
        public static void Push(string data)
        {
            StackNode nodeToAdd = new StackNode()
            {
                data = data,
                prevElem = topElem
            };
            topElem = nodeToAdd;
        }

        //Pop element from stack
        public static string Pop() 
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
        public static string Top() 
        {
            if (topElem == null)
            {
                return null;
            }
            return topElem.data;
        }

        //Returns 1 if stack is empty
        public static bool IsEmpty()
        {
            return topElem == null;
        }

        
        public static void Print()
        {
            StackNode current = topElem;

            while (current != null)
            {
                Console.Write(current.data + " ");
                current = current.prevElem;
            }
        }

        public static void Clear()
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
